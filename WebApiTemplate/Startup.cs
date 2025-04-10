using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Web.Http;
[assembly: OwinStartup(typeof(WebApiTemplate.Startup))]
namespace WebApiTemplate
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 配置应用程序管道
            app.UseCors(CorsOptions.AllowAll);

            HttpConfiguration config = new HttpConfiguration();
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);

            app.Map("/send", appcur => appcur.Use((ctx, next) =>
            {
                return ctx.Response.WriteAsync("ok");
            }));
        }
    }
}
