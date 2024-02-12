namespace GroceryList.Core.Entities;

public class ShoppingListItem
{
    public string Name { get; set; }
    public int Quantity { get; set; } = 1;

    public ShoppingListItem(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }
    public void IncrementQuantity()
    {
        Quantity++;
    }
}