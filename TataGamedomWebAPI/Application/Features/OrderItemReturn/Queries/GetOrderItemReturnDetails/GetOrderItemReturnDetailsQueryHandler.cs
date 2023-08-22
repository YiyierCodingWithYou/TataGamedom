using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;

namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Queries.GetOrderItemReturnDetails;

public class GetOrderItemReturnDetailsQueryHandler : IRequestHandler<GetOrderItemReturnDetailsQuery, OrderItemReturnDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IOrderItemReturnRepository _orderItemReturnRepository;
    private readonly IAppLogger<GetOrderItemReturnDetailsQueryHandler> _logger;

    public GetOrderItemReturnDetailsQueryHandler(
        IMapper mapper,
        IOrderItemReturnRepository orderItemReturnRepository,
        IAppLogger<GetOrderItemReturnDetailsQueryHandler> logger)
    {
        this._mapper = mapper;
        this._orderItemReturnRepository = orderItemReturnRepository;
        this._logger = logger;
    }

    public async Task<OrderItemReturnDetailsDto> Handle(GetOrderItemReturnDetailsQuery request, CancellationToken cancellationToken)
    {
        Models.EFModels.OrderItemReturn? orderItemReturn = await _orderItemReturnRepository.GetDetailIncludeOrderItemAsync(request.Id);

        OrderItemReturnDetailsDto response = _mapper.Map<OrderItemReturnDetailsDto>(orderItemReturn);

        _logger.LogInformation("orderItemReturn was retrieved successfully");
        return response;
    }
}

