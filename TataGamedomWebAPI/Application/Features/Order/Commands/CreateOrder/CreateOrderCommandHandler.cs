using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IApperLogger<CreateOrderCommandHandler> _logger;

        public CreateOrderCommandHandler(
            IMapper mapper, 
            IOrderRepository orderRepository, 
            IApperLogger<CreateOrderCommandHandler> logger)
        {
            this._mapper = mapper;
            this._orderRepository = orderRepository;
            this._logger = logger;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderTobeCreated = _mapper.Map<Models.EFModels.Order>(request);
            await _orderRepository.CreateAsync(orderTobeCreated);

            _logger.LogInformation("Created successfully");

            return orderTobeCreated.Id;
        }
    }
}
