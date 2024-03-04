namespace GroceryList.Application.DTOs;

public class ShoppingListDto
{
    public IEnumerable<ShoppingListtItemsQuantityDto>? Items { get; init; }
    public Guid Id { get; init; }
}