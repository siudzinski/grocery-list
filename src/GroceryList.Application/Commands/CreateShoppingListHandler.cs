using GroceryList.Application.DTOs;
using GroceryList.Core.Entities;
using GroceryList.Core.Repositories;

namespace GroceryList.Application.Commands;

public class CreateShoppingListHandler
{
    private readonly IShoppingListRepository _shoppingListRepository;

    public CreateShoppingListHandler(IShoppingListRepository shoppingListRepository)
    {
        _shoppingListRepository = shoppingListRepository;
    }
    public ShoppingListDto? Handle(CreateShoppingList createShoppingList)
    {
        var shoppingList = new ShoppingList(Guid.NewGuid());

        foreach (var list in createShoppingList.Items)
        {
            shoppingList.AddItem(list);
        }
        var items = shoppingList.Items.Select(item => new ShoppingListQuantityDto
        {
            Name = item.Name,
            Quantity = item.Quantity,
        });

        ShoppingListDto shoppingListDto = new ShoppingListDto
        {
            Id = shoppingList.Id,
           Items = items.ToList(),
        };

        _shoppingListRepository.Save(shoppingList);

        return shoppingListDto;
    }
}