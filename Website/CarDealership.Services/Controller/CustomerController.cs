
namespace CarDealership.Services.Controller
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Web.Http;
  using CarDealership.Services.Model;
  using CarDealership.Services.Repository;
  using Sitecore.Services.Core;
  using Sitecore.Services.Infrastructure.Sitecore.Services;

  [ServicesController]
  public class CustomerController : EntityService<Customer>
  {
    private readonly CustomerRepository repository;

    public CustomerController(CustomerRepository repository)
      : base(repository)
    {
      this.repository = repository;
    }

    public CustomerController()
      : this(new CustomerRepository())
    {
    }

    [HttpGet]
    public IEnumerable<Customer> GetByName(string name)
    {
      return this.repository.GetAll().Where(customer => string.Equals(customer.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    [HttpGet]
    public IEnumerable<Customer> GetByStreet(string street)
    {
      return this.repository.GetAll().Where(customer => string.Equals(customer.Street, street, StringComparison.OrdinalIgnoreCase));
    }
  }
}
