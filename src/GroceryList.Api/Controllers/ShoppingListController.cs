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
        [HttpGet]
        public ActionResult ShoppingListIdStatus(GetShoppingListById id)
        {
            var shoppingListDto = _getShoppingListByIdHandler.Handle(id);

            if(shoppingListDto == null)
            {
                return NotFound("The list with the given id does not exist");
            }
            return Ok(shoppingListDto);
        }
    }
}