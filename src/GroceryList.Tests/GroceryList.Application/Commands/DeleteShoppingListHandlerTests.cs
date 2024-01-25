using GroceryList.Application.Commands;
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
    public class DeleteShoppingListHandlerTests
    {
        private readonly Mock<IShoppingListRepository> _repositoryMock;
        private readonly DeleteshoppingListHandler _systemUnderTests;

        public DeleteShoppingListHandlerTests()
        {
            _repositoryMock = new Mock<IShoppingListRepository>();
            _systemUnderTests = new DeleteshoppingListHandler(_repositoryMock.Object);
        }
        [Fact]
        public void Handle_Should_Delete_Shopping_List_And_Return_true_If_List_Existing()
        {
            // Arrange
            var shoppingListId = Guid.NewGuid();
            var deleteShoppingList = new DeleteShoppingList(shoppingListId);

            _repositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(new ShoppingList(shoppingListId));
                         
            // Act 

               var result = _systemUnderTests.DeleteShoppingList(deleteShoppingList);

            // Assert
            _repositoryMock.Verify(repo => repo.Delete(shoppingListId), Times.Once);
            result.ShouldNotBeNull();
            result.Success.ShouldBeTrue();
        }
        [Fact]
        public void Handle_Should_Delete_Shopping_List_And_Return_false_If_List_Doesnt_Existing()
        {
            // Arrange
            var shoppingListId = Guid.NewGuid();
           
            var deleteShoppingList = new DeleteShoppingList(shoppingListId);

            _repositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()));
            // Act 

            var result = _systemUnderTests.DeleteShoppingList(deleteShoppingList);

            // Assert
            _repositoryMock.Verify(repo => repo.Delete(shoppingListId), Times.Never);
            result.ShouldNotBeNull();
            result.Success.ShouldBeFalse();

        }
    }
}
