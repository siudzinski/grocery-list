namespace GroceryList.Application.DTOs;

public class ShoppingListDto
{
    public IEnumerable<string>? Items { get; init; }
    public Guid Id { get; init; }
}
