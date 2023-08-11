using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Exceptions;
using TataGamedomWebAPI.Infrastructure.TaTaGamedom_Persistence.Repositories;
using TataGamedomWebAPI.Models.Interfaces;

namespace TataGamedomWebAPI.Application.Features.InventoryItem.Commands.CreateInventoryItem;

public class CreateInventoryItemCommandHandler : IRequestHandler<CreateInventoryItemCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IInventoryItemRepository _inventoryItemRepository;
    private readonly IProductRepository _productRepository;
    private readonly IStockInSheetRepository _stockInSheetRepository;
    private readonly IAppLogger<CreateInventoryItemCommandHandler> _logger;
    private readonly IIndexGenerator _indexGenerator;

    public CreateInventoryItemCommandHandler(
        IMapper mapper,
        IInventoryItemRepository inventoryItemRepository,
        IProductRepository productRepository,
        IStockInSheetRepository stockInSheetRepository,
        IAppLogger<CreateInventoryItemCommandHandler> logger,
        IIndexGenerator indexGenerator)
    {
        this._mapper = mapper;
        this._inventoryItemRepository = inventoryItemRepository;
        this._productRepository = productRepository;
        this._stockInSheetRepository = stockInSheetRepository;
        this._logger = logger;
        this._indexGenerator = indexGenerator;
    }

    public async Task<int> Handle(CreateInventoryItemCommand request, CancellationToken cancellationToken)
    {
        await ValidateRequest(request);
        Models.EFModels.InventoryItem inventoryItemToBeCreated = _mapper.Map<Models.EFModels.InventoryItem>(request);

        await GenerateIndex(request, inventoryItemToBeCreated);

        await _inventoryItemRepository.CreateAsync(inventoryItemToBeCreated);
        return inventoryItemToBeCreated.Id;
    }

    private async Task GenerateIndex(CreateInventoryItemCommand request, Models.EFModels.InventoryItem inventoryItemToBeCreated)
    {
        int maxInventoryItemId = await _inventoryItemRepository.GetMaxId();
        inventoryItemToBeCreated.Index = _indexGenerator.GetSKU(inventoryItemToBeCreated, maxInventoryItemId);
    }

    private async Task ValidateRequest(CreateInventoryItemCommand request)
    {
        var validator = new CreateInventoryItemCommandValidator(_productRepository, _stockInSheetRepository);
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid InventoryItem request");
        }
    }
}
