using Blazored.LocalStorage;
using Blazored.Toast;
using LecturerManagement.Wasm.UI.CustomAuthState;
using LecturerManagement.Wasm.UI.Services.Authentication;
using LecturerManagement.Wasm.UI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LecturerManagement.Wasm.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:8868") });

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddBlazoredToast();
            //builder.Services.AddScoped<JwtSecurityTokenHandler>();
            builder.Services.AddScoped<CustomApiAuthStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(p =>
                p.GetRequiredService<CustomApiAuthStateProvider>());
            builder.Services.AddAuthorizationCore();

            builder.Services.AddScoped<IClient, Client>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            await builder.Build().RunAsync();
        }
    }
}
