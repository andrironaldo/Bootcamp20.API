using Bootcamp20.API.BussinessLogic.Interface;
using Bootcamp20.API.BussinessLogic.Interface.Master;
using Bootcamp20.API.DataAccess.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Bootcamp20.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ItemsController : ApiController
    {
        IItemService _Item = new ItemService();
        ISuplierService _Supplier = new SupplierService();
        // GET: api/Suppliers   
        public ItemsController() { }
        public ItemsController(IItemService Item, ISuplierService Supplier)
        {
            this._Item = Item;
            this._Supplier = Supplier;
        }
        [HttpGet]
        public System.Web.Http.Results.JsonResult<IEnumerable<ItemParam>> Get()
        {
            IEnumerable<ItemParam> list_param = _Item.Get().Select(x => new ItemParam
            {
                Id = x.Id,
                Name = x.Name.ToString(),
                Stock = Convert.ToInt16(x.Stock),
                Price = Convert.ToDecimal(x.Price),
                CreateDate = Convert.ToDateTime(x.CreateDate),
                Supplier_Name =x.Supplier.Name,
                IsDelete = Convert.ToBoolean(x.IsDelete)
            });
            return Json(list_param);
        }

        [HttpGet]
        public System.Web.Http.Results.JsonResult<IEnumerable<ItemParam>> Get(int jns,string name)
        {
            ItemParam pencarian = new ItemParam();
            pencarian.Name = name;
            pencarian.jenis_cari = jns;
            IEnumerable<ItemParam> list_param = _Item.GetName(pencarian).Select(x => new ItemParam
            {
                Id = x.Id,
                Name = x.Name,
                Stock = Convert.ToInt16(x.Stock),
                Price = Convert.ToDecimal(x.Price),
                CreateDate =Convert.ToDateTime(x.CreateDate),
                Supplier_Name = x.Supplier.Name,
                IsDelete = Convert.ToBoolean(x.IsDelete)
            });
            return Json(list_param);
        }

        // GET: api/Suppliers/5
        [HttpGet]
        public ItemParam Get(int id)
        {
            ItemParam itemparam = new ItemParam(_Item.Get(id));
            return itemparam;
        }
        
        // POST: api/Suppliers
        [HttpPost]
        public void Post(ItemParam itemparam)
        {
            _Item.Insert(itemparam);
        }

        // PUT: api/Suppliers/5
        [HttpPut]
        //public void Put(int id, Supplier supplier)//Nama Bebas, tapi buat httpPut
        public void Put(ItemParam itemparam)
        {
            _Item.Update(itemparam);
        }

        // DELETE: api/Suppliers/5
        [HttpDelete]
        public void Delete(int id)
        {
            _Item.Delete(id);
        }
    }
}
