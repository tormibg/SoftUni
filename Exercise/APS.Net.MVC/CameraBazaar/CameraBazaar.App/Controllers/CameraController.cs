using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using CameraBazaar.App.Service;
using CameraBazaar.Models.BindModels.Camera;
using CameraBazaar.Models.BindModels.User;
using CameraBazaar.Models.EntityModels;
using CameraBazaar.Models.ViewModels.Cameras;
using AuthenticationManager = CameraBazaar.App.Security.AuthenticationManager;

namespace CameraBazaar.App.Controllers
{
    [RoutePrefix("cameras")]
    public class CameraController : Controller
    {
        private CameraService service;
        private AuthenticationManager authentication;

        public CameraController()
        {
            this.service = new CameraService();
            this.authentication = new AuthenticationManager();
        }

        [HttpGet]
        [Route("all")]
        [Route("~/")]
        public ActionResult All()
        {
            IEnumerable<ShortCameraVm> vms = this.service.GetAllCameras();
            return this.View(vms);
        }

        [HttpGet]
        [Route("details/{id}")]
        public ActionResult Details(int? id)
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = this.authentication.GetAuthenticatedUser(sessionId);
            DetailsCameraVm camera = this.service.GetDetailsVm(id, user);

            if (camera == null)
            {
                return HttpNotFound();
            }

            return View(camera);
        }

        [HttpGet, Route("create")]
        public ActionResult Create()
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
            if (!this.authentication.IsAuthenticated(sessionId))
            {
                return this.RedirectToAction("Login", "Users");
            }

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create")]
        public ActionResult Create([Bind(Include = "Make,Model,Price,Quantity,MinShutterSpeed,MaxShutterSpeed,MinIso,MaxIso,IsFullFrame,VideoResolution,LightMetering,Description,ImageUrl")] AddCameraBm camera)
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
            if (!this.authentication.IsAuthenticated(sessionId))
            {
                return this.RedirectToAction("Login", "Users");
            }

            if (this.ModelState.IsValid)
            {
                User user = this.authentication.GetAuthenticatedUser(sessionId);
                this.service.Create(camera, user);
                return RedirectToAction("Profile", "Users");
            }
            AddCameraVm vm = Mapper.Map<AddCameraBm, AddCameraVm>(camera);
            return View(vm);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
            if (!this.authentication.IsAuthenticated(sessionId))
            {
                return this.RedirectToAction("Login", "Users");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = this.authentication.GetAuthenticatedUser(sessionId);
            EditCameraVm vm = this.service.GetEditVm(id, user);

            if (vm == null)
            {
                return this.RedirectToAction("Profile", "Users");
            }

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit/{id}")]
        public ActionResult Edit([Bind(Include = "Id,Make,Model,Price,Quantity,MinShutterSpeed,MaxShutterSpeed,MinIso,MaxIso,IsFullFrame,VideoResolution,LightMetering,Description,ImageUrl")] EditCameraBm camera)
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
            if (!this.authentication.IsAuthenticated(sessionId))
            {
                return this.RedirectToAction("Login", "Users");
            }

            if (ModelState.IsValid)
            {
                User user = this.authentication.GetAuthenticatedUser(sessionId);
                this.service.Edit(camera, user);
                return this.RedirectToAction("Profile", "Users");
            }

            EditCameraVm vm = Mapper.Map<EditCameraBm, EditCameraVm>(camera);
            return View(vm);
        }

         // GET: Cameras/Delete/5
        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
            if (!this.authentication.IsAuthenticated(sessionId))
            {
                return this.RedirectToAction("Login", "Users");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = this.authentication.GetAuthenticatedUser(sessionId);
            DeleteCameraVm vm = this.service.GetDeleteVm(id, user);
            if (vm == null)
            {
                return this.RedirectToAction("Profile", "Users");
            }

            return View(vm);
        }

        // POST: Cameras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
            if (!this.authentication.IsAuthenticated(sessionId))
            {
                return this.RedirectToAction("Login", "Users");
            }

            this.service.Delete(id);
            return this.RedirectToAction("Profile", "Users");
        }
    }
}