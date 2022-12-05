using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DbScaffoldingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateDefaultBuilder().Build();
            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            //var workerInstance = provider.GetRequiredService<Worker>();
            //workerInstance.DoWork();
            host.Run();
        }

        static IHostBuilder CreateDefaultBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(app =>
                {
                    app.AddJsonFile("appsettings.json");
                })
                .ConfigureServices(services =>
                {
                    //services.AddSingleton<Worker>();
                });
        }
    }
}



///*  AUTO CREATE DB FOR SCAFFOLD

//	 ALL DB READ DEV : CODE -  dotnet ef dbcontext scaffold --data-annotations --force Name=ConnectionStrings:ConnectionContextDev Microsoft.EntityFrameworkCore.SqlServer --context ApplicationDbContextDev --context-namespace DataAccess --namespace Entities.EntityDev --output-dir ../Entities/EntityDev --context-dir ../DataAccess/DbContexDev

//	ALL DB READ:               dotnet ef dbcontext scaffold --data-annotations --force Name=ConnectionStrings:ConnectionContext Microsoft.EntityFrameworkCore.SqlServer --context ApplicationDbContext --context-namespace DataAccess --namespace Entities.Entity --output-dir ../Entities/Entity --context-dir ../DataAccess/DbContex


