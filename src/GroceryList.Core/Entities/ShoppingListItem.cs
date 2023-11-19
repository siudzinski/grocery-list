namespace GroceryList.Core.Entities;

public class ShoppingListItem
{
    public string Name { get; }
    public int Quantity { get; private set; } = 1;

    public ShoppingListItem(string name)
    {
        Name = name;
    }
    public void IncrementQuantity()
    {
        Quantity++;
    }
}