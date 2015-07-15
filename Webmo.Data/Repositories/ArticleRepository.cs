using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webmo.Data.Models;
using Webmo.Data.DAL;

namespace Webmo.Data.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private WebmoContext context;

        public ArticleRepository(WebmoContext _context)
        {
            this.context = _context;
        }


        public IEnumerable<Article> GetAll()
        {
            return context.Articles.ToList();
        }

        public Article Find(int id)
        {
            return context.Articles.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<Article> Where(Func<Article, bool> predicate)
        {
            return context.Articles.Where(predicate);
        }

        public int Count(Func<Article, bool> predicate)
        {
            return context.Articles.Count(predicate);
        }

        public void Insert(Article item)
        {
            item.Posted = DateTime.Now;
            item.Updated = DateTime.Now;
            context.Articles.Add(item);
        }

        public void Remove(Article item)
        {
            var a = this.Find(item.ID);
            context.Articles.Remove(a);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Edit(Article item)
        {
            var existing = this.Find(item.ID);
            if (existing == null)
            {
                return;
            }
            var entry = context.Entry(existing);
            entry.CurrentValues.SetValues(item);

        }

        public void Dipose()
        {
            context.Dispose();
        }

        // To Mock out in testing
        private System.Data.Entity.Infrastructure.DbEntityEntry GetEntry(Article existing)
        {
            return context.Entry(existing);
        }
    }
}
