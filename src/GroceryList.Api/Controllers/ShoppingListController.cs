using GroceryList.Core.Entities;
using GroceryList.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GroceryList.Api.Controllers
{
    [Route("shopping-list")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListRepository _shoppingListRepository;

        public ShoppingListController(IShoppingListRepository shoppingListRepository)
        {
            _shoppingListRepository = shoppingListRepository;
        }

        [HttpGet("{id}")]
        public ActionResult GetList(Guid id)
        {
            ShoppingList shoppingList = _shoppingListRepository.GetById(id);
            
            if (shoppingList == null)
            {
                return NotFound();
            }
            return Ok(shoppingList);
        }
    } 
}
