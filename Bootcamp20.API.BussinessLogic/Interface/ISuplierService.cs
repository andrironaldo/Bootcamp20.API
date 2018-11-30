using Bootcamp20.API.DataAccess.Models;
using Bootcamp20.API.DataAccess.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp20.API.BussinessLogic.Interface
{
    public interface ISuplierService
    {
        List<Supplier> Get();
        List<Supplier> GetName(string name);
        Supplier Get(int? id);
        bool Insert(SupplierParam _supplierparam);
        bool Update(SupplierParam _supplierparam);
        bool Delete(int? id);
    }
}
