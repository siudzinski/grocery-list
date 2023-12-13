
using GroceryList.Application.Queries;

namespace GroceryList.Application.Commands;

    public record AddShoppingListItem(GetShoppingListById Id, string[] ShoppingListItem);