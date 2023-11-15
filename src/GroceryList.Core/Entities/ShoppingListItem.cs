namespace GroceryList.Core.Entities;

public record ShoppingListItem
{
    public string? Name { get; set; }
    public int? Quantity { get; set; }

    public ShoppingListItem()
    {
        Quantity = 1;
    }
    public void IncrementQuantity()
    {
        Quantity++;
    }
}