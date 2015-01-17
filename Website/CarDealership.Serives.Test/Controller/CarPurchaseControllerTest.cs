
namespace CarDealership.Serives.Test.Controller
{
  using CarDealership.Services.Controller;
  using CarDealership.Services.Model;
  using CarDealership.Services.Repository;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Moq;
  using System;
  using System.Collections.Generic;

  [TestClass]
  public class CarPurchaseControllerTest
  {
    private string customerId = Guid.NewGuid().ToString();

    [TestMethod]
    public void GetByCustomerIdShouldCallFindByCustomer()
    {
      //Arrange
      var carPurchaseRepositoryMock = new Mock<ICarPurchaseRepository>();

      var controller = new CarPurchaseController(carPurchaseRepositoryMock.Object);

      //Act
      controller.GetByCustomerId(this.customerId);

      //Assert
      carPurchaseRepositoryMock.Verify(m => m.FindByCustomer(this.customerId));
    }

    [TestMethod]
    public void GetByCustomerIdShouldReturnIEnumerableCarPurchase()
    {
      //Arrange
      var carPurchaseRepositoryMock = new Mock<ICarPurchaseRepository>();

      var controller = new CarPurchaseController(carPurchaseRepositoryMock.Object);

      //Act
      var result = controller.GetByCustomerId(this.customerId);

      //Assert
      Assert.IsInstanceOfType(result, typeof(IEnumerable<CarPurchase>));
    }

  }
}
