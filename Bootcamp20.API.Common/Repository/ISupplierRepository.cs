using Bootcamp20.API.DataAccess.Models;
using Bootcamp20.API.DataAccess.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp20.API.Common.Repository
{
    public interface ISupplierRepository
    {
        List<Supplier> Get();
        List<Supplier> GetName(SupplierParam _supplierparam);
        Supplier Get(int? id);
        bool Insert(SupplierParam _supplierparam);
        bool Update(SupplierParam _supplierparam);
        bool Delete(int? id);
    }
}
