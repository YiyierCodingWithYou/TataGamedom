using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Infrastructure.TaTaGamedom_Persistence.Repositories;

public class OrderItemReturnRepository : GenericRepository<OrderItemReturn>, IOrderItemReturnRepository
{
    public OrderItemReturnRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}

