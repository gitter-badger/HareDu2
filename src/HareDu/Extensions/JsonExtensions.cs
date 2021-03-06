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
namespace HareDu.Extensions
{
    using System.Collections.Generic;
    using Internal.Serialization;
    using Newtonsoft.Json;

    public static class JsonExtensions
    {
        public static string ToJson<T>(this T obj)
        {
            JsonSerializerSettings settings = GetSerializerSettings();
            string serializeObject = JsonConvert.SerializeObject(obj, settings);

            return serializeObject;
        }

        static JsonSerializerSettings GetSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include,
                DefaultValueHandling = DefaultValueHandling.Include,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                ObjectCreationHandling = ObjectCreationHandling.Auto,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                ContractResolver = new JsonContractResolver(),
                TypeNameHandling = TypeNameHandling.None,
                DateParseHandling = DateParseHandling.None,
                DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind,
                Converters = new List<JsonConverter>(new JsonConverter[]
                {
                    new ByteArrayConverter()
                }),
                Formatting = Formatting.Indented
            };
        }
    }
}