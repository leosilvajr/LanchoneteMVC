using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace LanchoneteMVC
{
    public class Startup
    {
        //Teste
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }



        //Aqui vamos configurar os Serviços da aplicação
        public void ConfigureServices(IServiceCollection services)
        {
            //Controla as Views e os Controladores
            services.AddControllersWithViews();
        }

        //Configura o pipeline de processamento do aplicativo.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Verifica se estamos em um ambiente de desenvolvimento.
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
            });
        }
    }
}
