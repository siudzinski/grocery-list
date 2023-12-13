using GroceryList.Application.Commands;
using GroceryList.Application.Queries;
using GroceryList.Core.Entities;
using GroceryList.Core.Repositories;
using Moq;

namespace GroceryList.Tests.GroceryList.Application.Commands
{
    public class AddShoppingListTests
    {
        [Fact]
        public void Handle_Should_Add_New_Item_To_ShoppingList_And_Save_Repository()
        {
            // Arrange
            var repositoryMock = new Mock<IShoppingListRepository>();
            var systemUnderTests = new AddShoppingListItemHandler(repositoryMock.Object);

            var shoppingListId = new GetShoppingListById(Guid.NewGuid());

            var command = new AddShoppingListItem(shoppingListId, new[] { "Item1", "Item2", "Item3" });

            // act
            systemUnderTests.Handle(command);

            // Assert 
            repositoryMock.Verify(repo => repo.Save(It.IsAny<ShoppingList>()));
        }
    }
}