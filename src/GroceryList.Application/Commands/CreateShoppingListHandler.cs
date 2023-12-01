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
        IEnumerable<string> items = shoppingList.Items.Select(x => x.Name);

        ShoppingListDto shoppingListDto = new ShoppingListDto
        {
            Id = shoppingList.Id,
            Items = items
        };

        _shoppingListRepository.Save(shoppingList);

        return shoppingListDto;
    }
}