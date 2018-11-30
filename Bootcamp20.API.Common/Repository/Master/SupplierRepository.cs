using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp20.API.DataAccess.Models;
using Bootcamp20.API.DataAccess.Params;
using System.Data.Entity;

namespace Bootcamp20.API.Common.Repository.Master
{
    public class SupplierRepository : ISupplierRepository
    {
        MyContext _context = new MyContext();
        int status = 0;
        public bool Delete(int? id)
        {
            var getSupplier=_context.Suppliers.Find(id);
            getSupplier.IsDelete = true;
            _context.Entry(getSupplier).State = EntityState.Modified;
            status = _context.SaveChanges();
            if (status > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Supplier> Get()
        {
            return _context.Suppliers.ToList();
        }
        public List<Supplier> GetName(string name)
        {
            return _context.Suppliers.Where(x => x.Name.Contains(name)).ToList();
        }

        public Supplier Get(int? id)
        {
            return _context.Suppliers.SingleOrDefault(x => x.Id==id);
        }

        public bool Insert(SupplierParam _supplierparam)
        {
            Supplier setSupplier = new Supplier(_supplierparam);
            _context.Suppliers.Add(setSupplier);
            status = _context.SaveChanges();
            if (status > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(SupplierParam _supplierparam)
        {
            Supplier getSupplier = Get(_supplierparam.Id);
            getSupplier.Update(_supplierparam);
            _context.Entry(getSupplier).State = EntityState.Modified;
            status = _context.SaveChanges();
            if (status > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
