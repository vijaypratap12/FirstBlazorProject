﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;

namespace FirstBlazorApp.Server.Providers
{
    public class ApplicationOAuthProvider: OAuthAuthorizationServerProvider
    {

            //public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
            //{
            //    context.Validated();
            //    return Task.FromResult<object>(null);
            //}

            //public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
            //{

            //    var allowedOrigin = "*";

            //    context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            //    var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            //    ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);

            //    if (user == null)
            //    {
            //        context.SetError("invalid_grant", "The user name or password is incorrect.");
            //        return;
            //    }

            //    if (!user.EmailConfirmed)
            //    {
            //        context.SetError("invalid_grant", "User did not confirm email.");
            //        return;
            //    }

            //    ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager, "JWT");

            //    var ticket = new AuthenticationTicket(oAuthIdentity, null);

            //    context.Validated(ticket);

           // }
    }
}
