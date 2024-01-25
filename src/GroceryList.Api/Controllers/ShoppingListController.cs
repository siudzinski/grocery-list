using GroceryList.Application.Commands;
using GroceryList.Application.DTOs;
using GroceryList.Application.Queries;
using GroceryList.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GroceryList.Api.Controllers
{
    [Route("shopping-list")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly GetShoppingListByIdHandler _getShoppingListByIdHandler;
        private readonly CreateShoppingListHandler _createShoppingListHandler;
        private readonly AddShoppingListItemHandler _addShoppingListItemHandler;
        private readonly DeleteshoppingListHandler _deleteShoppingListHandler;

        public ShoppingListController(GetShoppingListByIdHandler getShoppingListByIdHandler, CreateShoppingListHandler createShoppingListHandler, AddShoppingListItemHandler addShoppingListItemHandler, DeleteshoppingListHandler deleteShoppingListHandler)
        {
            _getShoppingListByIdHandler = getShoppingListByIdHandler;
            _createShoppingListHandler = createShoppingListHandler;
            _addShoppingListItemHandler = addShoppingListItemHandler;
            _deleteShoppingListHandler = deleteShoppingListHandler;
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
        [HttpPost]
        public ActionResult CreateShoppingList(CreateShoppingList request)
        {
            if (request == null || request.Items.Length == 0)
            {
                return BadRequest(" The list is empty");
            }
            var shoppingListDto = _createShoppingListHandler.Handle(request);

            return Ok(shoppingListDto);
        }

        [HttpPost("{id}")]
        public ActionResult AddShoppingListItem(Guid id, [FromBody] ShoppingListItemsDto request)
        {
            var command = new AddShoppingListItem(id, request.Items);

            var result = _addShoppingListItemHandler.Handle(command);


            if (!result.Success)
            {
                return NotFound();
            }

            return Ok();
        }
        [HttpDelete("shopping-list/{id}")]
        public ActionResult Delete(Guid id)
        {
            var command = new DeleteShoppingList(id);
            var result = _deleteShoppingListHandler.DeleteShoppingList(command);
           
            if(!result.Success)
            {
                return NotFound();
            }
            return Ok();
        }
    }   
}