using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Sistema.Startup))]


namespace Sistema
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                CookieName = "AGC.SIGMA",
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                LogoutPath = new PathString("/Cuenta/CerrarSesion")
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;
            //app.MapSignalR();
        }
    }
}