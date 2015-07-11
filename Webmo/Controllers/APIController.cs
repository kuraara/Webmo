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
    }
}
