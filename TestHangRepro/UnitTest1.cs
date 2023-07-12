using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.PowerApps.CoreFramework.AspNetCore;

namespace TestHangRepro
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            System.Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development"); 

            //* This Hangs
            CoreServicesWebHost
                .CreateDefaultBuilder(new string[] { })
            //*/
            /* This works
            WebHost
                .CreateDefaultBuilder(new string[] { })
            //*/
                .UseStartup(context => new EmptyStartup(context.Configuration))
                .Build();
        }
    }

    public class EmptyStartup
    {
        public EmptyStartup(IConfiguration configuration)
        {
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
        }

        public void Configure(IApplicationBuilder application)
        {
        }
    }
}