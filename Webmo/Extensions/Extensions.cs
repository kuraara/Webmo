using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using Webmo.Data.Models;
using MarkdownSharp;

namespace Webmo.Extensions
{
    public static class Extensions
    {
        public static string Preview(this Article a) 
        {
            int n = a.Content.Length < 160 ? a.Content.Length : 160;
            return a.Content.Substring(0, n);
        }

        public static MvcHtmlString ProcessMarkDown(this Article a)
        {
            Markdown md = new Markdown();
            return MvcHtmlString.Create(md.Transform(a.Content));
        }
    }
}