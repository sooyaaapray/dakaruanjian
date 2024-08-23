using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Server.IService
{
    public interface IServiceBase
    {
        #region C
        T Insert<T>(T t) where T : class;//新增
        IEnumerable<T> Insert<T>(IEnumerable<T> list) where T : class;
        #endregion

        #region R
        T Find<T>(int id) where T : class;//id查实体
        IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class;
        #endregion

        #region U
        int Update<T>(T t) where T : class;
        int Update<T>(IEnumerable<T> list) where T : class;
        #endregion


        #region D
        int Delete<T>(int id) where T : class;//id删
        int Delete<T>(T t) where T : class;//t删
        int Delete<T>(IEnumerable<T> list) where T : class;

        #endregion
        int Commit();//保证事务
        #region other

        #endregion
    }
}
