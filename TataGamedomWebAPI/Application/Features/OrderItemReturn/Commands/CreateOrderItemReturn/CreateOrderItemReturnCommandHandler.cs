using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Exceptions;
using TataGamedomWebAPI.Models.Interfaces;

namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.CreateOrderItemReturn;

public class CreateOrderItemReturnCommandHandler : IRequestHandler<CreateOrderItemReturnCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IOrderItemReturnRepository _orderItemReturnRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IAppLogger<CreateOrderItemReturnCommandHandler> _logger;
    private readonly IIndexGenerator _indexGenerator;

    public CreateOrderItemReturnCommandHandler(
        IMapper mapper,
        IOrderItemReturnRepository orderItemReturnRepository,
        IOrderItemRepository orderItemRepository,
        IAppLogger<CreateOrderItemReturnCommandHandler> logger,
        IIndexGenerator indexGenerator)
    {
        this._mapper = mapper;
        this._orderItemReturnRepository = orderItemReturnRepository;
        this._orderItemRepository = orderItemRepository;
        this._logger = logger;
        this._indexGenerator = indexGenerator;
    }

    public async Task<int> Handle(CreateOrderItemReturnCommand request, CancellationToken cancellationToken)
    {
        await ValidateRequest(request, cancellationToken);

        Models.EFModels.OrderItemReturn orderItemReturnToBeCreated = _mapper.Map<Models.EFModels.OrderItemReturn>(request);

        await GenerateIndex(request, orderItemReturnToBeCreated);

        await _orderItemReturnRepository.CreateAsync(orderItemReturnToBeCreated);

        return orderItemReturnToBeCreated.Id;
    }

    private async Task ValidateRequest(CreateOrderItemReturnCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateOrderItemReturnCommandValidator(_orderItemRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid orderItemReturn Request");
        }
    }

    private async Task GenerateIndex(CreateOrderItemReturnCommand request, Models.EFModels.OrderItemReturn orderItemReturnToBeCreated)
    {
        string orderIndex = await _orderItemRepository.GetOrderIndexById(request.OrderItemId);
        int maxOrderItemReturnId = await _orderItemReturnRepository.GetMaxId();
        orderItemReturnToBeCreated.Index = _indexGenerator.GetOrderItemReturnIndex(orderItemReturnToBeCreated, orderIndex, maxOrderItemReturnId);
    }
}
