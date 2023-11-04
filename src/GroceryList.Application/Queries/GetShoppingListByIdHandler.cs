using GroceryList.Application.DTOs;
using GroceryList.Core.Entities;
using GroceryList.Infrastructure.Repositories;

namespace GroceryList.Application.Queries;

public class GetShoppingListByIdHandler
{

    public ShoppingListDto? Handle(GetShoppingListById query)
    {
        ShoppingList shoppingList = ShoppingListRepository.GetById(query.ShoppingListId);

        if(shoppingList == null)
        {
            return null;
        }

        ShoppingListDto shoppingListDto = new ShoppingListDto
        {
            Id = shoppingList.Id,
            Items = shoppingList.Items
        };

        return shoppingListDto;
    }
}
