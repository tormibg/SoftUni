using System;
using System.IO;
using System.Web.Mvc;

namespace CarDealer.App.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var logTimeStamp = DateTime.Now;
            var ipAddress = filterContext.HttpContext.Request.UserHostAddress;
            var user = filterContext.HttpContext.User.Identity.Name;
            var requestCookie = filterContext.HttpContext.Request.Cookies["SessionId"];
            if (requestCookie != null)
            {
                var sessionId = requestCookie.Value;
            }
            if (string.IsNullOrEmpty(user))
            {
                user = "Anonymous";
            }
            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var actionName = filterContext.ActionDescriptor.ActionName;
            var exception = filterContext.Exception;
            string logMessage;
            if (exception == null)
            {
                logMessage = $"{logTimeStamp} – {ipAddress} – {user} – {controllerName}.{actionName}{Environment.NewLine}";
            }
            else
            {
                logMessage = $"[!] {logTimeStamp} – {ipAddress} – {user} – {controllerName}.{actionName} - {exception.GetType().Name} – {exception.Message}{Environment.NewLine}";
            }

            File.WriteAllText(@"c:\temp\log.txt", logMessage);

            base.OnActionExecuted(filterContext);
        }
    }
}