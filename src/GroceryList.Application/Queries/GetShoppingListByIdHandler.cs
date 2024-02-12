using GroceryList.Application.DTOs;
using GroceryList.Core.Entities;
using GroceryList.Core.Repositories;

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
        List<ShoppingListItemsDto> items = shoppingList.Items.Select(x => new ShoppingListItemsDto
        {
            Name = x.Name,
            Quantity = x.Quantity,
        }).ToList();

        ShoppingListDto shoppingListDto = new ShoppingListDto
        {
            Id = shoppingList.Id,
            Items = items.ToList(),
        };
        return shoppingListDto;
    }
}