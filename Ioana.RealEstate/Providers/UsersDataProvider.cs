using Ioana.RealEstate.Data.EntityFramework;
using Ioana.RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;

namespace Ioana.RealEstate.Providers
{
    public class UsersDataProvider : IDataProvider<UserModel>
    {
        public async Task<UserModel[]> GetAll()
        {
            UserModel[] allUsers;
            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                allUsers = (await dbContext.Users.ToArrayAsync()).Select(u => new UserModel()
                    {
                        Id = u.Id,
                        FullName = string.Join(" ", u.FirstName, u.LastName)
                    }).OrderBy(u => u.FullName).ToArray();
            }

            return allUsers;
        }
    }
}