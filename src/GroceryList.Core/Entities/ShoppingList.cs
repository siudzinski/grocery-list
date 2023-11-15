using System.Collections.ObjectModel;
using System.Linq.Expressions;

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
        ShoppingListItem SameItem = _items.FirstOrDefault(x => x.Name == itemName);
        if(SameItem != null)
        {
            SameItem.Quantity++;
        }
        else
        {
           var Newitem = new ShoppingListItem();
            _items.Add(SameItem);
        }
      
    }
}