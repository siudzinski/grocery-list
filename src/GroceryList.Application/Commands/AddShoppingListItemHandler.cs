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

        public AddShoppingListItemResult Handle(AddShoppingListItem addShoppingListItem)
        {
            var shoppingList = new ShoppingList(Guid.NewGuid());

            foreach (var item in addShoppingListItem.Items)
            {
                shoppingList.AddItem(item);
            }

            _shoppingListRepository.Save(shoppingList);

            bool success = shoppingList.Items.Any();

            return new AddShoppingListItemResult(success);
        }
    }
}