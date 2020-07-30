using System;
using System.Threading.Tasks;
using System.Web.Http;
using Hangfire;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ConsoleHangfireTest.Startup1))]

namespace ConsoleHangfireTest
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {

            //HttpConfiguration configuration = new HttpConfiguration();
            //configuration.Routes.MapHttpRoute(
            //    name: "default",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //    );
            //app.UseWebApi(configuration);

            // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888
            //定时任务的持久化使用Sqlserver进行，当然也可以使用mongodb，redis等其他的
            GlobalConfiguration.Configuration.UseSqlServerStorage("Data Source=MOP6EXV9E5J1M1F;Initial Catalog=mydb;Integrated Security=True;");
            //启用Hangfire服务
            app.UseHangfireServer();
            //启用Hangfire Dashboard面板
            app.UseHangfireDashboard();
        }
    }
}
