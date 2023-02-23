using LanchoneteMVC.Context;
using LanchoneteMVC.Models;
using LanchoneteMVC.Repositories;
using LanchoneteMVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //Controla as Views e os Controladores
            services.AddControllersWithViews();

            //Adicionando o Serviço do Identity
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();




            //Registrando Serviços
            /*Com esse registro, toda vez que eu solicitar uma instancia referenciando a interface,
             o conteiner nativo da injeçao de dependencia vai criar uma instancia da classe vai injetar no 
            contrutor aonde eu estiver solicitando  a instancia do repositorio.*/
            services.AddTransient<ILancheRepository, LancheRepository>();
            services.AddTransient<ICategoriaRepositoy, CategoriaRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();


            //Com isso, atravez de um serviço recuperar uma instancia de HTTP Context Acessor


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));

            services.AddMemoryCache();
            services.AddSession();
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

            app.UseSession();

            app.UseAuthorization();


            //Roteamento padrão
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "categoriaFiltro",
                pattern: "Lanche/{action}/{categoria?}",
                defaults: new { Controller = "Lanche", action = "List"});

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
