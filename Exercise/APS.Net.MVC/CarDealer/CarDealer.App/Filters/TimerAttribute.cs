using System;
using System.Diagnostics;
using System.IO;
using System.Web.Mvc;

namespace CarDealer.App.Filters
{
    public class TimerAttribute : ActionFilterAttribute
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            this._stopwatch.Start();
            base.OnActionExecuted(filterContext);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this._stopwatch.Stop();
            var timePassed = _stopwatch.Elapsed;
            this._stopwatch.Reset();

            var logTimeStamp = DateTime.Now;
            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var actionName = filterContext.ActionDescriptor.ActionName;
            string log = $"{logTimeStamp} – {controllerName}.{actionName} – {timePassed}";
            File.AppendAllText(@"c:\temp\timer.log", log);
            base.OnActionExecuting(filterContext);
        }
    }
}