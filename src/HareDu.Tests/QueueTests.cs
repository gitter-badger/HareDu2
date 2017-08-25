﻿namespace HareDu.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Internal.Serialization;
    using Model;
    using Newtonsoft.Json;
    using NUnit.Framework;

    [TestFixture]
    public class QueueTests :
        HareDuTestBase
    {
        [Test]
        public async Task Verify_can_create_queue()
        {
            Result result = await Client
                .Factory<Queue>()
                .Create(x =>
                {
                    x.Queue("TestQueue2");
                    x.Configure(c =>
                    {
                        c.IsDurable();
                        c.WithArguments(arg =>
                        {
                            arg.SetQueueExpiration(1000);
                        });
                    });
                    x.Target(t =>
                    {
                        t.Node("MyNode1");
                        t.VirtualHost("HareDu");
                    });
                });
        }

        [Test]
        public async Task Verify_can_get_all()
        {
            Result<IEnumerable<QueueInfo>> result = await Client
                .Factory<Queue>()
                .GetAll();
            
//            foreach (var queue in result)
//            {
//                Console.WriteLine("Name: {0}", queue.Name);
//                Console.WriteLine("VirtualHost: {0}", queue.VirtualHost);
//                Console.WriteLine("AutoDelete: {0}", queue.AutoDelete);
//                Console.WriteLine("****************************************************");
//                Console.WriteLine();
//            }
//            using (StreamWriter sw = new StreamWriter("/users/albert/documents/git/test5.txt"))
//            using (JsonWriter writer = new JsonTextWriter(sw))
//            {
//                SerializerCache.Serializer.Serialize(writer, result);
//            }

            Console.WriteLine(result.ToJson());
        }

        [Test]
        public async Task Verify_can_delete_queue()
        {
            Result result = await Client
                .Factory<Queue>()
                .Delete(x =>
                {
                    x.Queue("");
                    x.Target(l => l.VirtualHost("HareDu"));
                    x.WithConditions(c =>
                    {
                        c.IfUnused();
                        c.IfEmpty();
                    });
                });
        }

        [Test]
        public async Task Verify_can_peek_messages()
        {
            Result result = await Client
                .Factory<Queue>()
                .Peek(x =>
                {
                    x.Queue("");
                    x.Target(t => t.VirtualHost("HareDu"));
                });
        }
    }
}