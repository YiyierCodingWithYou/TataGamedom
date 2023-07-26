using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TataGamedomWebAPI.Models.Dtos;
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
        /// <param name="dto"></param>
        /// <returns></returns>
        public string GetOrderIndex(OrderCreateDto dto) => string.Concat(dto.CreatedAt.ToString("yyyyMMdd"), dto.ShipmemtMethodId, dto.MemberId, _Id + 1);
	
	}