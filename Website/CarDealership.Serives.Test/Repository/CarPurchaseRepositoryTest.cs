
namespace CarDealership.Serives.Test.Repository
{
  using System.Collections.Generic;
  using System.Linq;
  using CarDealership.Services.Model.ResultItem;
  using CarDealership.Services.Repository;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Moq;
  using Sitecore.ContentSearch;
  using Sitecore.ContentSearch.Security;
  using Sitecore.Data;

  [TestClass]
  public class CarPurchaseRepositoryTest
  {
    private Mock<ISearchIndex> mockSearchIndex;
    private Mock<IProviderSearchContext> mockSearchContext;

    private ID carPurchaseId1, carPurchaseId2, carPurchaseId3;
    private string customerId1, customerId2, customerId3;
    private string carId1, carId2, carId3;
    private string salesPersonId1, salesPersonId2, salesPersonId3;
    private List<CarPurchaseItem> carPurchaseItems;

    [TestInitialize]
    public void Setup()
    {
      this.mockSearchIndex = new Mock<ISearchIndex>();
      this.mockSearchContext = new Mock<IProviderSearchContext>();
      this.mockSearchIndex.Setup(i => i.CreateSearchContext(SearchSecurityOptions.EnableSecurityCheck)).Returns(this.mockSearchContext.Object);

      this.carPurchaseId1 = ID.NewID;
      this.carPurchaseId2 = ID.NewID;
      this.carPurchaseId3 = ID.NewID;

      this.customerId1 = ID.NewID.ToString();
      this.customerId2 = ID.NewID.ToString();
      this.customerId3 = ID.NewID.ToString();

      this.carId1 = ID.NewID.ToString();
      this.carId2 = ID.NewID.ToString();
      this.carId3 = ID.NewID.ToString();

      this.salesPersonId1 = ID.NewID.ToString();
      this.salesPersonId2 = ID.NewID.ToString();
      this.salesPersonId3 = ID.NewID.ToString();

      this.carPurchaseItems = new List<CarPurchaseItem>
      {
        new CarPurchaseItem
        {
          ItemId = this.carPurchaseId1,
          Customer = this.customerId1,
          Car = this.carId1,
          SalesPerson = this.salesPersonId1
        },
        new CarPurchaseItem
        {
          ItemId = this.carPurchaseId2,
          Customer = this.customerId2,
          Car = this.carId2,
          SalesPerson = this.salesPersonId2
        },
        new CarPurchaseItem
        {
          ItemId = this.carPurchaseId3,
          Customer = this.customerId3,
          Car = this.carId3,
          SalesPerson = this.salesPersonId3
        }
      };
    }

    [TestMethod]
    public void FindById_ShouldFindUniqueCarPurchase()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<CarPurchaseItem>()).Returns(this.carPurchaseItems.AsQueryable);

      // Act
      var carPurchaseRepository = new CarPurchaseRepository(this.mockSearchIndex.Object);
      var result = carPurchaseRepository.FindById(carPurchaseId1.ToString());

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(carPurchaseId1.ToString(), result.Id);
    }

    [TestMethod]
    public void FindById_ShouldReturnNullIfCarPurchaseNotFound()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<CarPurchaseItem>()).Returns(this.carPurchaseItems.AsQueryable);

      // Act
      var carPurchaseRepository = new CarPurchaseRepository(this.mockSearchIndex.Object);
      var result = carPurchaseRepository.FindById(ID.NewID.ToString());

      // Assert
      Assert.IsNull(result);
    }

    [TestMethod]
    public void GetAll_ShouldReturnAllCarPurchases()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<CarPurchaseItem>()).Returns(this.carPurchaseItems.AsQueryable);

      // Act
      var carPurchaseRepository = new CarPurchaseRepository(this.mockSearchIndex.Object);
      var result = carPurchaseRepository.GetAll();

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(3, result.Count());
    }

    [TestMethod]
    public void FindByCar_ShouldFindCarPruchasesWithThatId()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<CarPurchaseItem>()).Returns(this.carPurchaseItems.AsQueryable);

      // Act
      var carPurchaseRepository = new CarPurchaseRepository(this.mockSearchIndex.Object);
      var result = carPurchaseRepository.FindByCar(new List<string>{this.carId1});

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(1, result.Count());
    }

    [TestMethod]
    public void FindByCar_ShouldReturnEmptyIfCarPurchaseNotFound()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<CarPurchaseItem>()).Returns(this.carPurchaseItems.AsQueryable);

      // Act
      var carPurchaseRepository = new CarPurchaseRepository(this.mockSearchIndex.Object);
      var result = carPurchaseRepository.FindByCar(new List<string> { ID.NewID.ToString() });

      // Assert
      Assert.AreEqual(0, result.Count());
    }

    [TestMethod]
    public void FindByCustomer_ShouldFindCarPruchasesWithThatId()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<CarPurchaseItem>()).Returns(this.carPurchaseItems.AsQueryable);

      // Act
      var carPurchaseRepository = new CarPurchaseRepository(this.mockSearchIndex.Object);
      var result = carPurchaseRepository.FindByCustomer(this.customerId1);

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(1, result.Count());
    }

    [TestMethod]
    public void FindByCustomer_ShouldReturnEmptyIfCarPurchaseNotFound()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<CarPurchaseItem>()).Returns(this.carPurchaseItems.AsQueryable);

      // Act
      var carPurchaseRepository = new CarPurchaseRepository(this.mockSearchIndex.Object);
      var result = carPurchaseRepository.FindByCustomer(ID.NewID.ToString());

      // Assert
      Assert.AreEqual(0, result.Count());
    }

    [TestMethod]
    public void FindBySalesPerson_ShouldFindCarPruchasesWithThatId()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<CarPurchaseItem>()).Returns(this.carPurchaseItems.AsQueryable);

      // Act
      var carPurchaseRepository = new CarPurchaseRepository(this.mockSearchIndex.Object);
      var result = carPurchaseRepository.FindBySalesPerson(new List<string> { this.salesPersonId1 });

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(1, result.Count());
    }

    [TestMethod]
    public void FindBySalesPerson_ShouldReturnEmptyIfCarPurchaseNotFound()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<CarPurchaseItem>()).Returns(this.carPurchaseItems.AsQueryable);

      // Act
      var carPurchaseRepository = new CarPurchaseRepository(this.mockSearchIndex.Object);
      var result = carPurchaseRepository.FindBySalesPerson(new List<string> { ID.NewID.ToString() });

      // Assert
      Assert.AreEqual(0, result.Count());
    }
  }
}