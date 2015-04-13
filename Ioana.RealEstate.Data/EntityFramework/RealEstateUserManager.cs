using Ioana.RealEstate.Data.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioana.RealEstate.Data.EntityFramework
{
    public class RealEstateUserManager : UserManager<RealEstateUser, int>
    {
        public RealEstateUserManager(IUserStore<RealEstateUser, int> store)
            : base(store)
        {
            ((UserValidator<RealEstateUser, int>)this.UserValidator).AllowOnlyAlphanumericUserNames = false;
        }
    }
}
