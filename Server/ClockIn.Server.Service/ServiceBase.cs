using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using System.Dynamic;
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

        public IEnumerable<dynamic> ExecuteSqlQuery(string cmdText, CommandType cmdType = CommandType.Text, params DbParameter[] parameters)
        {
            using (var cmd = this.Context.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = cmdText;
                cmd.CommandType = cmdType;
                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open(); //打开连接
                }
                //添加输入参数
                cmd.Parameters.AddRange(parameters);

                //执行命令，读取器读取数据
                using (var dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        IDictionary<string, object> row = new ExpandoObject(); //实例化一个动态可扩展对象
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            row.Add(dataReader.GetName(i), dataReader[i]);
                        }
                        yield return row;
                    }
                }
            }
        }

        public int ExecuteNonQuery(string cmdText, CommandType cmdType = CommandType.Text, params DbParameter[] parameters)
        {
            //1. 创建连接对象
            using (var cmd = this.Context.Database.GetDbConnection().CreateCommand())
            {
                //接下来把异常处理加入
                try
                {
                    cmd.CommandText = cmdText;
                    cmd.CommandType = cmdType;
                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open(); //打开连接
                    }
                    //处理输入参数
                    cmd.Parameters.AddRange(parameters);

                    //事务
                    //cmd.Transaction = tran; 

                    int result = cmd.ExecuteNonQuery();   //执行增删改命令
                    return result;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
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
