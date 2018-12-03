using Bootcamp20.API.DataAccess.Models;
using Bootcamp20.API.DataAccess.Params;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp20.API.Common.Repository.Master
{
    public class ItemRepository:IItemRepository
    {
        MyContext _context = new MyContext();
        int status = 0;
        public bool Delete(int? id)
        {
            var getItem = _context.Items.Find(id);
            getItem.IsDelete = true;
            _context.Entry(getItem).State = EntityState.Modified;
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

        public List<Item> Get()
        {
            return _context.Items.Include("Supplier").ToList();
        }
        public List<Item> GetName(ItemParam _itemparam)
        {
            if (_itemparam.jenis_cari == 1)
            {
                return _context.Items.Include("Supplier").Where(x => x.Name.Contains(_itemparam.Name)).ToList();
            }
            else if (_itemparam.jenis_cari == 2)
            {
                var hasil=_context.Items.Include("Supplier").Where(x => x.Supplier.Name.Contains(_itemparam.Name)).ToList();
                return hasil;
            }
            else if (_itemparam.jenis_cari == 3)
            {
                return _context.Items.Include("Supplier").Where(x => x.Name.Contains(_itemparam.Name)).ToList();
            }
            else
            {
                return _context.Items.Where(x => x.Name.Contains(_itemparam.Name)).ToList();
            }
        }

        public Item Get(int? id)
        {
            return _context.Items.SingleOrDefault(x => x.Id == id);
        }

        public bool Insert(ItemParam _itemparam)
        {
            _itemparam.Supplier = _context.Suppliers.Find(_itemparam.Supplier_Id);
            Item setItem = new Item(_itemparam);            
            _context.Items.Add(setItem);
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

        public bool Update(ItemParam _itemparam)
        {
            _itemparam.Supplier = _context.Suppliers.Find(_itemparam.Supplier_Id);
            Item getItem = Get(_itemparam.Id);
            getItem.Update(_itemparam);
            _context.Entry(getItem).State = EntityState.Modified;
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
