using GroceryList.Core.Repositories;

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
            var shoppingList = _shoppingListRepository.GetById(addShoppingListItem.Id);

            if(shoppingList == null)
            {
                return new AddShoppingListItemResult(false);
            }

            foreach (var item in addShoppingListItem.Items)
            {
                shoppingList.AddItem(item.Name, item.Quantity);
            }

            _shoppingListRepository.Save(shoppingList);

            bool success = shoppingList.Items.Any();

            return new AddShoppingListItemResult(success);
        }
    }
}