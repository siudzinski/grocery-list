using GroceryList.Core.Entities;

namespace GroceryList.Application.Commands
{
    public record AddShoppingListItem(Guid Id, List<ShoppingListItem> Items);
}