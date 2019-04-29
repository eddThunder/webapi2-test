using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System;
using System.Web.Http;
using WebAPIService.App_Start;
using WebAPIService.Auth;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Web.config", Watch = true)]
[assembly: OwinStartup(typeof(WebAPIService.Startup))]
namespace WebAPIService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureOAuth(app);

            //CORS
            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);

            //Ninject
            var kernel = NinjectWebCommon.CreateKernel();
            app.UseNinjectMiddleware(() => kernel);
            app.UseNinjectWebApi(config);

            // app.UseWebApi(config);

        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(20),
                Provider = new AuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}