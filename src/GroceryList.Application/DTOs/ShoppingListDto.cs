namespace GroceryList.Application.DTOs;

public class ShoppingListDto
{
    public IEnumerable<ShoppingListQuantityDto>? Items { get; init; }
    public Guid Id { get; init; }
}