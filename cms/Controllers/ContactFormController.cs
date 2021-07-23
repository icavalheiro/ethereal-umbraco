using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace ethereal
{
    public class ContactFormController : Controller
    {
        public class ContactFormData
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Message { get; set; }
        }

        private readonly IUmbracoContext Umbraco;
        private readonly IContentService ContentService;

        public ContactFormController(IUmbracoContextAccessor umbracoContextAccessor, IContentService contentService)
        {
            Umbraco = umbracoContextAccessor.UmbracoContext;
            ContentService = contentService;
        }

        [HttpPost("/contact-form")]
        public IActionResult HandlePost([FromForm] ContactFormData data)
        {
            var parent = Umbraco.Content.GetAtRoot().Where(x => x.ContentType.Alias == "contactForms").FirstOrDefault();
            if (parent == null)
            {
                throw new System.Exception("There's no \"Contact Forms\" node at the root to be used to save new contact entries");
            }

            var entry = ContentService.Create(data.Name + ": " + DateTime.Now.ToShortDateString(), parent.Key, "contactFormEntry");
            entry.SetValue("personName", data.Name);
            entry.SetValue("email", data.Email);
            entry.SetValue("message", data.Message);

            ContentService.SaveAndPublish(entry);

            return Ok();
        }
    }
}
