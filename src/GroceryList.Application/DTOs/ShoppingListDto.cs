namespace GroceryList.Application.DTOs;

public class ShoppingListDto
{
    public List<string>? Items { get; set; }
    public Guid Id { get; internal set; }
}
