using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;

namespace LanchoneteMVC
{
    public class Program
    {

        //Ponto de entrada do Aplicativo
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        //Cria um host para nossa aplicação Web, usando as configurações padrão
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
