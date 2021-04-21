using Arbbet.Connectors.Dal;
using Arbbet.Connectors.Dal.Configuration;
using Arbbet.DataExplorer.Configuration;
using Arbbet.DataExplorer.Identity.Configuration;
using Arbbet.DataExplorer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbbet.DataExplorer
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; private set; }
        public IWebHostEnvironment Environment { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<EmailSenderConfiguration>(Configuration.GetSection(EmailSenderConfiguration.SectionName));
            services.Configure<IdentityConfiguration>(Configuration.GetSection(IdentityConfiguration.SectionName));
            IdentityConfiguration identityConfigurationSection = (IdentityConfiguration)Configuration.GetSection(IdentityConfiguration.SectionName).Get(typeof(IdentityConfiguration));
            IOptions<IdentityConfiguration> identityConfiguration = Options.Create(identityConfigurationSection);

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddScoped<IEmailSender, EmailSender>();

            Connectors.Dal.Configuration.ConfigurationExtension.ConfigureDbContext(services);
            Identity.Configuration.ConfigurationExtension.ConfigureIdentity(services, identityConfiguration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
