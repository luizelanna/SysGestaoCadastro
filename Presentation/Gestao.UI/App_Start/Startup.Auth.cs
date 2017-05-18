﻿using System;
using System.Web.Mvc;
using Gestao.Infra.CrossCutting.Identity.Configuration;
using Gestao.Infra.CrossCutting.Identity.Context;
using Gestao.Infra.CrossCutting.Identity.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Owin;

namespace Gestao.UI
{
    public partial class Startup
    {
        public static IDataProtectionProvider DataProtectionProvider { get; set; }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(() => DependencyResolver.Current.GetService<ApplicationUserManager>());

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }
}
//    public partial class Startup
//    {
//        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
//        public void ConfigureAuth(IAppBuilder app)
//        {
//            // Configure o contexto db, gerenciador de usuários e gerenciador de login para usar uma única instância por solicitação
//            app.CreatePerOwinContext(ApplicationDbContext.Create);
//            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
//            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

//            // Habilitar o aplicativo a usar um cookie para armazenar informações do usuário logado
//            // e para usar um cookie para armazenar temporariamente informações sobre um usuário fazendo logon com um provedor de logon de terceiros
//            // Configurar o cookie de logon
//            app.UseCookieAuthentication(new CookieAuthenticationOptions
//            {
//                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
//                LoginPath = new PathString("/Account/Login"),
//                Provider = new CookieAuthenticationProvider
//                {
//                    // Permite que o aplicativo valide o carimbo de segurança quando o usuário efetuar login.
//                    // Este é um recurso de segurança que é usado quando você altera uma senha ou adiciona um login externo à sua conta.  
//                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
//                        validateInterval: TimeSpan.FromMinutes(30),
//                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
//                }
//            });            
//            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

//            // Permite que o aplicativo armazene temporariamente as informações do usuário quando ele estiver verificando o segundo fator no processo de autenticação de dois fatores.
//            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

//            // Permite que o aplicativo lembre segundo fator de verificação de login, como telefone ou email.
//            // Assim que você marcar esta opção, sua segunda etapa de verificação durante o processo de login será lembrada no dispositivo no qual você efetuou login.
//            // Isso é semelhante à opção RememberMe (Lembre-me) quando você efetua login.
//            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

//            // Remover comentário das seguintes linhas para habilitar o logon com provedores de logon de terceiros
//            //app.UseMicrosoftAccountAuthentication(
//            //    clientId: "",
//            //    clientSecret: "");

//            //app.UseTwitterAuthentication(
//            //   consumerKey: "",
//            //   consumerSecret: "");

//            //app.UseFacebookAuthentication(
//            //   appId: "",
//            //   appSecret: "");

//            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
//            //{
//            //    ClientId = "",
//            //    ClientSecret = ""
//            //});
//        }
//    }
//}