using Ioana.RealEstate.Data.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioana.RealEstate.Data.EntityFramework
{
    public class RealEstateRoleStore : RoleStore<RealEstateRole, int, RealEstateUserRole>
    {
        public RealEstateRoleStore(RealEstateDbContext context)
            : base(context)
        {
        }
    }
}
