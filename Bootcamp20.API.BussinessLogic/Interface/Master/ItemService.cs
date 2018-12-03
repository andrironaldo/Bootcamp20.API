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
    public class ItemService : IItemService
    {
        private readonly IItemRepository _iitemrepository;
        public ItemService() { }
        public ItemService(IItemRepository iitemrepository)
        {
            this._iitemrepository = iitemrepository;
        }
        public bool Delete(int? id)
        {
            return _iitemrepository.Delete(id);
        }

        public List<Item> Get()
        {
            return _iitemrepository.Get();
        }
        public List<Item> GetName(ItemParam _itemparam)
        {
            return _iitemrepository.GetName(_itemparam);
        }

        public Item Get(int? id)
        {
            return _iitemrepository.Get(id);
        }

        public bool Insert(ItemParam _itemparam)
        {
            return _iitemrepository.Insert(_itemparam);
        }

        public bool Update(ItemParam _itemparam)
        {
            return _iitemrepository.Update(_itemparam);
        }
    }
}
