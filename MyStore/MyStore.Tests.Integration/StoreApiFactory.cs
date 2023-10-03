using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Tests.Integration
{
    public class StoreApiFactory<TProgram> : WebApplicationFactory<TProgram> where
      TProgram : class
    {
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StoreTest";


        public StoreApiFactory()
        {
        }


        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test");
            builder.ConfigureTestServices(services =>
            {
                //services.RemoveAll(typeof(IHostedService));

                //services.RemoveAll(typeof(IDbConnectionFactory));

                //var dbContextDescriptor = services.SingleOrDefault(
                //d => d.ServiceType ==
                //    typeof(DbContextOptions<StoreContext>));

                //services.Remove(dbContextDescriptor);

                //services.AddDbContext<StoreContext>(options =>
                //{
                //    options.UseSqlServer(ConnectionString);
                //    options.EnableSensitiveDataLogging();
                //});

                //var sp = services.BuildServiceProvider();

                //using (var scope = sp.CreateScope())
                //{
                //    var scopedServices = scope.ServiceProvider;
                //    var db = scopedServices.GetRequiredService<StoreContext>();

                //    //  db.Database.EnsureDeleted();
                //    // db.Database.EnsureCreated();
                //}


                services.AddHttpClient("local", httpClient =>
                {
                    //api's URL
                    httpClient.BaseAddress = new Uri("https://localhost:7018/api/");

                });

                //configure the default client

            });

            builder.UseTestServer();
        }
    }
}
