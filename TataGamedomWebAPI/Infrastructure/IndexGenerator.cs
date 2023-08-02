using System;
using TataGamedomWebAPI.Models.EFModels;
using TataGamedomWebAPI.Models.Interfaces;

namespace TataGamedom.Infrastructure;

public class IndexGenerator : IIndexGenerator
{
    private int _Id;
    public IndexGenerator(int id)
    {
        _Id = id;
    }
     
    /// <summary>
    /// "命名規則: CreatedAt+ ShipmentMethodId + MemberId + Id"
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    public string GetOrderIndex(Order order) => string.Concat(order.CreatedAt.ToString("yyyyMMdd"), order.ShipmemtMethodId, order.MemberId, _Id + 1);
	
}