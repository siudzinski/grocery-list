using GroceryList.Application.Commands;
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
        private readonly CreateShoppingListHandler _createShoppingListHandler;
        private readonly AddShoppingListItemHandler _addShoppingListItemHandler;

        public ShoppingListController(GetShoppingListByIdHandler getShoppingListByIdHandler, CreateShoppingListHandler createShoppingListHandler, AddShoppingListItemHandler addShoppingListItemHandler)
        {
            _getShoppingListByIdHandler = getShoppingListByIdHandler;
            _createShoppingListHandler = createShoppingListHandler;
            _addShoppingListItemHandler = addShoppingListItemHandler;
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
        public ActionResult CreateShoppingList(AddShoppingListItem request)
        {
            if (request == null || request.ShoppingListItem.Length == 0)
            {
                return BadRequest(" The list is empty");
            }
            var shoppingListDto = _createShoppingListHandler.Handle(request);

            return Ok(shoppingListDto);
        }
        [HttpGet]
        public ActionResult ShoppingListIdStatus(AddShoppingListItem addShoppingListItem)
        {
            var shoppingListDto = _getShoppingListByIdHandler.Handle(addShoppingListItem.Id);

            if(shoppingListDto == null)
            {
                return NotFound("The list with the given id does not exist");
            }
            var AddNewItem = _addShoppingListItemHandler.AddItemToShoppingList(shoppingListDto.Id, addShoppingListItem.ShoppingListItem);
            return Ok(AddNewItem);
        }
    }
}