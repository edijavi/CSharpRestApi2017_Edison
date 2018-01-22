using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VideoAppBLL;
using VideoAppBLL.BusinessObjects;

namespace VideoRestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                var facade = new BLLFacade();

                var address = facade.AddressService.Create( 
                    new AddressBO() {
                        City = "Kolding",
                        Street = "Kirkegade",
                        Number = "22A"
                    });

                var address2 = facade.AddressService.Create(
                    new AddressBO()
                    {
                        City = "Esbjerg",
                        Street = "321",
                        Number = "111"
                    });
                var address3 = facade.AddressService.Create(
                    new AddressBO()
                    {
                        City = "Braming",
                        Street = "123",
                        Number = "222"
                    });

                var vid = facade.VideoService.Create(
                    new VideoBO() {
                            VideoName="Primer",
                            VideoType="Example",
                            VideoLocation="Home",
                            AddressIds = new List<int>() { address.Id, address3.Id }
                    });
                facade.VideoService.Create(
                    new VideoBO()
                    {
                            VideoName = "Second",
                            VideoType = "Example",
                            VideoLocation = "EASV",
                            AddressIds = new List<int>() { address.Id, address2.Id}
                    });

                for (int i = 0; i < 5; i++)
                {
                    facade.OrderService.Create(
                    new OrderBO()
                    {
                        DeliveryDate = DateTime.Now.AddMonths(1),
                        OrderDate = DateTime.Now.AddMonths(-1),
                        VideoId = vid.Id
                    });
                }

            }

            app.UseMvc();
        }
    }
}
