using System.Collections.ObjectModel;
namespace GroceryList.Core.Entities;

public class ShoppingList
{
    public Guid Id { get; init; }
    public ReadOnlyCollection<ShoppingListItem> Items => _items.AsReadOnly();

    private List<ShoppingListItem> _items;

    public ShoppingList(Guid id)
    {
        Id = id;
        _items = new List<ShoppingListItem>();
    }
    public void AddItem(string itemName)
    {
        var existingItem = _items.FirstOrDefault(x => x.Name == itemName);

        if (existingItem != null)
        {
            existingItem.IncrementQuantity();
        }
        else
        {
            var newItem = new ShoppingListItem(itemName);
            _items.Add(newItem);
        }
    }
}