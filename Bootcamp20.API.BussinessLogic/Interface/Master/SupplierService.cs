using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp20.API.DataAccess.Models;
using Bootcamp20.API.DataAccess.Params;
using Bootcamp20.API.Common.Repository;

namespace Bootcamp20.API.BussinessLogic.Interface.Master
{    
    public class SupplierService : ISuplierService
    {
        private readonly ISupplierRepository _isupplierrepository;
        public SupplierService() { }
        public SupplierService(ISupplierRepository isupplierrepository)
        {
            this._isupplierrepository = isupplierrepository;
        }
        public bool Delete(int? id)
        {
            return _isupplierrepository.Delete(id);
        }

        public List<Supplier> Get()
        {
            return _isupplierrepository.Get();
        }
        public List<Supplier> GetName(string name)
        {
            return _isupplierrepository.GetName(name);
        }

        public Supplier Get(int? id)
        {
            return _isupplierrepository.Get(id);
        }

        public bool Insert(SupplierParam _supplierparam)
        {
            return _isupplierrepository.Insert(_supplierparam);
        }

        public bool Update(SupplierParam _supplierparam)
        {
            return _isupplierrepository.Update(_supplierparam);
        }
    }
}
