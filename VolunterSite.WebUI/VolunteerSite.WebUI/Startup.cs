﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VolunteerSite.Data.Context;
using VolunteerSite.Data.Implementation.EFCore;
using VolunteerSite.Data.Interfaces;
using VolunteerSite.Domain.Models;
using VolunteerSite.Service.Services;

namespace VolunteerSite.WebUI
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            GetDependencyResolvedForEFCoreLayer(services);

            //GetDependencyResolvedForMockRepositoryLayer(services);

            GetDependencyResolvedForServiceLayer(services);

            services.AddDbContext<VolunteerSiteDbContext>();
            services.AddDefaultIdentity<AppUser>()
                .AddEntityFrameworkStores<VolunteerSiteDbContext>();

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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void GetDependencyResolvedForMockRepositoryLayer(IServiceCollection services)
        {
            services.AddScoped<IGroupMemberRepository, EFCoreGroupMemberRepository>();
            services.AddScoped<IJobListingRepository, EFCoreJobListingRepository>();
            services.AddScoped<IOrganizationRepository, EFCoreOrganizationRepository>();
            services.AddScoped<IVolunteerGroupRepository, EFCoreVolunteerGroupRepository>();
        }
        private void GetDependencyResolvedForEFCoreLayer(IServiceCollection services)
        {
            services.AddScoped<IGroupMemberRepository, EFCoreGroupMemberRepository>();
            services.AddScoped<IJobListingRepository, EFCoreJobListingRepository>();
            services.AddScoped<IOrganizationRepository, EFCoreOrganizationRepository>();
            services.AddScoped<IVolunteerGroupRepository, EFCoreVolunteerGroupRepository>();
        }

        private void GetDependencyResolvedForServiceLayer(IServiceCollection services)
        {
            services.AddScoped<IGroupMemberService, GroupMemberService>();
            services.AddScoped<IJobListingService, JobListingService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IVolunteerService, VolunteerService>();
        }
    }
}
