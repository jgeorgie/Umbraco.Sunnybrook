using SunnybrookMontessori.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace SunnybrookMontessori.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {
        public ActionResult ShowForm()
        {
            ContactModel myModel = new ContactModel();
            //myModel.Email=CurrentPage.GetProperty
            return PartialView("ContactForm", myModel);
        }
        public ActionResult HandleFormPost(ContactModel model)
        {
            var newComment = Services.ContentService.CreateContent(model.Name + " - " + DateTime.Now.ToString("dd-MM-yyyy HH:mm"), CurrentPage.Id, "contactUs");
            newComment.SetValue("emailForm", model.Email);
            newComment.SetValue("contactName", model.Name);
            newComment.SetValue("contactMessage", model.Message);
            Services.ContentService.SaveAndPublishWithStatus(newComment);
            return RedirectToCurrentUmbracoPage();
        }
    }
}