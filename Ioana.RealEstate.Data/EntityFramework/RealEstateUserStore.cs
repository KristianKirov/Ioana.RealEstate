using Ioana.RealEstate.Data.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioana.RealEstate.Data.EntityFramework
{
    public class RealEstateUserStore : UserStore<RealEstateUser, RealEstateRole, int,
        RealEstateUserLogin, RealEstateUserRole, RealEstateUserClaim>
    {
        public RealEstateUserStore(RealEstateDbContext context)
            : base(context)
        {
        }
    }
}
