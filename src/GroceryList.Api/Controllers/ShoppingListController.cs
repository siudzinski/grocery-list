using Microsoft.AspNetCore.Mvc;

namespace GroceryList.Api.Controllers
{
    [Route("shopping-list")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        //create an endpoint /shopping-list/{id} that return shopping list or NotFound (404)
    }
}
