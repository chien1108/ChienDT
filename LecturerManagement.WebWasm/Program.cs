using Blazored.LocalStorage;
using Blazored.Toast;
using LecturerManagement.Server.Configurations;
using LecturerManagement.Server.CustomAuthState;
using LecturerManagement.Server.Services.AuthServices;
using LecturerManagement.Server.Services.Base;
using LecturerManagement.Server.Services.StandardTimeServices;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Threading.Tasks;

namespace LecturerManagement.Server
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddBlazoredToast();
            builder.Services.AddScoped<JwtSecurityTokenHandler>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddHttpClient<IClient, Client>(cl => cl.BaseAddress = new Uri("http://localhost:8868/"));
            //builder.Services.TryAddSingle<IHttpContextAccessor, HttpContextAccessor>
            #region DI Service
           
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IStandardTimeService, StandardTimeService>();

            #endregion DI Service

            builder.Services.AddAutoMapper(typeof(MapperConfig));
            builder.Services.AddScoped<CustomApiAuthStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(p =>
                p.GetRequiredService<CustomApiAuthStateProvider>());

            builder.Services.AddSingleton<HttpClient>();

            await builder.Build().RunAsync();
        }
    }
}