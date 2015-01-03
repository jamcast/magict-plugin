﻿/*-
 * Copyright (c) 2015 Software Development Solutions, Inc.
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 * 1. Redistributions of source code must retain the above copyright
 *    notice, this list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in the
 *    documentation and/or other materials provided with the distribution.
 *
 * THIS SOFTWARE IS PROVIDED BY THE AUTHOR AND CONTRIBUTORS ``AS IS'' AND
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED.  IN NO EVENT SHALL THE AUTHOR OR CONTRIBUTORS BE LIABLE
 * FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
 * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS
 * OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
 * HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
 * LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY
 * OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF
 * SUCH DAMAGE.
 */

using System.IO;
using System.Reflection;
using Jamcast.Extensibility.MediaServer;
using Jamcast.Extensibility.Metadata;

namespace Jamcast.Plugins.MagicTransistor
{
    public class AlbumArtHandler : MediaRequestHandler
    {
        private static Stream _stream;

        public override RequestInitializationResult Initialize()
        {
            if (_stream == null)
                _stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Jamcast.Plugins.MagicTransistor.icon.png");

            RequestInitializationResult result = new RequestInitializationResult()
            {
                CanProceed = true,
                IsConversion = this.Context.Format != MediaFormats.PNG,
                TotalBytes = _stream.Length
            };

            return result;
        }

        public override DataPipeBase RetrieveMedia()
        {
            return new StreamDataPipe("MagicTransistor Album Art", _stream);
        }
    }
}