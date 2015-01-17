
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
  public class SalesPersonRepositoryTest
  {
    private Mock<ISearchIndex> mockSearchIndex;
    private Mock<IProviderSearchContext> mockSearchContext;

    private ID salesPersonId1, salesPersonId2, salesPersonId3;
    private string salesPersonName1, salesPersonName2, salesPersonName3;
    private List<SalesPersonItem> salesPersonItems;

    [TestInitialize]
    public void Setup()
    {
      this.mockSearchIndex = new Mock<ISearchIndex>();
      this.mockSearchContext = new Mock<IProviderSearchContext>();
      this.mockSearchIndex.Setup(i => i.CreateSearchContext(SearchSecurityOptions.EnableSecurityCheck)).Returns(this.mockSearchContext.Object);

      this.salesPersonId1 = ID.NewID;
      this.salesPersonId2 = ID.NewID;
      this.salesPersonId3 = ID.NewID;

      this.salesPersonName1 = "Lars";
      this.salesPersonName2 = "Lars";
      this.salesPersonName3 = "Michael";

      this.salesPersonItems = new List<SalesPersonItem>
      {
        new SalesPersonItem
        {
          ItemId = this.salesPersonId1,
          SalesPersonName = this.salesPersonName1
        },
        new SalesPersonItem
        {
          ItemId = this.salesPersonId2,
          SalesPersonName = this.salesPersonName2
        },
        new SalesPersonItem
        {
          ItemId = this.salesPersonId3,
          SalesPersonName = this.salesPersonName3
        }
      };
    }

    [TestMethod]
    public void FindById_ShouldFindUniqueSalesPerson()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<SalesPersonItem>()).Returns(this.salesPersonItems.AsQueryable);

      // Act
      var salesPersonRepository = new SalesPersonRepository(this.mockSearchIndex.Object);
      var result = salesPersonRepository.FindById(salesPersonId1.ToString());

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(salesPersonId1.ToString(), result.Id);
    }

    [TestMethod]
    public void FindById_ShouldReturnEmptyIfSalesPersonNotFound()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<SalesPersonItem>()).Returns(this.salesPersonItems.AsQueryable);

      // Act
      var salesPersonRepository = new SalesPersonRepository(this.mockSearchIndex.Object);
      var result = salesPersonRepository.FindById(ID.NewID.ToString());

      // Assert
      Assert.IsNull(result);
    }

    [TestMethod]
    public void GetAll_ShouldReturnAllSalesPersons()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<SalesPersonItem>()).Returns(this.salesPersonItems.AsQueryable);

      // Act
      var salesPersonRepository = new SalesPersonRepository(this.mockSearchIndex.Object);
      var result = salesPersonRepository.GetAll();

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(3, result.Count());
    }

    [TestMethod]
    public void FindByName_ShouldFindSalesPersonsWithThatName()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<SalesPersonItem>()).Returns(this.salesPersonItems.AsQueryable);

      // Act
      var salesPersonRepository = new SalesPersonRepository(this.mockSearchIndex.Object);
      var result = salesPersonRepository.FindByName("Lars");

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void FindByName_ShouldReturnEmptyIfSalesPersonNotFound()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<SalesPersonItem>()).Returns(this.salesPersonItems.AsQueryable);

      // Act
      var salesPersonRepository = new SalesPersonRepository(this.mockSearchIndex.Object);
      var result = salesPersonRepository.FindByName("Jan");

      // Assert
      Assert.AreEqual(0, result.Count());
    }
  }
}

