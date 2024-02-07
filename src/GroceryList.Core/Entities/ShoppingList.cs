using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;

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
    public void AddItem(string itemName, int quantity)
    {
        var existingItem = _items.FirstOrDefault(x => x.Name == itemName);

        if (existingItem != null)
        {
            existingItem.IncrementQuantity();
        }
        else
        {
            var newItem = new ShoppingListItem(itemName, quantity );
            _items.Add(newItem);
        }
    }
}