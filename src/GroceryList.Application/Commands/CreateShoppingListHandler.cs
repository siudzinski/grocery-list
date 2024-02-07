using GroceryList.Application.DTOs;
using GroceryList.Core.Entities;
using GroceryList.Core.Repositories;
using System.Security.Cryptography.X509Certificates;

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


        foreach (var item in createShoppingList.Items)
        {
            shoppingList.AddItem(item.Name, item.Quantity);
        }

        ShoppingListDto shoppingListDto = new ShoppingListDto
        {
            Id = shoppingList.Id,

        };

        _shoppingListRepository.Save(shoppingList);

        return shoppingListDto;
    }
}