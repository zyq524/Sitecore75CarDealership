
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
  public class CustomerRepositoryTest
  {
    private Mock<ISearchIndex> mockSearchIndex;
    private Mock<IProviderSearchContext> mockSearchContext;

    private ID customerd1, customerd2, customerd3;
    private string customerName1, customerName2, customerName3;
    private string street1, street2, street3;
    private List<CustomerItem> customerItems;

    [TestInitialize]
    public void Setup()
    {
      this.mockSearchIndex = new Mock<ISearchIndex>();
      this.mockSearchContext = new Mock<IProviderSearchContext>();
      this.mockSearchIndex.Setup(i => i.CreateSearchContext(SearchSecurityOptions.EnableSecurityCheck)).Returns(this.mockSearchContext.Object);

      this.customerd1 = ID.NewID;
      this.customerd2 = ID.NewID;
      this.customerd3 = ID.NewID;

      this.customerName1 = "John";
      this.customerName2 = "John";
      this.customerName3 = "Michael";

      this.street1 = "Folehaven";
      this.street2 = "Hvidpilevej";
      this.street3 = "Folehaven";

      this.customerItems = new List<CustomerItem>
      {
        new CustomerItem
        {
          ItemId = this.customerd1,
          CustomerName = this.customerName1,
          Street = this.street1
        },
        new CustomerItem
        {
          ItemId = this.customerd2,
          CustomerName = this.customerName2,
          Street = this.street2
        },
        new CustomerItem
        {
          ItemId = this.customerd3,
          CustomerName = this.customerName3,
          Street = this.street3
        }
      };
    }

    [TestMethod]
    public void FindById_ShouldFindUniqueCustomer()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<CustomerItem>()).Returns(this.customerItems.AsQueryable);

      // Act
      var customerRepository = new CustomerRepository(this.mockSearchIndex.Object);
      var result = customerRepository.FindById(customerd1.ToString());

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(customerd1.ToString(), result.Id);
    }

    [TestMethod]
    public void FindById_ShouldReturnEmptyIfCustomerNotFound()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<CustomerItem>()).Returns(this.customerItems.AsQueryable);

      // Act
      var customerRepository = new CustomerRepository(this.mockSearchIndex.Object);
      var result = customerRepository.FindById(ID.NewID.ToString());

      // Assert
      Assert.IsNull(result);
    }

    [TestMethod]
    public void GetAll_ShouldReturnAllCustomers()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<CustomerItem>()).Returns(this.customerItems.AsQueryable);

      // Act
      var customerRepository = new CustomerRepository(this.mockSearchIndex.Object);
      var result = customerRepository.GetAll();

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(3, result.Count());
    }

    [TestMethod]
    public void FindByName_ShouldFindCustomersWithThatName()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<CustomerItem>()).Returns(this.customerItems.AsQueryable);

      // Act
      var customerRepository = new CustomerRepository(this.mockSearchIndex.Object);
      var result = customerRepository.FindByName("John");

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void FindByName_ShouldReturnEmptyIfCustomerNotFound()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<CustomerItem>()).Returns(this.customerItems.AsQueryable);

      // Act
      var customerRepository = new CustomerRepository(this.mockSearchIndex.Object);
      var result = customerRepository.FindByName("Jan");

      // Assert
      Assert.AreEqual(0, result.Count());
    }

    [TestMethod]
    public void FindByStreet_ShouldFindCustomersWithThatStreet()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<CustomerItem>()).Returns(this.customerItems.AsQueryable);

      // Act
      var customerRepository = new CustomerRepository(this.mockSearchIndex.Object);
      var result = customerRepository.FindByStreet("Folehaven");

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void FindBySteet_ShouldReturnEmptyIfCustomerNotFound()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<CustomerItem>()).Returns(this.customerItems.AsQueryable);

      // Act
      var customerRepository = new CustomerRepository(this.mockSearchIndex.Object);
      var result = customerRepository.FindByName("Pilevej");

      // Assert
      Assert.AreEqual(0, result.Count());
    }
  }
}
