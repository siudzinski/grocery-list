namespace GroceryList.Core.Entities;

public class ShoppingList
{
    public required Guid Id { get; init; }
    public required List<string> Items { get; init; }
}
