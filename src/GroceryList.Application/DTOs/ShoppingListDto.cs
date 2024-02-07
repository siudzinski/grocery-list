using GroceryList.Core.Entities;

namespace GroceryList.Application.DTOs;

public class ShoppingListDto
{
    public IEnumerable<ShoppingListItemsDto>? Items { get; init; }
    public Guid Id { get; init; }
   

}