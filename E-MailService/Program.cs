using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.DependencyResolves.Autofac;
using Castle.DynamicProxy;
using Core.Utilities.EmailService.Abstract;
using Core.Utilities.Interceptors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_MailService
{
    static class Program
    {
       
       static string path = "http://acaribrahim.tr.ht/E-MailService/GMailApi/client_secret.json";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var container = Configure();
            Application.Run(new LogIn(container.Resolve<IUserService>(),container.Resolve<ICustomerService>(), container.Resolve<IEmailService>()));
        }

        static IContainer Configure()
        {   
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new AutofacBusinessModule());
            var container = containerBuilder.Build();
            
            return container;
        }
        static string clientSecret()
        {
            string client_secret="";
            using (WebClient client = new WebClient())
            {
                client_secret = client.DownloadString(path);
            }
            using (FileStream fs = new FileStream(@".\client_secret.json", FileMode.OpenOrCreate, FileAccess.Write))
            {
                TextWriter writer = new StreamWriter(fs);
                writer.Write(client_secret);
                fs.Close();
            }
            
            
            return client_secret;
        }
    }
}
