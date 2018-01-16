﻿using System.Web.Mvc;
using CarDealer.App.Security;
using CarDealer.Models.ViewModels.Log;
using CarDealer.Services;

namespace CarDealer.App.Controllers
{
    [RoutePrefix("Logs")]
    public class LogsController : Controller
    {
        private LogsService service;

        public LogsController()
        {
            this.service = new LogsService();
        }

        [HttpGet]
        [Route("All/{username?}")]
        public ActionResult All(string username, int? page)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All", "Suppliers");
            }
            LogsAllPageVm vm = this.service.GetAllLogsPageVm(username, page);
            return this.View(vm);
        }

         [HttpGet]
        [Route("deleteAll")]    
        public ActionResult DeleteAll() => this.View();

        [HttpPost]
        [Route("deleteAll")]
        public ActionResult DeleteAlll()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All", "Suppliers");
            }

            this.service.DeleteAllLogs();
            return this.RedirectToAction("All", "Suppliers");
        }
    }
}