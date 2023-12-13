using GroceryList.Core.Entities;

namespace GroceryList.Core.Repositories;

public interface IShoppingListRepository
{
    ShoppingList? GetById(Guid id);

    void Save(ShoppingList shoppingList);
}