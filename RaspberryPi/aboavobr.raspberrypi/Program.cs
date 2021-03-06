﻿using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace aboavobr.raspberrypi
{
   public class Program
   {
      public static void Main(string[] args)
      {
         CreateWebHostBuilder(args).Build().Run();
      }

      public static IWebHostBuilder CreateWebHostBuilder(string[] args)
      {
         return WebHost.CreateDefaultBuilder(args)
            .UseUrls("http://0.0.0.0:5000")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>();
      }
   }
}
