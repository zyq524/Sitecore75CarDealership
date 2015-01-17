
namespace CarDealership.Serives.Test.Repository
{
  using CarDealership.Services.Model.ResultItem;
  using CarDealership.Services.Repository;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Moq;
  using Sitecore.ContentSearch;
  using Sitecore.ContentSearch.Security;
  using Sitecore.Data;
  using System.Collections.Generic;
  using System.Linq;

  [TestClass]
  public class CarRepositoryTest
  {
    private Mock<ISearchIndex> mockSearchIndex;
    private Mock<IProviderSearchContext> mockSearchContext;

    private ID carId1, carId2, carId3;
    private string carMake1, carMake2, carMake3;
    private string carModel1, carModel2, carModel3;
    private List<CarItem> carItems;

    [TestInitialize]
    public void Setup()
    {
      this.mockSearchIndex = new Mock<ISearchIndex>();
      this.mockSearchContext = new Mock<IProviderSearchContext>();
      this.mockSearchIndex.Setup(i => i.CreateSearchContext(SearchSecurityOptions.EnableSecurityCheck)).Returns(this.mockSearchContext.Object);
      
      this.carId1 = ID.NewID;
      this.carId2 = ID.NewID;
      this.carId3 = ID.NewID;

      this.carMake1 = "Citroen";
      this.carMake2 = "Toyota";
      this.carMake3 = "Citroen";

      this.carModel1 = "C4";
      this.carModel2 = "Aygo";
      this.carModel3 = "C4";

      this.carItems = new List<CarItem>
      {
        new CarItem
        {
          ItemId = this.carId1,
          Make = this.carMake1,
          Model = this.carModel1
        },
        new CarItem
        {
          ItemId = this.carId2,
          Make = this.carMake2,
          Model = this.carModel2
        },
        new CarItem
        {
          ItemId = this.carId3,
          Make = this.carMake3,
          Model = this.carModel3
        }
      };
    }

    [TestMethod]
    public void FindById_ShouldFindUniqueCar()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<CarItem>()).Returns(this.carItems.AsQueryable);

      // Act
      var carRepository = new CarRepository(this.mockSearchIndex.Object);
      var result = carRepository.FindById(carId1.ToString());

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(carId1.ToString(), result.Id);
    }

    [TestMethod]
    public void FindById_ShouldReturnEmptyIfCarNotFound()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<CarItem>()).Returns(this.carItems.AsQueryable);

      // Act
      var carRepository = new CarRepository(this.mockSearchIndex.Object);
      var result = carRepository.FindById(ID.NewID.ToString());

      // Assert
      Assert.IsNull(result);
    }

    [TestMethod]
    public void GetAll_ShouldReturnAllCars()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<CarItem>()).Returns(this.carItems.AsQueryable);

      // Act
      var carRepository = new CarRepository(this.mockSearchIndex.Object);
      var result = carRepository.GetAll();

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(3, result.Count());
    }

    [TestMethod]
    public void FindByMake_ShouldFindCarsWithThatMake()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<CarItem>()).Returns(this.carItems.AsQueryable);

      // Act
      var carRepository = new CarRepository(this.mockSearchIndex.Object);
      var result = carRepository.FindByMake("Citroen");

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void FindByMake_ShouldReturnEmptyIfCarNotFound()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<CarItem>()).Returns(this.carItems.AsQueryable);

      // Act
      var carRepository = new CarRepository(this.mockSearchIndex.Object);
      var result = carRepository.FindByMake("Renault");

      // Assert
      Assert.AreEqual(0, result.Count());
    }

    [TestMethod]
    public void FindByModel_ShouldFindCarsWithThatModel()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<CarItem>()).Returns(this.carItems.AsQueryable);

      // Act
      var carRepository = new CarRepository(this.mockSearchIndex.Object);
      var result = carRepository.FindByModel("C4");

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void FindByModel_ShouldReturnNullIfCarNotFound()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<CarItem>()).Returns(this.carItems.AsQueryable);

      // Act
      var carRepository = new CarRepository(this.mockSearchIndex.Object);
      var result = carRepository.FindByModel("C3");

      // Assert
      Assert.AreEqual(0, result.Count());
    }
  }
}
