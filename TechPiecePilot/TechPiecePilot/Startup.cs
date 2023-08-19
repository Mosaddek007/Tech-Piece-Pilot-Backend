using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;


[assembly: OwinStartup(typeof(TechPiecePilot.Startup))]

namespace TechPiecePilot
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureJwtAuth(app);
        }

        private void ConfigureJwtAuth(IAppBuilder app)
        {
            string secretKey = ConfigurationManager.AppSettings["JwtKey"];
            var keyByteArray = Encoding.ASCII.GetBytes(secretKey);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = ConfigurationManager.AppSettings["JwtIssuer"],
                ValidAudience = ConfigurationManager.AppSettings["JwtAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(keyByteArray),
            };

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                TokenValidationParameters = tokenValidationParameters
            });

        }



    }

}
