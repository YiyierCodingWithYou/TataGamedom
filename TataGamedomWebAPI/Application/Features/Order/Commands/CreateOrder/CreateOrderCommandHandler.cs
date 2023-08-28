using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Exceptions;
using TataGamedomWebAPI.Models.Interfaces;

namespace TataGamedomWebAPI.Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IAppLogger<CreateOrderCommandHandler> _logger;
        private readonly IIndexGenerator _indexGenerator;

        public CreateOrderCommandHandler(
            IMapper mapper, 
            IOrderRepository orderRepository,
            IMemberRepository memberRepository,
            IAppLogger<CreateOrderCommandHandler> logger,
            IIndexGenerator indexGenerator)
        {
            this._mapper = mapper;
            this._orderRepository = orderRepository;
            this._memberRepository = memberRepository;
            this._logger = logger;
            this._indexGenerator = indexGenerator;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            Models.EFModels.Order orderTobeCreated = _mapper.Map<Models.EFModels.Order>(request);
            
            await GenerateIndex(request, orderTobeCreated);

            await _orderRepository.CreateAsync(orderTobeCreated);

            _logger.LogInformation("Created successfully");

            return orderTobeCreated.Id;
        }

        private async Task ValidateRequest(CreateOrderCommand request)
        {
            var validator = new CreateOrderCommandValidator(_memberRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid order request", validationResult);
            }
        }
        private async Task GenerateIndex(CreateOrderCommand request, Models.EFModels.Order orderTobeCreated)
        {
            int maxOrderId = await _orderRepository.GetMaxId();
            orderTobeCreated.Index = _indexGenerator.GetOrderIndex(orderTobeCreated, maxOrderId);
        }
    }
}
