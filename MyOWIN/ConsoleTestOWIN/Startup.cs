using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ConsoleTestOWIN.Startup))]

namespace ConsoleTestOWIN
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888

            HttpConfiguration configuration = new HttpConfiguration();
            configuration.Routes.MapHttpRoute(
                name: "default", 
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
            app.UseWebApi(configuration);

            //注意：

            //1、defaults: new { id = RouteParameter.Optional }
            // 设置http://ip:port/api/{controller}/{id}中的id是否需要

            //2、如果 路由模板是 routeTemplate: "api/{controller}/{action}/{id}",，
            //访问:http://ip:port/api/{controller}/{action}/{id}

            //如果 路由模板是 routeTemplate: "api/{controller}/{id}",，
            //访问:http://ip:port/api/{controller}/{id}
            //以上两种 路由模板设置是有区别的
        }
    }
}
