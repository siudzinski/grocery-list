using GroceryList.Core.Entities;
using GroceryList.Core.Repositories;

namespace GroceryList.Infrastructure.Repositories;

public class ShoppingListRepository : IShoppingListRepository
{
    private readonly List<ShoppingList> _shoppingLists;

    public ShoppingListRepository()
    {
        _shoppingLists = new()
        {
            new(Guid.Parse("4c842603-bcdf-4498-b479-d5b305c7b8c5")),
            new(Guid.Parse("00010d5a-8eb9-45de-93a5-f952b7dd6547")),
        };

        _shoppingLists[0].AddItem("apple",1);
        _shoppingLists[0].AddItem("orange", 1);

        _shoppingLists[1].AddItem("milk", 1);
        _shoppingLists[1].AddItem("bread", 1);

    }

    public ShoppingList? GetById(Guid id)
    {
        return _shoppingLists.FirstOrDefault(_ => _.Id == id);
    }

    public void Save(ShoppingList shoppingList)
    {
        _shoppingLists.Add(shoppingList);
    }
    public void Delete(Guid id)
    {
        var shoppingList = _shoppingLists.FirstOrDefault(x => x.Id == id);

        if (shoppingList != null)
        {
            _shoppingLists.Remove(shoppingList);
        }
        else
        {
            throw new Exception("There is no list to delete");
        }
    }
}