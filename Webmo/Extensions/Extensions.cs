using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using Webmo.Data.Models;
using MarkdownSharp;
using System;

namespace Webmo.Extensions
{
    public static class Extensions
    {
        public static string Preview(this Article a) 
        {
            int n = a.Content.Length < 160 ? a.Content.Length : 160;
            return a.Content.Substring(0, n);
        }

        public static MvcHtmlString RawActionLink(this HtmlHelper htmlHelper, string rawHtml, string action, string controller, object routeValues, object htmlAttributes)
        {
            //string anchor = htmlHelper.ActionLink("##holder##", action, controller, routeValues, htmlAttributes).ToString();
            //return MvcHtmlString.Create(anchor.Replace("##holder##", rawHtml));
            /* Updated code to use a generated guid as from the suggestion of Phillip Haydon */
            string holder = Guid.NewGuid().ToString();
            string anchor = htmlHelper.ActionLink(holder, action, controller, routeValues, htmlAttributes).ToString();
            return MvcHtmlString.Create(anchor.Replace(holder, rawHtml));
        }

        public static MvcHtmlString ProcessMarkDown(this Article a)
        {
            Markdown md = new Markdown();
            return MvcHtmlString.Create(md.Transform(a.Content));
        }
    }
}