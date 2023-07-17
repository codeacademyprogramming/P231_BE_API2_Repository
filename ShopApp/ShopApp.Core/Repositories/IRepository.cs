using ShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Core.Repositories
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);
        IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> exp, params string[] includes);
        TEntity Get(Expression<Func<TEntity, bool>> exp,params string[] includes);
        bool IsExist(Expression<Func<TEntity, bool>> exp, params string[] includes);
        void Remove(TEntity entity);
        int Commit();
    }
}
