using GroceryList.Core.Entities;
using GroceryList.Core.Repositories;

namespace GroceryList.Infrastructure.Repositories;

public class ShoppingListRepository : IShoppingListRepository
{
    private List<ShoppingList> _shoppingLists = new()
    {
        new() 
        { 
            Id = Guid.Parse("4c842603-bcdf-4498-b479-d5b305c7b8c5"), 
            Items = new List<string> { "apple", "orange" }
        },
        new() 
        { 
            Id = Guid.Parse("00010d5a-8eb9-45de-93a5-f952b7dd6547"), 
            Items = new List<string> { "milk", "bread" }
        },
    };

    public ShoppingList? GetById(Guid id)
    {
        return _shoppingLists.FirstOrDefault(_ => _.Id == id);
    }
}