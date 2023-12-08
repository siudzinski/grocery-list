using GroceryList.Application.DTOs;
using GroceryList.Core.Entities;
using GroceryList.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Application.Commands
{
    public class AddShoppingListItemHandler
    {
        private readonly IShoppingListRepository _shoppingListRepository;


        public AddShoppingListItemHandler(IShoppingListRepository shoppingListRepository)
        {
            _shoppingListRepository = shoppingListRepository;
        }

        public AddShoppingListResult Handle(AddShoppingListItem addShoppingListItem)
        {
            var shoppingList = new ShoppingList(Guid.NewGuid());

            var newItem = _shoppingListRepository.AddNewItem(shoppingList.Id,addShoppingListItem.ShoppingListItem);

            if(newItem == true)
            {
                shoppingList.AddItem(newItem.ToString());

                return new AddShoppingListResult {  result = true };    
            }
            else
            {
                return new AddShoppingListResult { result = false };
            }
           
        }
    }
}
