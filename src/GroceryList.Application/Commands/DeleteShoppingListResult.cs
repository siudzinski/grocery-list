using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Application.Commands
{
    public class DeleteShoppingListResult
    {
        public bool Success { get; set; }
        public DeleteShoppingListResult(bool success)
        {
            Success = success;
        }
    }
}
