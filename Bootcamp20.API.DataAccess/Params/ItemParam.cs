using Bootcamp20.API.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp20.API.DataAccess.Params
{
    public class ItemParam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool IsDelete { get; set; }
        public Supplier Supplier { get; set; } 
        public int Supplier_Id { get; set; }
        public string Supplier_Name { get; set; }
        public int jenis_cari { get; set; }
        public ItemParam() { }
        public ItemParam(Item item)
        {
            this.Id = item.Id;
            this.Name = item.Name;
            this.CreateDate = Convert.ToDateTime(item.CreateDate);
            this.UpdateDate = Convert.ToDateTime(item.UpdateDate);
            this.IsDelete = Convert.ToBoolean(item.IsDelete);
            this.Supplier_Id = item.Supplier.Id;
        }
    }
}
