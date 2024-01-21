using GroceryList.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Application.Commands
{
    public class DeleteshoppingListHandler
    {
        private readonly IShoppingListRepository _shoppingListRepository;
        public DeleteshoppingListHandler(IShoppingListRepository shoppingListRepository)
        {
            _shoppingListRepository = shoppingListRepository;
        }
        public DeleteShoppingListResult DeleteShoppingList(DeleteShoppingList deleteShoppingList)
        {
            var shoppingList = _shoppingListRepository.GetById(deleteShoppingList.id);

            if (shoppingList == null)
            {
                return new DeleteShoppingListResult(false);
            }
            _shoppingListRepository.Delete(deleteShoppingList.id);

            return new DeleteShoppingListResult(true);

        }
    }
}
