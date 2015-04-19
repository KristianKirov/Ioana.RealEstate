using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioana.RealEstate.Providers
{
    public interface IDataProvider<TModel>
    {
        Task<TModel[]> GetAll();

        Task<TModel> GetById(int id);

        Task<TModel[]> GetByIds(params int[] ids);
    }
}
