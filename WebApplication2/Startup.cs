﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.ATM;
using Domain.Shared;
using Infrastructure.EFCore;
using Infrastructure.MailService.SendGrid;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OData.Edm;

namespace WebApplication2
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
            // Inject unit of work
            services.AddTransient<IUnitOfWork, EFCoreUnitOfWork>();

            // Inject mail service
            services.AddScoped<IMailService, SendGridMailService>();
            
            // Add OData
            services.AddOData();

            // Add MVC
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAll")
                .UseMvc(routeBuilder =>
                {
                    // Set up OData
                    routeBuilder.MapODataServiceRoute("odata", string.Empty, GetEdmModel());
                    routeBuilder.EnableDependencyInjection();
                });
        }

        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<Atm>("Atms")
                .EntityType
                .HasKey(o => o.Id)
                .Page(10, 10)
                .Filter(QueryOptionSetting.Allowed);

            return builder.GetEdmModel();
        }
    }
}
