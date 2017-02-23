 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using HNCJ.DY.Model;

using System.Linq.Expressions;
using System.Data;

namespace HNCJ.DY.DAL
{
    public class BaseDal<T> where T:class,new ()
    {
        //DataModelContainer db = new DataModelContainer();
        public DbContext db { get { return DbContextFactory.GetCurrentDbContext(); } }

        #region 查询方法
        public IQueryable<T> GetEntity(Expression<Func<T, bool>> whereLambda)
        {
            return db.Set<T>().Where(whereLambda).AsQueryable();
        }
        #endregion

        #region 分页查询
        public IQueryable<T> GetPageEntity<S>(int pagesize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, bool isAsc)
        {
            total = db.Set<T>().Where(whereLambda).Count();
            if (isAsc)
            {
                return db.Set<T>().Where(whereLambda).OrderBy(orderbyLambda).Skip(pagesize * (pageIndex - 1)).Take(pagesize).AsQueryable();
            }
            else
            {
                return db.Set<T>().Where(whereLambda).OrderByDescending(orderbyLambda).Skip(pagesize * (pageIndex - 1)).Take(pagesize).AsQueryable();
            }

        }  
        #endregion
        
        #region 添加方法
            public T Add(T entity) {
                db.Set<T>().Add(entity);
                return entity;
            }
        #endregion

        #region 修改方法
        public bool Update(T entity) {
            db.Entry(entity).State = EntityState.Modified;
            return true;
        }

        #endregion

        #region 删除方法
        public bool Delete(T entity)
        {
            db.Entry(entity).State = EntityState.Deleted;
            return true;
        }
        public bool Delete(int id) {
            var entity = db.Set<T>().Find(id);
            db.Set<T>().Remove(entity);
            return true;
        }
        
        #endregion

        #region 批量删除之软删除
        public int DeleteListByLogical(List<int> ids)
        {
            foreach (var id in ids)
            {
                var entity = db.Set<T>().Find(id);
                db.Entry(entity).Property("DelFlag").CurrentValue = false;
                db.Entry(entity).Property("DelFlag").IsModified = true;

            }
            return ids.Count;
        } 
        #endregion
        public int AlterListStatus(List<int> ids)
        {
            foreach (var id in ids)
            {
                var entity = db.Set<T>().Find(id);
               var obj=db.Entry(entity).Property("Status").CurrentValue;
               int i = int.Parse(obj.ToString());
               i = (i + 1) % 2;
               db.Entry(entity).Property("Status").CurrentValue = (short)i;
                db.Entry(entity).Property("Status").IsModified = true;

            }
            return ids.Count;
        } 
    }
}
