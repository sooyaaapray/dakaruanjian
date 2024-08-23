using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClockIn.Server.Service
{
    public class ServiceBase : IService.IServiceBase
    {
        protected DbContext Context { get; set; }
        public ServiceBase(IEFContext.IEFContext eFContext)
        {
            Context = eFContext.CreateDBContext();
        }
        public int Commit()
        {
            return this.Context.SaveChanges();
        }

        public int Delete<T>(int id) where T : class
        {
            T t = this.Find<T>(id);
            if (t == null) throw new Exception("not exisits");
            this.Context.Set<T>().Remove(t);
            return this.Commit();
        }

        public int Delete<T>(T t) where T : class
        {
            if (t == null) throw new Exception("not exisits");
            this.Context.Set<T>().Attach(t);
            this.Context.Set<T>().Remove(t);
            return this.Commit();
        }

        public int Delete<T>(IEnumerable<T> list) where T : class
        {
            foreach (var t in list) {
                this.Context.Set<T>().Attach(t);
            }
            this.Context.Set<T>().RemoveRange(list);
            return this.Commit();
        }

        public T Find<T>(int id) where T : class
        {
            return this.Context.Set<T>().Find(id);
        }

        public T Insert<T>(T t) where T : class
        {
            this.Context.Set<T>().Add(t);
            this.Commit();
            return t;
        }

        public IEnumerable<T> Insert<T>(IEnumerable<T> list) where T : class
        {
            this.Context.Set<T>().AddRange(list);
            this.Commit();
            return list;
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class
        {
            return this.Context.Set<T>().Where <T>(funcWhere);
        }

        public int Update<T>(T t) where T : class
        {
            if (t == null) throw new Exception("not exisits");
            this.Context.Set<T>().Attach(t);
            this.Context.Entry<T>(t).State = EntityState.Modified;
            return this.Commit();
        }

        public int Update<T>(IEnumerable<T> list) where T : class
        {
            foreach (var t in list) {
                this.Context.Set<T>().Attach(t);
                this.Context.Entry<T>(t).State = EntityState.Modified;
            }
            return this.Commit();
        }

        public virtual void Dispose() 
        {
            if (this.Context != null) 
            {
                this.Context.Dispose();
                this.Context = null;
            }
        }
    }
}
