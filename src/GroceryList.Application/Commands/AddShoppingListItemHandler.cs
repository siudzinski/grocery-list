using GroceryList.Application.DTOs;
using GroceryList.Core.Entities;
using GroceryList.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            var shoppingList = _shoppingListRepository.GetById(addShoppingListItem.Id.ShoppingListId);

            if (shoppingList != null)
            {
                foreach (var item in addShoppingListItem.ShoppingListItem)
                {
                    shoppingList.AddItem(item);
                }
                return new AddShoppingListResult { Result = true };
            }
            else { return new AddShoppingListResult { Result = false }; }
        }
        public class ShoppingList
        {
            public Guid Id { get; init; }
            public ReadOnlyCollection<ShoppingListItem> Items => _items.AsReadOnly();

            private List<ShoppingListItem> _items;

            public ShoppingList(Guid id)
            {
                Id = id;
                _items = new List<ShoppingListItem>();
            }
            public void AddItem(string itemName)
            {
                var existingItem = _items.FirstOrDefault(x => x.Name == itemName);

                if (existingItem != null)
                {
                    existingItem.IncrementQuantity();
                }
                else
                {
                    var newItem = new ShoppingListItem(itemName);
                    _items.Add(newItem);
                }
            }
        }
            public bool AddItemToShoppingList(Guid id, string[] item)
            {
                var shoppingList = _shoppingListRepository.GetById(id);
                if (shoppingList != null)
                {
                    shoppingList.AddItem(item.Length.ToString());
                    return true;
                }
                return false;
            }
        }
    }