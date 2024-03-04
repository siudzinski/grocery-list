using GroceryList.Application.Commands;
using GroceryList.Application.DTOs;
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

        var command = new CreateShoppingList(new[] { "item1", "item2", "item3" });

        // Act
       var result = systemUnderTests.Handle(command);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Items);
        Assert.Contains(result.Items,item => item.Name == "item1");
        Assert.Contains(result.Items, item => item.Name == "item2");
        Assert.Contains(result.Items, item => item.Name == "item3");
     
        repositoryMock.Verify(repo => repo.Save(It.IsAny<ShoppingList>()), Times.Once);
    }
}