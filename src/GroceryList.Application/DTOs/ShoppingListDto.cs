namespace GroceryList.Application.DTOs;

public class ShoppingListDto
{
    public List<ShoppingListItemsDto>? Items { get; init; }
    public Guid Id { get; init; }
}