using GroceryList.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Application.DTOs
{
    public record ShoppingListItemsDto(List<ShoppingListItem> Items);
}