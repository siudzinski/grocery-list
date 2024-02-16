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
        systemUnderTests.Handle(command);

        // Assert
        repositoryMock.Verify(repo => repo.Save(It.IsAny<ShoppingList>()), Times.Once);
    }
    [Fact]
    public void Handle_should_CreateShoppingList_with_quantity()
    {
        // Arrange
        var repositoryMock = new Mock<IShoppingListRepository>();
        var systemUnderTests = new CreateShoppingListHandler(repositoryMock.Object);

        var QuantityDto = new ShoppingListQuantityDto
        {
            Name = "item1",
            Quantity = 1
        };

        // Act
        systemUnderTests.Handle(new CreateShoppingList(new[] { QuantityDto.Name }));

        // Assert
        Assert.Equal("item1", QuantityDto.Name);
        Assert.Equal(1, QuantityDto.Quantity);

        repositoryMock.Verify(repo => repo.Save(It.IsAny<ShoppingList>()), Times.Once);
    }
}