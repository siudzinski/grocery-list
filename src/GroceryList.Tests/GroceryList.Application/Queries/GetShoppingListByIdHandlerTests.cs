using GroceryList.Application.Queries;
using GroceryList.Core.Entities;
using GroceryList.Core.Repositories;
using Moq;
using Shouldly;

namespace GroceryList.Tests.GroceryList.Application.Queries;

public class GetShoppingListByIdHandlerTests
{
    private readonly Mock<IShoppingListRepository> _repositoryMock;
    private readonly GetShoppingListByIdHandler _systemUnderTests;

    public GetShoppingListByIdHandlerTests()
    {
        _repositoryMock = new Mock<IShoppingListRepository>();
        _systemUnderTests = new GetShoppingListByIdHandler(_repositoryMock.Object);
    }

    [Fact]
    public void Handle_Should_Return_ShoppingListDto_When_ShoppingListFound()
    {
        // Arrange
        var shoppingListId = Guid.NewGuid();
        var shoppingList = new ShoppingList(shoppingListId);
        shoppingList.AddItem("test");

        _repositoryMock
            .Setup(repo => repo.GetById(shoppingListId))
            .Returns(shoppingList);

        var query = new GetShoppingListById(shoppingListId);

        // Act
        var result = _systemUnderTests.Handle(query);

        // Assert
        result.ShouldNotBeNull();
        result.Items.ShouldNotBeEmpty();
        result.Items.FirstOrDefault()?.Name.ShouldBe("test");
        result.Items.FirstOrDefault()?.Quantity.ShouldBe(1);
    }

    [Fact]
    public void Handle_Should_Return_Null_When_ShoppingListNotFound()
    {
        // Arrange
        var shoppingListId = Guid.NewGuid();

        _repositoryMock
            .Setup(repo => repo.GetById(shoppingListId))
            .Returns((ShoppingList?)null);

        var query = new GetShoppingListById(shoppingListId);

        // Act
        var result = _systemUnderTests.Handle(query);

        // Assert
        result.ShouldBeNull();
    }
}