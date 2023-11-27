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
    public ShoppingListDto? Handle(ShoppingList shoppingList)
    { 
         var shoppingListDto = new ShoppingListDto();

        shoppingList.AddItem(shoppingListDto.Items.ToString());
        _shoppingListRepository.Save(shoppingList);

    return shoppingListDto;
    }
}