﻿// Copyright 2013-2017 Albert L. Hives
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
namespace HareDu.Internal
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using Configuration;
    using Exceptions;

    internal class HareDuFactoryImpl :
        Logging,
        HareDuFactory
    {
        readonly HttpClient _httpClient;
        readonly HareDuClientSettings _settings;

        public HareDuFactoryImpl(HttpClient httpClient, HareDuClientSettings settings)
            : base(settings.LoggerSettings.Name, settings.LoggerSettings.Logger, settings.LoggerSettings.Enable)
        {
            _httpClient = httpClient;
            _settings = settings;
        }

        public TResource Factory<TResource>()
            where TResource : Resource
        {
            Type type = GetType()
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => typeof(TResource).IsAssignableFrom(x) && !x.IsInterface);

            if (type == null)
                throw new HareDuResourceInitException($"Failed to find implementation class for interface {typeof(TResource)}");
            
            return (TResource)Activator.CreateInstance(type, _httpClient, _settings);
        }

        public void CancelPendingRequest()
        {
            LogInfo("Cancelling all pending requests.");

            _httpClient.CancelPendingRequests();
        }
    }
}