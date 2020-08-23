namespace AssessmentApp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AssessmentApp.Data.Models;
    using AssessmentApp.Services.Data;
    using AssessmentApp.Services.Messaging;
    using AssessmentApp.Web.ViewModels.TtPictures;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "EmailSenders")]
    public class TtPicturesController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly INewEmailSender newEmailSender;
        private readonly ITtPicturesServices picturesServices;

        public TtPicturesController(UserManager<ApplicationUser> userManager, INewEmailSender newEmailSender, ITtPicturesServices picturesServices)
        {
            this.userManager = userManager;
            this.newEmailSender = newEmailSender;
            this.picturesServices = picturesServices;
        }

        public async Task<IActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var model = new TtPicturesInputViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                Emails = this.picturesServices.GetAll<EmailsDropDownViewModel>(),
            };
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(TtPicturesInputViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                if (input.Emails is null || !input.Emails.Any())
                {
                    input.Emails = this.picturesServices.GetAll<EmailsDropDownViewModel>();
                }

                return this.View(input);
            }

            var mailList = new List<string>();
            foreach (var mail in input.EmailsList)
            {
                if (mail.Contains(','))
                {
                    var tmpList = mail.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
                    mailList.AddRange(tmpList);
                }
                else
                {
                    mailList.Add(mail);
                }
            }

            input.Content ??= string.Empty;

            var message = new Message(input.Email, mailList, $"Pictures from {input.UserName}", input.Content, input.Pictures);

            // var message = new Message(new string[] { "warnings@ff-bg.net" }, "Test email async", "This is the content from our async email.", input.Pictures);
            await this.newEmailSender.SendEmailAsync(message);

            this.TempData["InfoMessage"] = "Съобщението беше изпратено !";

            return this.Redirect("/TtPictures");
        }
    }
}
