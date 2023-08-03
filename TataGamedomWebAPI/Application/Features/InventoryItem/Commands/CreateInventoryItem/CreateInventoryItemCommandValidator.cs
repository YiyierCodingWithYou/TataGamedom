using FluentValidation;
using TataGamedomWebAPI.Application.Contracts.Persistence;

namespace TataGamedomWebAPI.Application.Features.InventoryItem.Commands.CreateInventoryItem;

public class CreateInventoryItemCommandValidator : AbstractValidator<CreateInventoryItemCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IStockInSheetRepository _stockInSheetRepository;

    public CreateInventoryItemCommandValidator(
        IProductRepository productRepository,
        IStockInSheetRepository stockInSheetRepository)
    {
        this._productRepository = productRepository;
        this._stockInSheetRepository = stockInSheetRepository;

        RuleFor(p =>p.ProductId)
            .NotEmpty()
            .MustAsync(ProductMustExist)
            .WithMessage("此產品編號不存在");

        RuleFor(p => p.StockInSheetId)
            .NotEmpty()
            .MustAsync(StockInSheetMustExist)
            .WithMessage("此進貨單編號不存在");

        RuleFor(p => p.Cost)
            .LessThan(9999999).WithMessage("超過金額上限")
            .GreaterThanOrEqualTo(0).WithMessage("金額不得為負值");
    }

    private async Task<bool> ProductMustExist(int productId, CancellationToken token)
    {
        return await _productRepository.IsProductExist(productId);
    }

    private async Task<bool> StockInSheetMustExist(int stockInSheetId, CancellationToken token)
    {
        return await _stockInSheetRepository.IsStockInSheetExist(stockInSheetId);
    }

}
