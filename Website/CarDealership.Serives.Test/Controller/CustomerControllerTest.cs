
namespace CarDealership.Serives.Test.Controller
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using CarDealership.Services.Controller;
  using CarDealership.Services.Model;
  using CarDealership.Services.Repository;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Moq;

  [TestClass]
  public class CustomerControllerTest
  {
    private  Mock<ICustomerRepository> mockCustomerRepository;

    private Mock<ICarPurchaseRepository> mockCarPurchaseRepository;
    private Mock<ICarRepository> mockCarRepository;
    private Mock<ISalesPersonRepository> mockSalesPersonRepository;

    private CustomerController controller;
    private List<Car> cars;
    private List<CarPurchase> carPurchases;
    private List<SalesPerson> salesPersons;
    private Customer customer1;
    private Customer customer2;

    [TestInitialize]
    public void Setup()
    {
      this.mockCustomerRepository = new Mock<ICustomerRepository>();
      this.mockCarPurchaseRepository = new Mock<ICarPurchaseRepository>();
      this.mockCarRepository = new Mock<ICarRepository>();
      this.mockSalesPersonRepository = new Mock<ISalesPersonRepository>();

      this.controller = new CustomerController(this.mockCustomerRepository.Object)
      {
        CarRepository = this.mockCarRepository.Object,
        CarPurchaseRepository = this.mockCarPurchaseRepository.Object,
        SalesPersonRepository = this.mockSalesPersonRepository.Object
      };

      var carId1 = Guid.NewGuid().ToString();
      var carId2 = Guid.NewGuid().ToString();
      var customerId1 = Guid.NewGuid().ToString();
      var customerId2 = Guid.NewGuid().ToString();
      var salesPerson1 = Guid.NewGuid().ToString();
      var salesPerson2 = Guid.NewGuid().ToString();

      this.cars = new List<Car>
      {
        new Car
        {
          Id = carId1
        },
        new Car
        {
          Id = carId2
        }
      };

      this.carPurchases = new List<CarPurchase>
      {
        new CarPurchase
        {
          Car = carId1,
          Customer = customerId1,
          SalesPerson = salesPerson1
        },
        new CarPurchase
        {
          Id = carId2,
          Customer = customerId2,
          SalesPerson = salesPerson1
        },
        new CarPurchase
        {
          Id = carId1,
          Customer = customerId2,
          SalesPerson = salesPerson1
        }
      };

      this.salesPersons = new List<SalesPerson>
      {
        new SalesPerson
        {
          Id = salesPerson1
        },
        new SalesPerson
        {
          Id = salesPerson2
        }
      };

      this.customer1 = new Customer
      {
        Id = customerId1
      };

      this.customer2 = new Customer
      {
        Id = customerId2
      };
    }

    [TestMethod]
    public void GetByNameShouldCallFindByName()
    {
      //Assign
      string name = "John";

      //Act
      this.controller.GetByName(name);

      //Assert
      this.mockCustomerRepository.Verify(c => c.FindByName(name));
    }

    [TestMethod]
    public void GetByNameShouldReturnIEnumerableCustomer()
    {
      //Act
      var result = controller.GetByName("John");

      //Assert
      Assert.IsInstanceOfType(result, typeof(IEnumerable<Customer>));
    }

    [TestMethod]
    public void GetByStreetShouldCallFindByStreet()
    {
      //Assign
      string street = "Rosikildevej";

      //Act
      this.controller.GetByStreet(street);

      //Assert
      this.mockCustomerRepository.Verify(c => c.FindByStreet(street));
    }

    [TestMethod]
    public void GetByStreetShouldReturnIEnumerableCustomer()
    {
      //Act
      var result = controller.GetByStreet("Rosikildevej");

      //Assert
      Assert.IsInstanceOfType(result, typeof(IEnumerable<Customer>));
    }

    [TestMethod]
    public void GetByCarMakeShouldReturnCorrectCustomers()
    {
      //Assign
      string make = "Toyata";
      this.mockCarRepository.Setup(c => c.FindByMake(make)).Returns(this.cars.AsQueryable);
      this.mockCarPurchaseRepository.Setup(c => c.FindByCar(It.IsAny<List<string>>())).Returns(this.carPurchases.AsQueryable);
      this.mockCustomerRepository.Setup(c => c.FindById(this.customer1.Id)).Returns(this.customer1);
      this.mockCustomerRepository.Setup(c => c.FindById(this.customer2.Id)).Returns(this.customer2);
      //Act
      var result = this.controller.GetByCarMake(make);

      //Assert
      Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void GetByCarMakeShouldReturnIEnumerableCustomer()
    {
      //Act
      var result = controller.GetByCarMake("Toyota");

      //Assert
      Assert.IsInstanceOfType(result, typeof(IEnumerable<Customer>));
    }

    [TestMethod]
    public void GetByCarModelShouldReturnCorrectCustomers()
    {
      //Assign
      string model = "C4";
      this.mockCarRepository.Setup(c => c.FindByModel(model)).Returns(this.cars.AsQueryable);
      this.mockCarPurchaseRepository.Setup(c => c.FindByCar(It.IsAny<List<string>>())).Returns(this.carPurchases.AsQueryable);
      this.mockCustomerRepository.Setup(c => c.FindById(this.customer1.Id)).Returns(this.customer1);
      this.mockCustomerRepository.Setup(c => c.FindById(this.customer2.Id)).Returns(this.customer2);
      //Act
      var result = this.controller.GetByCarModel(model);

      //Assert
      Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void GetByCarModelShouldReturnIEnumerableCustomer()
    {
      //Act
      var result = controller.GetByCarModel("C4");

      //Assert
      Assert.IsInstanceOfType(result, typeof(IEnumerable<Customer>));
    }

    [TestMethod]
    public void GetBySalesPersonShouldReturnCorrectCustomers()
    {
      //Assign
      string salesPerson = "Lars";
      this.mockSalesPersonRepository.Setup(s => s.FindByName(salesPerson)).Returns(this.salesPersons.AsQueryable);
      this.mockCarPurchaseRepository.Setup(c => c.FindBySalesPerson(It.IsAny<List<string>>())).Returns(this.carPurchases.AsQueryable);
      this.mockCustomerRepository.Setup(c => c.FindById(this.customer1.Id)).Returns(this.customer1);
      this.mockCustomerRepository.Setup(c => c.FindById(this.customer2.Id)).Returns(this.customer2);
      //Act
      var result = this.controller.GetBySalesPerson(salesPerson);

      //Assert
      Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void GetBySalesPersonShouldReturnIEnumerableCustomer()
    {
      //Act
      var result = controller.GetBySalesPerson("Lars");

      //Assert
      Assert.IsInstanceOfType(result, typeof(IEnumerable<Customer>));
    }
  }
}
