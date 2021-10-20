using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models.BaseModels.Identity;
using Services;
using Services.DapperExtension;
using Services.Implementation.CRM;
using Services.Implementation.Custom;
using Services.Implementation.Diary;
using Services.Implementation.Generic;
using Services.Implementation.Repair;
using Services.Implementation.System;
using Services.Implementation.Vehicles;
using Services.Interfaces;
using Services.Interfaces.CRM;
using Services.Interfaces.Custom;
using Services.Interfaces.Dapper;
using Services.Interfaces.Diary;
using Services.Interfaces.Generic;
using Services.Interfaces.Repair;
using Services.Interfaces.System;
using Services.Interfaces.Vehicles;

namespace Web
{
    public class Startup
    {
        private readonly IConfiguration configurationService;

        public Startup(IConfiguration configurationService)
        {
            this.configurationService = configurationService;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<GarageDreamDbContext>(options => options.UseSqlServer(configurationService.GetConnectionString("default")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<GarageDreamDbContext>();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
            });

            services.AddTransient<IAddress, Address_Implementation>();
            services.AddTransient<IContactMethodType, ContactMethodType_Implementation>();
            services.AddTransient<ICustomer, Customer_Implementation>();
            services.AddTransient<ICustomerContactDetail, CustomerContactDetail_Implementation>();
            services.AddTransient<ICustomComponents, CustomComponents_Implementation>();
            services.AddTransient<IDapper, Dapper_Implementation>();
            services.AddTransient<IDiaryOption, DiaryOption_Implementation>();
            services.AddTransient<IDiarySlot, DiarySlot_Implementation>();
            services.AddTransient<IFuelType, FuelType_Implementation>();
            services.AddTransient<IGender, Gender_Implementation>();
            services.AddTransient<IRepairHeader, RepairHeader_Implementation>();
            services.AddTransient<IRepairStatus, RepairStatus_Implementation>();
            services.AddTransient<IStaticLists, StaticLists_Implementation>();
            services.AddTransient<ISystemJob, SystemJob_Implementation>();
            services.AddTransient<ISystemJobHistory, SystemJobHistory_Implementation>();
            services.AddTransient<ITitle, Title_Implementation>();
            services.AddTransient<IVehicle, Vehicle_Implementation>();
            services.AddTransient<IVehicleMake, VehicleMake_Implementation>();
            services.AddTransient<IVehicleModel, VehicleModel_Implementation>();
            services.AddTransient<IWorkArea, WorkArea_Implementation>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseNodeModules();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
