﻿namespace HareDu.Tests
{
    using System;
    using System.Net;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model;
    using NUnit.Framework;

    [TestFixture]
    public class VirtualHostTests :
        HareDuTestBase
    {
        [Test]
        public async Task Verify_GetAll_works()
        {
            Result<IEnumerable<VirtualHost>> result = await Client
                .Factory<VirtualHostResource>(x => x.Credentials("guest", "guest"))
                .GetAll();

            foreach (var vhost in result.Data)
            {
                Console.WriteLine("Name: {0}", vhost.Name);
                Console.WriteLine("Tracing: {0}", vhost.Tracing);
                Console.WriteLine("****************************************************");
                Console.WriteLine();
            }
        }

        [Test]
        public async Task Verify_Get_works()
        {
            Result<VirtualHost> result = await Client
                .Factory<VirtualHostResource>(x => x.Credentials("guest", "guest"))
                .Get("HareDu");

            Console.WriteLine("Name: {0}", result.Data.Name);
            Console.WriteLine("Tracing: {0}", result.Data.Tracing);
            Console.WriteLine("****************************************************");
            Console.WriteLine();
        }

        [Test]
        public async Task Verify_Create_works()
        {
            Result result = await Client
                .Factory<VirtualHostResource>(x => x.Credentials("guest", "guest"))
                .Create("HareDu3");

            Console.WriteLine("Reason: {0}", result.Reason);
            Console.WriteLine("StatusCode: {0}", result.StatusCode);
            Console.WriteLine("****************************************************");
            Console.WriteLine();
        }

        [Test]
        public async Task Verify_Delete_works()
        {
            Result result = await Client
                .Factory<VirtualHostResource>(x => x.Credentials("guest", "guest"))
                .Delete("HareDu2");

            Console.WriteLine("Reason: {0}", result.Reason);
            Console.WriteLine("StatusCode: {0}", result.StatusCode);
            Console.WriteLine("****************************************************");
            Console.WriteLine();
        }
    }
}