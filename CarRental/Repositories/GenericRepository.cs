using CarRental.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRental.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        Context context = new Context();

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? context.Set<T>().ToList() : context.Set<T>().Where(filter).ToList();
        }

        public void TAdd(T t)
        {
            context.Set<T>().Add(t);
            context.SaveChanges();
        }

        public void TDelete(T t)
        {
            context.Set<T>().Remove(t);
            context.SaveChanges();
        }
        public void TUpdate(T t)
        {
            context.Set<T>().Update(t);
            context.SaveChanges();
        }

        public T TGet(int id)
        {
            return context.Set<T>().SingleOrDefault();
        }
        //public T TGet(Expression<Func<T, bool>> filter)
        //{
        //    return context.Set<T>().SingleOrDefault(filter);
        //}

        public List<T> TList(string p)
        {
            return context.Set<T>().Include(p).ToList();
        }
    }
}
