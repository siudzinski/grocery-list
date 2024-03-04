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
        var sortedItems = shoppingList.Items
            .GroupBy(item => item.Name.ToLower())
            .Select(sort => new ShoppingListtItemsQuantityDto
            {
                Name = sort.First().Name,
                Quantity = sort.Sum(item => item.Quantity)
            });

        ShoppingListDto shoppingListDto = new ShoppingListDto
        {
            Id = shoppingList.Id,
            Items = sortedItems.ToList()
        };
        return shoppingListDto;
    }
}