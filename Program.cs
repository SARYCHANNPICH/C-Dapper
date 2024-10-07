using DeepDapper.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeepDapper.GUI;

namespace DeepDapper
{
    internal static class Program
    {

        public static ServiceProvider ServiceProvider;
        public static string DB_CODE = "B16"; 
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
       {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
             var services = new ServiceCollection();
            services.AddConfiguration();
            services.AddFormConfigureServices();

             var serviceProvider = services.BuildServiceProvider();
            ServiceProvider = serviceProvider;
            serviceProvider.AddConnectionString();
           
            var mainView = serviceProvider.GetRequiredService<Userfrm>();
            Application.Run (mainView);
        }
    }
}
