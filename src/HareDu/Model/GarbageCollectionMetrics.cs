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
namespace HareDu.Model
{
    using Newtonsoft.Json;

    public interface GarbageCollectionMetrics
    {
        [JsonProperty("connection_closed")]
        long ConnectionsClosed { get; }

        [JsonProperty("channel_closed")]
        long ChannelsClosed { get; }

        [JsonProperty("consumer_deleted")]
        long ConsumersDeleted { get; }
        
        [JsonProperty("exchange_deleted")]
        long ExchangesDeleted { get; }

        [JsonProperty("queue_deleted")]
        long QueuesDeleted { get; }

        [JsonProperty("vhost_deleted")]
        long VirtualHostsDeleted { get; }

        [JsonProperty("node_node_deleted")]
        long NodesDeleted { get; }

        [JsonProperty("channel_consumer_deleted")]
        long ChannelConsumersDeleted { get; }
    }
}