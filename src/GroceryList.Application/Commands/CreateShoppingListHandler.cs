using GroceryList.Application.DTOs;
using GroceryList.Application.Queries;
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

        foreach(var shopping in createShoppingList.Items)
        {
            shoppingList.AddItem(shopping);
        }
        IEnumerable<string> items = shoppingList.Items.Select(x => x.Name);

        ShoppingListDto shoppingListDto = new ShoppingListDto
        {
            Id = Guid.NewGuid(),
            Items = items
        };

        _shoppingListRepository.Save(shoppingList);

    return shoppingListDto;
    }
}