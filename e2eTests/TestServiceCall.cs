using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndersJson;
using EndersJson.Interfaces;
using Microsoft.Owin.Hosting;
using NUnit.Framework;
using WebApi2Demo;

namespace e2eTests
{
    public class TestServiceCall
    {
        readonly IJsonService _client = new JsonService();

        [Test]
        public async Task TestFoo()
        {
            using (WebApp.Start<Startup>("http://localhost:9030"))
            {
                var result = await _client.Get<string>("http://localhost:9030/api/values/1");
                Assert.That(result, Is.EqualTo("value"));
            }
        }
    }
}
