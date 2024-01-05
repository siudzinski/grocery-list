using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Application.Commands
{
    public class AddShoppingListItemResult
    {
        public bool Success { get; set; }
        public AddShoppingListItemResult(bool success)
        {
            Success = success;
        }
    }
}
