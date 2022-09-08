using FirstBlazorApp.Server.Common;
using FirstBlazorApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using System.Net;

namespace FirstBlazorApp.Server.Services
{
    public class CustomResponse : IAuthorizationMiddlewareResultHandler
    {
        private readonly AuthorizationMiddlewareResultHandler _resultHandler = new AuthorizationMiddlewareResultHandler();
        public async Task HandleAsync(RequestDelegate next, HttpContext context, AuthorizationPolicy policy, PolicyAuthorizationResult authorizeResult)
        {
            if (authorizeResult.Challenged)
            {
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                await context.Response.WriteAsJsonAsync(new ErrorResponseModel(EnumResponseCode.Unauthorize, "Token Validation Has Failed. Request Access Denied"));
                return;
            }
            await _resultHandler.HandleAsync(next, context, policy, authorizeResult);
        }
    }
}
