using GroceryList.Application.Commands;
using GroceryList.Application.DTOs;
using GroceryList.Application.Queries;
using GroceryList.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace GroceryList.Api.Controllers
{
    [Route("shopping-list")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly GetShoppingListByIdHandler _getShoppingListByIdHandler;
        private readonly CreateShoppingListHandler _createShoppingListHandler;

        public ShoppingListController(GetShoppingListByIdHandler getShoppingListByIdHandler, CreateShoppingListHandler createShoppingListHandler)
        {
            _getShoppingListByIdHandler = getShoppingListByIdHandler;
            _createShoppingListHandler = createShoppingListHandler;
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
        [HttpPost("Shopping-List")]
        public ActionResult CreateShoppingList([FromBody] ShoppingList items)
        {
            if (items == null)
            {
                return BadRequest(" The list is empty");
            }

            var shoppingListDto = _createShoppingListHandler.Handle(items);

            return Ok(shoppingListDto);
        }
    }
}