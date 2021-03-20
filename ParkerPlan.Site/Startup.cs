using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor.Services;
using ParkerPlan.Abstractions;
using ParkerPlan.Abstractions.Commands.Costumer;
using ParkerPlan.Abstractions.Commands.Good;
using ParkerPlan.Abstractions.Commands.Lead;
using ParkerPlan.Abstractions.Dtos;
using ParkerPlan.Abstractions.Queries;
using ParkerPlan.CommandHandlers.Costumer;
using ParkerPlan.CommandHandlers.Good;
using ParkerPlan.CommandHandlers.Lead;
using ParkerPlan.QueryHandlers;
using ParkerPlan.Repositories;
using ParkerPlan.Site.Data;

namespace ParkerPlan.Site
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
            services.AddMudServices();
            services.AddScoped<IQueryHandler<GetGoods, GoodDto[]>, GetGoodsQueryHandler>();
            services.AddScoped<ICommandHandler<UpdateGood>, UpdateGoodCommandHandler>();
            services.AddScoped<ICommandHandler<InsertGood>, InsertGoodCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteGood>, DeleteGoodCommandHandler>();
            services.AddScoped<SqlGoodRepository>();
            services.AddScoped<IQueryHandler<GetCostumers, CostumerDto[]>, GetCostumersQueryHandler>();
            services.AddScoped<ICommandHandler<UpdateCostumer>, UpdateCostumerCommandHandler>();
            services.AddScoped<ICommandHandler<InsertCostumer>, InsertCostumerCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteCostumer>, DeleteCostumerCommandHandler>();
            services.AddScoped<SqlCostumerRepository>();
            services.AddScoped<IQueryHandler<GetLeads, LeadDto[]>, GetLeadsQueryHandler>();
            services.AddScoped<ICommandHandler<UpdateLead>, UpdateLeadCommandHandler>();
            services.AddScoped<ICommandHandler<InsertLead>, InsertLeadCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteLead>, DeleteLeadCommandHandler>();
            services.AddScoped<SqlLeadRepository>();
            services.AddScoped<PasswordService>();
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