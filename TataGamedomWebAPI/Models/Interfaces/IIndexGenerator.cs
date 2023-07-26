using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Models.Interfaces;

public interface IIndexGenerator
{
    string GetOrderIndex(Order dto);
}
