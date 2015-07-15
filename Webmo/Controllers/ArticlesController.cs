using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Webmo.Data.DAL;
using Webmo.Data.Repositories;
using Webmo.Data.Models;
using System.Xml;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace Webmo.Controllers
{
    public class ArticlesController : Controller
    {
        private IArticleRepository repo = new ArticleRepository(new Data.DAL.WebmoContext());

        // GET: Articles
        public ActionResult Index(int? id)
        {
            return View(repo.GetAll());
        }

        public JsonResult GetList()
        {
            return Json(repo.GetAll(), JsonRequestBehavior.AllowGet);
        }

        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = repo.Find(id.Value);
            if (article == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
            {
                return Json(article, JsonRequestBehavior.AllowGet);
            }

            return View(article);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "ID,Posted,Updatd,Title,Content")]*/ Article article)
        {
            if (ModelState.IsValid)
            {
                repo.Insert(article);
                repo.Save();
                return RedirectToAction("Index");
            }

            return View(article);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = repo.Find(id.Value);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Posted,Updatd,Title,Content")] Article article)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.Edit(article);
                    repo.Save();

                    if(Request.IsAjaxRequest())
                    {
                        var a = repo.Find(article.ID);
                        return Json(a);
                    }

                    return RedirectToAction("Index");
                }
            }
            catch(Exception e)
            {
                Response.StatusCode = 400;
                if(Request.IsAjaxRequest())
                {
                    return Json(new{Status = 400, Success=false});
                }
                return RedirectToAction("Error", new {from = "edit"});
            }

            return RedirectToAction("Index");
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = repo.Find(id.Value);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = repo.Find(id);
            repo.Remove(article);
            repo.Save();

            if(Request.IsAjaxRequest())
            {
                return Json(article);
            }

            return RedirectToAction("Index");
        }

    }
}
