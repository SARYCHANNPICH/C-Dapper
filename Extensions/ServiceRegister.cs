using DATAACCESS.DBAccess;
using DATAACCESS.IService;
using DATAACCESS.Model;
using DATAACCESS.Service;
using DeepDapper.GUI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DeepDapper.Extensions
{
    public static class ServiceRegister
    {
        public static void AddConfiguration( this ServiceCollection service )
        {
            service.AddLogging(configure => configure.AddConsole()).AddScoped<ISqlDataAcess, SqlDataAcess>();
            service.AddSingleton<SqlServerDbSettings>();
            
            service.AddTransient<IContactService, ContactService>();
            service.AddTransient<IAgentService, AgentService>();
            service.AddTransient<IEmailService, EmailService>();
            service.AddTransient<IOrderService,OrderService>();
            service.AddTransient<IUserService,UserService>();
            service.AddTransient<ISIDBINFOService, SIDBINFOService>();
        }
        public static void AddFormConfigureServices(this ServiceCollection service)
        {
            service.AddTransient<Form1>();
            service.AddTransient<Userfrm>();
            service.AddTransient<TestingDoubleClick>();
        }
        public static void AddConnectionString(this ServiceProvider serviceProvider)
        {
            var config = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly()).Build();
            var connectionString = string.Empty;
#if DEBUG
            //connectionString =
            //    @"Data Source=.;Initial Catalog=SQLContactsDB;Integrated Security=True;";
            //connectionString = "Data Source = '192.168.1.100';Initial Catalog = 'SIDB';User ID = 'sa';Password = 'TD@dmin168';Connect Timeout=500000;";
            connectionString = "Data Source=.;Initial Catalog=SQLContactsDB;Integrated Security=True;";
#else
        connectionString = @"Data Source=51.79.251.248;Initial Catalog=HR_DATABASE_SYSTEM;TrustServerCertificate=True;User ID=sa;Password=T0n@d!g!t@l2023";
#endif
            var sqlServerDbSettings = serviceProvider.GetRequiredService<SqlServerDbSettings>();
            sqlServerDbSettings.ConnectionString = connectionString;
        }
    }
}
