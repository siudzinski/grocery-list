namespace GroceryList.Core.Entities;

public class ShoppingListItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }

    public ShoppingListItem(string name, int quantity = 1)
    {
        Name = name;
        Quantity = quantity;
    }
    public void IncrementQuantity()
    {
        Quantity++;
    }
}