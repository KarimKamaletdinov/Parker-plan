using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParkerPlan.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MudBlazor;
using MudBlazor.Services;
using ParkerPlan.QueryHandlers;
using ParkerPlan.Repositories;

namespace ParkerPlan.Web
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
            services.AddScoped<GoodsService>();
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

    class Rls : IResizeListenerService
    {
        public void Dispose()
        {
         
        }

        public ValueTask<BrowserWindowSize> GetBrowserWindowSize()
        {
            return new ValueTask<BrowserWindowSize>(new BrowserWindowSize());
        }

        public Task<bool> IsMediaSize(Breakpoint breakpoint)
        {
            return new Task<bool>(() => true);
        }

        public bool IsMediaSize(Breakpoint breakpoint, Breakpoint reference)
        {
            return true;
        }

        public Task<Breakpoint> GetBreakpoint()
        {
            return new Task<Breakpoint>(() => Breakpoint.Always);
        }

        public event EventHandler<BrowserWindowSize>? OnResized;
        public event EventHandler<Breakpoint>? OnBreakpointChanged;
    }
}
