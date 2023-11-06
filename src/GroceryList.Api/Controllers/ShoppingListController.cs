using GroceryList.Application.DTOs;
using GroceryList.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace GroceryList.Api.Controllers
{
    [Route("shopping-list")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly GetShoppingListByIdHandler _getShoppingListByIdHandler;

        public ShoppingListController(GetShoppingListByIdHandler getShoppingListByIdHandler)
        {
            _getShoppingListByIdHandler = getShoppingListByIdHandler;
        }

        [HttpGet("{id}")]
        public ActionResult GetList(Guid id)
        {
            ShoppingListDto? shoppingListDto = _getShoppingListByIdHandler.Handle(new GetShoppingListById(id));

            if (shoppingListDto == null)
            {
                return NotFound();
            }
            return Ok(shoppingListDto);
        }
    }
}