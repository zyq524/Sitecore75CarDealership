
namespace CarDealership.Services.Controller
{
  using CarDealership.Services.Helper;
  using CarDealership.Services.Model;
  using CarDealership.Services.Repository;
  using Sitecore.Diagnostics;
  using Sitecore.Services.Core;
  using Sitecore.Services.Infrastructure.Sitecore.Services;
  using System.Collections.Generic;
  using System.Linq;
  using System.Web.Http;

  [ServicesController]
  public class CustomerController : EntityService<Customer>
  {
    private readonly ICustomerRepository customerRepository;

    private ICarPurchaseRepository carPurchaseRepository;
    private ICarRepository carRepository;
    private ISalesPersonRepository salesPersonRepository;

    public ICarPurchaseRepository CarPurchaseRepository
    {
      get
      {
        if (this.carPurchaseRepository == null)
        {
          this.carPurchaseRepository = new CarPurchaseRepository();
        }
        return this.carPurchaseRepository;
      }
      set
      {
        this.carPurchaseRepository = value;
      }
    }

    public ICarRepository CarRepository
    {
      get
      {
        if (this.carRepository == null)
        {
          this.carRepository = new CarRepository();
        }
        return this.carRepository;
      }
      set
      {
        this.carRepository = value;
      }
    }

    public ISalesPersonRepository SalesPersonRepository
    {
      get
      {
        if (this.salesPersonRepository == null)
        {
          this.salesPersonRepository = new SalesPersonRepository();
        }
        return this.salesPersonRepository;
      }
      set
      {
        this.salesPersonRepository = value;
      }
    }

    public CustomerController(ICustomerRepository customerRepository)
      : base(customerRepository)
    {
      Assert.ArgumentNotNull(customerRepository, "customerRepository");

      this.customerRepository = customerRepository;
    }

    public CustomerController()
      : this(new CustomerRepository())
    {
    }

    [HttpGet]
    public IEnumerable<Customer> GetByName(string name)
    {
      Assert.ArgumentNotNullOrEmpty(name, "name");

      return this.customerRepository.FindByName(name);
    }

    [HttpGet]
    public IEnumerable<Customer> GetByStreet(string street)
    {
      Assert.ArgumentNotNullOrEmpty(street, "street");

      return this.customerRepository.FindByStreet(street);
    }

    [HttpGet]
    public IEnumerable<Customer> GetByCarMake(string carMake)
    {
      Assert.ArgumentNotNullOrEmpty(carMake, "carMake");

      var cars = this.CarRepository.FindByMake(carMake);
      var carPurchases = this.CarPurchaseRepository.FindByCar(cars.Select(c => c.Id.ToString()).ToList());

      return carPurchases.Select(carPurchase => this.customerRepository.FindById(carPurchase.Customer)).Distinct(new CustomerComparer());
    }

    [HttpGet]
    public IEnumerable<Customer> GetByCarModel(string carModel)
    {
      Assert.ArgumentNotNullOrEmpty(carModel, "carModel");

      var cars = this.CarRepository.FindByModel(carModel);
      var carPurchases = this.CarPurchaseRepository.FindByCar(cars.Select(c => c.Id.ToString()).ToList());

      return carPurchases.Select(carPurchase => this.customerRepository.FindById(carPurchase.Customer)).Distinct(new CustomerComparer());
    }

    [HttpGet]
    public IEnumerable<Customer> GetBySalesPerson(string salesPersonName)
    {
      Assert.ArgumentNotNullOrEmpty(salesPersonName, "salesPersonName");

      var salesPersons = this.SalesPersonRepository.FindByName(salesPersonName);
      var carPurchases = this.CarPurchaseRepository.FindBySalesPerson(salesPersons.Select(s => s.Id.ToString()).ToList());

      return carPurchases.Select(carPurchase => this.customerRepository.FindById(carPurchase.Customer)).Distinct(new CustomerComparer());
    }
  }
}
