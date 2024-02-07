using GroceryList.Core.Entities;

namespace GroceryList.Application.Commands;

public record CreateShoppingList(List<ShoppingListItem> Items, int Quantity);
