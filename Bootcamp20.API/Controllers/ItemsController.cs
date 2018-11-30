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
                Supplier=x.Supplier,
                IsDelete = Convert.ToBoolean(x.IsDelete)
            });
            return Json(list_param);
        }

        [HttpGet]
        public System.Web.Http.Results.JsonResult<IEnumerable<ItemParam>> Get(string name)
        {
            IEnumerable<ItemParam> list_param = _Item.GetName(name).Select(x => new ItemParam
            {
                Id = x.Id,
                Name = x.Name.ToString(),
                Supplier=x.Supplier,
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
        public void Post(SupplierParam supplierparam)
        {
            _Supplier.Insert(supplierparam);
        }

        // PUT: api/Suppliers/5
        [HttpPut]
        //public void Put(int id, Supplier supplier)//Nama Bebas, tapi buat httpPut
        public void Put(SupplierParam supplierparam)
        {
            _Supplier.Update(supplierparam);
        }

        // DELETE: api/Suppliers/5
        [HttpDelete]
        public void Delete(int id)
        {
            _Supplier.Delete(id);
        }
    }
}
