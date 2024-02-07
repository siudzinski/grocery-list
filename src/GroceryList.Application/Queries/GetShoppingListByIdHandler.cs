using GroceryList.Application.DTOs;
using GroceryList.Core.Entities;
using GroceryList.Core.Repositories;
using System.Linq;

namespace GroceryList.Application.Queries;

public class GetShoppingListByIdHandler
{
    private IShoppingListRepository _shoppingListRepository;

    public GetShoppingListByIdHandler(IShoppingListRepository repository)
    {
        _shoppingListRepository = repository;
    }
    public ShoppingListDto? Handle(GetShoppingListById query)
    {
        ShoppingList? shoppingList = _shoppingListRepository.GetById(query.ShoppingListId);

        if (shoppingList == null)
        {
            return null;
        }
        var Items = shoppingList.Items
             .GroupBy(item => item.Name)
              .Select(group => new ShoppingListItemsDto(group.Select(item => new ShoppingListItem(item.Name, item.Quantity)).ToList()));


        ShoppingListDto shoppingListDto = new ShoppingListDto
        {
            Id = shoppingList.Id,
            Items = Items.ToList(),
        };
        return shoppingListDto;
    }
}