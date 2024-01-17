using GroceryList.Application.Commands;
using GroceryList.Application.Queries;
using GroceryList.Core.Entities;
using GroceryList.Core.Repositories;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Tests.GroceryList.Application.Commands
{
    public class AddShoppingListItemHandlerTests
    {
        private readonly Mock<IShoppingListRepository> _repositoryMock;
        private readonly AddShoppingListItemHandler _systemUnderTests;

        public AddShoppingListItemHandlerTests()
        {
            _repositoryMock = new Mock<IShoppingListRepository>();
            _systemUnderTests = new AddShoppingListItemHandler(_repositoryMock.Object);
        }
        [Fact]
        public void Handle_Should_Add_Item_To_ShoppingList_and_return_true()
        {
            // Arrange
            var shoppingListId = Guid.NewGuid();
            var item = new[] { "item1", "item2", "item3" };
            var addShoppingListItem = new AddShoppingListItem(shoppingListId, item);


            _repositoryMock.Setup(repo => repo.GetById(shoppingListId))
                   .Returns(new ShoppingList(shoppingListId));

            var query = new AddShoppingListItem(shoppingListId, item);

            // Act
            var result = _systemUnderTests.Handle(addShoppingListItem);

            // Assert
            _repositoryMock.Verify(repo => repo.Save(It.IsAny<ShoppingList>()), Times.Once);
            result.ShouldNotBeNull();
            result.Success.ShouldBeTrue();


        }
        [Fact]
        public void Handle_Should_Add_Item_To_ShoppingList_and_return_false()
        {
            // Arrange
            var shoppingListId = Guid.NewGuid();
            var item = new string[0];
            var addShoppingListItem = new AddShoppingListItem(shoppingListId, item);


            _repositoryMock
             .Setup(repo => repo.GetById(It.IsAny<Guid>()));

            var query = new AddShoppingListItem(shoppingListId, item);

            // Act
            var result = _systemUnderTests.Handle(addShoppingListItem);

            // Assert
            _repositoryMock.Verify(repo => repo.Save(It.IsAny<ShoppingList>()), Times.Never);
            result.ShouldNotBeNull();
            result.Success.ShouldBeFalse();
        }
    }
}