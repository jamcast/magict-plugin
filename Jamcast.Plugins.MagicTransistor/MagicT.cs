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

using System;

namespace Jamcast.Plugins.MagicTransistor
{
    public static class MagicT
    {
        public const string MT_ICECAST_URL = "http://198.154.106.98";

        private static Channel[] _stations = new Channel[]
        {
            new Channel()
            {
                Title = "Channel 5",
                Port = 8201
            },
            new Channel()
            {
                Title = "Channel 6",
                Port = 8202
            },
            new Channel()
            {
                Title = "Channel 7",
                Port = 8203
            },
            new Channel()
            {
                Title = "Channel 8",
                Port = 8204
            }
        };

        public static Channel[] GetStations()
        {
            return _stations;
        }

        public class Channel
        {
            public int Port { get; set; }

            public string Title { get; set; }

            public string StreamUrl
            {
                get
                {
                    return String.Format("{0}:{1}/stream", MT_ICECAST_URL, Port);
                }
            }
        }
    }
}