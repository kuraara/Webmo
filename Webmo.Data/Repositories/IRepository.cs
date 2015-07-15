using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webmo.Data.Models;

namespace Webmo.Data.Repositories
{
    interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Find(int id);
        IEnumerable<T> Where(Func<T, bool> predicate);
        int Count(Func<T, bool> predicate);
        void Insert(T item);
        int Save();
        void Update(T item);
    }
}
