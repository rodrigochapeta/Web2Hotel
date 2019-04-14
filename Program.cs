using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Web2Hotel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args) 
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5100/","https://localhost:5101/");
    }
}
/*
1. Formulario de contacto (POST)
2. Registro usuario
3. Manager de usuarios para cambiarle el powerlevel
4. Reservas CRUD
5. Login usuario
 */