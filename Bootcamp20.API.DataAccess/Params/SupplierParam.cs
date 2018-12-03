using Bootcamp20.API.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp20.API.DataAccess.Params
{
    public class SupplierParam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool IsDelete { get; set; }
        public int jenis_cari { get; set; }
        public SupplierParam() { }
        public SupplierParam(Supplier supplier)
        {
            this.Id = supplier.Id;
            this.Name = supplier.Name;
            this.CreateDate = Convert.ToDateTime(supplier.CreateDate);
            this.UpdateDate = Convert.ToDateTime(supplier.UpdateDate);
            this.IsDelete = Convert.ToBoolean(supplier.IsDelete);
        }
    }
}
