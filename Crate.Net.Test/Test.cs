using System;
using System.Collections.Generic;
using Crate.Net.Client.Models;
using NUnit.Framework;

namespace Crate.Net.Client.Tests
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void TestDefaultConnection()
        {
            var server = new CrateServer();

            Assert.AreEqual("http", server.Scheme);
            Assert.AreEqual("localhost", server.Hostname);
            Assert.AreEqual(4200, server.Port);
        }

        [Test]
        public void TestServerWithKvp()
        {
            var server = new CrateServer(new KeyValuePair<string, int>("localhost", 4200));

            Assert.AreEqual("http", server.Scheme);
            Assert.AreEqual("localhost", server.Hostname);
            Assert.AreEqual(4200, server.Port);
        }

        [Test]
        public void TestGetDateTime()
        {
            var reader = new CrateDataReader(new SqlResponse
            {
                Rows = new[] { new object[] { 1388534400000 } },
                Cols = new[] { "dt" }
            });

            reader.Read();
            var dt = new DateTime(2014, 01, 01);

            Assert.AreEqual(dt, reader.GetDateTime(0));
        }
    }
}

