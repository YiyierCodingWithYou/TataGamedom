using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TataGamedom.Models.Dtos.Orders;
using TataGamedom.Models.EFModels;

namespace TataGamedom.Models.Interfaces
{


	public interface IIndexGenerator
	{
		string GetOrderIndex(OrderDto dto);
	}

}
