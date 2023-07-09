using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TataGamedom.Controllers;
using TataGamedom.Models.Dtos.InventoryItems;
using TataGamedom.Models.ViewModels.InventoryItems;

namespace TataGamedom.Models.Interfaces
{
    public interface IInventoryRepository
    {
        IEnumerable<InventoryVM> Search();

        IEnumerable<InventoryItemVM> Info(int? productId, InventoryCriteria criteria);

		int GetMaxIdInDb();

		void Create(InventoryItemCreateDto dto);

		string GetProductIndex(int productId);

		void Update(InventoryItemDto dto);

		InventoryItemDto GetByIndex(string index);

		int bulkCreate();
        InventoryItemDto GetById(int? id);
    }
}