using Microsoft.AspNetCore.Mvc.Filters;
using Nutrifit.Infra.CrossCutting.Handlers.Notifications;
using System.Net;

namespace Nutrifit.Api.Filters
{
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private string ApiKeyName = "x-api-key";
        private string ApiKey = null;
        private readonly IConfiguration _configuration;
        private readonly INotificationHandler _notificationHandler;

        public ApiKeyAttribute(IConfiguration configuration, INotificationHandler notificationHandler)
        {
            _configuration = configuration;
            _notificationHandler = notificationHandler;
            ApiKey = _configuration.GetSection("KeyAuthorization:ApiKey").Value;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyName, out var extractedApiKey))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                _notificationHandler.AddNotification("Api Key não localizada");
                return;
            }

            if (!ApiKey.Equals(extractedApiKey))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                _notificationHandler.AddNotification("Api Key inválida");
                return;
            }
            await next();
        }
    }
}
