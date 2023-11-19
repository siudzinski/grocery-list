using GroceryList.Core.Entities;
using Shouldly;

namespace GroceryList.Tests.GroceryList.Core.Entities;

public class ShoppingListTests
{
    [Fact]
    public void ShoppingList_ShouldHasNoItems_WhenInitialized()
    {
        // Arrange
        var shoppingList = new ShoppingList(Guid.NewGuid());

        // Act

        // Assert
        shoppingList.Items.ShouldBeEmpty();
    }

    [Fact]
    public void AddItem_ShouldAddAnotherItem_WhenNameIsUniqeu()
    {
        // Arrange
        var shoppingList = new ShoppingList(Guid.NewGuid());
        string itemName1 = "Item 1";
        string itemName2 = "Item 2";

        // Act
        shoppingList.AddItem(itemName1);
        shoppingList.AddItem(itemName2);

        // Assert
        shoppingList.Items.Count.ShouldBe(2);
        var item1 = shoppingList.Items.First(i => i.Name == itemName1);
        item1.ShouldNotBeNull();
        item1.Quantity.ShouldBe(1);
        var item2 = shoppingList.Items.First(i => i.Name == itemName2);
        item2.ShouldNotBeNull();
        item2.Quantity.ShouldBe(1);
    }

    [Fact]
    public void AddItem_ShouldIncreaseQuantityOfItem_WhenNameExists()
    {
        // Arrange
        var shoppingList = new ShoppingList(Guid.NewGuid());
        string itemName = "Item";

        // Act
        shoppingList.AddItem(itemName);
        shoppingList.AddItem(itemName);

        // Assert
        var item = shoppingList.Items.SingleOrDefault(i => i.Name == itemName);
        item.ShouldNotBeNull();
        item.Quantity.ShouldBe(2);
    }
}