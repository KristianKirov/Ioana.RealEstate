using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioana.RealEstate.Data.EntityFramework.Extensions
{
    public static class EntityExtender
    {
        public static TEntity AsExisting<TEntity>(this TEntity entity, DbContext context) where TEntity : class
        {
            context.Entry<TEntity>(entity).State = EntityState.Unchanged;

            return entity;
        }
    }
}
