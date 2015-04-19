using Ioana.RealEstate.Data.EntityFramework;
using Ioana.RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;
using Ioana.RealEstate.Data.Model;

namespace Ioana.RealEstate.Providers
{
    public class UsersDataProvider : EntityFrameworkProvider<UserModel, RealEstateUser>
    {
        protected override UserModel BuildModel(RealEstateUser entity)
        {
            return new UserModel()
            {
                Id = entity.Id,
                FullName = string.Join(" ", entity.FirstName, entity.LastName)
            };
        }

        protected override IQueryable<RealEstateUser> GetQuery(RealEstateDbContext dbContext)
        {
            return dbContext.Users;
        }
    }
}