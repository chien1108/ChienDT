using Blazored.LocalStorage;
using Blazored.Toast;
using LecturerManagement.Server.Configurations;
using LecturerManagement.Server.UI.CustomAuthState;
using LecturerManagement.Server.UI.Services.AuthServices;
using LecturerManagement.Server.UI.Services.Base;
using LecturerManagement.Server.UI.Services.StandardTimeServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace LecturerManagement.Server.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddOptions();
            services.AddAuthorizationCore();
            services.AddBlazoredToast();
            services.AddScoped<JwtSecurityTokenHandler>();
            services.AddBlazoredLocalStorage();
            services.AddHttpClient<IClient, Client>(cl => cl.BaseAddress = new Uri(Configuration.GetSection("BackendApiUrl").Value));

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IStandardTimeService, StandardTimeService>();
            services.AddAutoMapper(typeof(MapperConfig));
            services.AddScoped<CustomApiAuthStateProvider>();
            services.AddScoped<AuthenticationStateProvider>(p =>
                p.GetRequiredService<CustomApiAuthStateProvider>());
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}