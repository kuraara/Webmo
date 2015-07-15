using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webmo.Data.Models;

namespace Webmo.Data.Repositories
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetAll();
        Article Find(int id);
        IEnumerable<Article> Where(Func<Article, bool> predicate);
        int Count(Func<Article, bool> predicate);
        void Insert(Article item);
        void Remove(Article item);
        int Save();
        void Edit(Article item);
    }
}
