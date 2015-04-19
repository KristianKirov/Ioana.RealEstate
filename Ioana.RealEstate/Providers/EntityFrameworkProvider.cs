using Ioana.RealEstate.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using Ioana.RealEstate.Data.Model;

namespace Ioana.RealEstate.Providers
{
    public abstract class EntityFrameworkProvider<TModel, TEntity> : IDataProvider<TModel> where TEntity : class, IEntity
    {
        protected abstract TModel BuildModel(TEntity entity);

        protected abstract IQueryable<TEntity> GetQuery(RealEstateDbContext dbContext);

        public async Task<TModel[]> GetAll()
        {
            TModel[] allModels;
            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                TEntity[] allEntities = await this.GetQuery(dbContext).ToArrayAsync();
                allModels = allEntities.Select(e => this.BuildModel(e)).ToArray();
            }

            return allModels;
        }

        public async Task<TModel> GetById(int id)
        {
            TModel model;
            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                TEntity entity = await this.GetQuery(dbContext).FirstOrDefaultAsync(ot => ot.Id == id);
                if (entity == null)
                {
                    return default(TModel);
                }

                model = this.BuildModel(entity);
            }

            return model;
        }

        public async Task<TModel[]> GetByIds(params int[] ids)
        {
            TModel[] allModels;
            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                TEntity[] allEntities = await this.GetQuery(dbContext).Where(e => ids.Contains(e.Id)).ToArrayAsync();
                allModels = allEntities.Select(e => this.BuildModel(e)).ToArray();
            }

            return allModels;
        }
    }
}