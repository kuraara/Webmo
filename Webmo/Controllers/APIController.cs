using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.IO;
using System.Reflection;

using MarkdownSharp;

namespace Webmo.Controllers
{
    public class APIController : Controller
    {
        
        /// <summary>
        /// The summary listing of all the API functions
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            return View();
        }

        public JsonResult mdToHtml(string text)
        {
           
            Markdown md = new Markdown();
            string h = md.Transform(text);

            return Json(new {Original=text, Result=h });
        }
    }
}
