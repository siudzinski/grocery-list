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

            ShoppingListDto shoppingListDto = new ShoppingListDto
            {
                Id = shoppingList.Id,
                Items = (IEnumerable<string>)shoppingList.Items
            };

            return shoppingListDto;
        }
    }