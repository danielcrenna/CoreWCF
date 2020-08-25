using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CoreWCF.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ServiceContract;
using Services;
using Xunit;

namespace CoreWCF.Http.Tests.IntegrationTests
{
    public class WsdlTests : IClassFixture<IntegrationTest<WsdlTests.Startup>>
    {
        private readonly IntegrationTest<Startup> _factory;

        public WsdlTests(IntegrationTest<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task MetadataEndpointIsAvailable()
        {
            var client = _factory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri("http://localhost:8080/BasicWcfService/basichttp.svc?wsdl", UriKind.Absolute));
            var response = await client.SendAsync(request);
            Assert.True(response.StatusCode == HttpStatusCode.OK);
        }

        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddServiceModelServices();
            }

            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                app.UseServiceModel(builder =>
                {
                    builder.AddService<EchoService>();
                    builder.AddServiceEndpoint<EchoService, IEchoService>(new BasicHttpBinding(), "/BasicWcfService/basichttp.svc");
                });
            }
        }
    }
}
