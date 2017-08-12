﻿namespace HareDu.Tests
{
    using System;
    using System.Threading.Tasks;
    using NUnit.Framework;

    [TestFixture]
    public class QueueTests :
        HareDuTestBase
    {
        [Test]
        public void Test()
        {
            var result = Client
                .Factory<Queue>()
                .Create("Q1", "HareDu", x =>
                {
                    x.IsDurable();
                    x.WithArguments(a =>
                    {
                        a.SetDeadLetterExchange("E1");
                        a.SetQueueExpiration(1000);
                        a.SetPerQueuedMessageExpiration(1000);
                    });
                });
        }

        [Test]
        public void Test2()
        {
            var result = Client
                .Factory<Queue>()
                .GetAll()
                .Where(x => x.Name == "HareDu");
            
            foreach (var queue in result)
            {
                Console.WriteLine("Name: {0}", queue.Name);
                Console.WriteLine("VirtualHost: {0}", queue.VirtualHost);
                Console.WriteLine("AutoDelete: {0}", queue.AutoDelete);
                Console.WriteLine("****************************************************");
                Console.WriteLine();
            }

        }
    }
}