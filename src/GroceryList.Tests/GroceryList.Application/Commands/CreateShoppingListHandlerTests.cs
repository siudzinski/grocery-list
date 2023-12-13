using GroceryList.Application.Commands;
using GroceryList.Application.Queries;
using GroceryList.Core.Entities;
using GroceryList.Core.Repositories;
using Moq;

namespace GroceryList.Tests.GroceryList.Application.Commands;

public class CreateShoppingListHandlerTests
{
    [Fact]
    public void Handle_ShouldCreateShoppingListAndSaveToRepository()
    {
        // Arrange
        var repositoryMock = new Mock<IShoppingListRepository>();
        var systemUnderTests = new CreateShoppingListHandler(repositoryMock.Object);
        var shoppingListId = new GetShoppingListById(Guid.NewGuid());
        var command = new AddShoppingListItem(shoppingListId, new[] { "Item1", "Item2", "Item3" });

        // Act
        systemUnderTests.Handle(command);

        // Assert
        repositoryMock.Verify(repo => repo.Save(It.IsAny<ShoppingList>()), Times.Once);
    }
}