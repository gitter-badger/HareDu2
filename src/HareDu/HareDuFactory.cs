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
namespace HareDu
{
    public interface HareDuFactory
    {
        /// <summary>
        /// Creates a new instance of object implemented by T, which encapsulates a group of resources (e.g. Virtual Host, Exchange, Queue, User, etc.)
        /// that are exposed by the RabbitMQ server via its REST API.
        /// </summary>
        /// <typeparam name="TResource">Interface that derives from base interface ResourceClient.</typeparam>
        /// <param name="userCredentials">Username and password of valid user on a RabbitMQ server.</param>
        /// <returns>An interface of resources available on a RabbitMQ server.</returns>
        TResource Factory<TResource>()
            where TResource : Resource;
        
        /// <summary>
        /// 
        /// </summary>
        void CancelPendingRequest();
    }
}