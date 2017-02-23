using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HNCJ.DY.IDAL
{
   public interface IBaseDal<T> where T:class ,new ()
    {

         IQueryable<T> GetEntity(Expression<Func<T, bool>> whereLambda);//条件查询方法
         IQueryable<T> GetPageEntity<S>(int pagesize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, bool isAsc);//分页条件查询
         T Add(T entity);//添加方法
         bool Update(T entity);//修改方法
         bool Delete(T entity);//删除方法
         bool Delete(int id);
         int DeleteListByLogical(List<int> ids);
         int AlterListStatus(List<int> ids);
    }
}
