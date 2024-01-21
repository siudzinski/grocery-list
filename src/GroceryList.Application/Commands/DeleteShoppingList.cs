using GroceryList.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Application.Commands
{
    public record DeleteShoppingList(Guid id);
}