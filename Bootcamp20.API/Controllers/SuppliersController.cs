﻿using Bootcamp20.API.BussinessLogic.Interface;
using Bootcamp20.API.BussinessLogic.Interface.Master;
using Bootcamp20.API.DataAccess.Models;
using Bootcamp20.API.DataAccess.Params;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using System.Web.Script.Serialization;

namespace Bootcamp20.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SuppliersController : ApiController
    {
        ISuplierService _Supplier = new SupplierService();
        // GET: api/Suppliers   
        public SuppliersController() { }
        public SuppliersController(ISuplierService Supplier)
        {
            this._Supplier = Supplier;
        }
        [HttpGet]
        public System.Web.Http.Results.JsonResult<IEnumerable<SupplierParam>> Get()
        {
            //string name=null;
            IEnumerable<SupplierParam> list_param = _Supplier.Get().Select(x => new SupplierParam
            {
                Id=x.Id,
                CreateDate = Convert.ToDateTime(x.CreateDate),
                Name = x.Name.ToString(),
                IsDelete = Convert.ToBoolean(x.IsDelete)
            });
            return Json(list_param);
        }

        [HttpGet]
        public System.Web.Http.Results.JsonResult<IEnumerable<SupplierParam>> Get(int jns, string name)
        {            
            //string name=null;
            SupplierParam pencarian = new SupplierParam();
            pencarian.Name = name;
            pencarian.jenis_cari = jns;
            IEnumerable<SupplierParam> list_param = _Supplier.GetName(pencarian).Select(x => new SupplierParam
            {
                Id = x.Id,
                CreateDate=Convert.ToDateTime(x.CreateDate),
                Name = x.Name.ToString(),
                IsDelete = Convert.ToBoolean(x.IsDelete)
            });
            return Json(list_param);
        }

        // GET: api/Suppliers/5
        [HttpGet]
        public SupplierParam Get(int id)
        {
            SupplierParam supplierparam = new SupplierParam(_Supplier.Get(id));
            return supplierparam;
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