
namespace CarDealership.Services.Repository
{
  using System;
  using CarDealership.Services.Model;
  using Sitecore.Data;
  using System.Collections.Generic;
  using System.Linq;
  using Sitecore.Data.Items;
  using Sitecore.Services.Core;

  public class CustomerRepository : IRepository<Customer>
  {
    private readonly Database db = Database.GetDatabase("master");

    public void Add(Customer entity)
    {
      throw new System.NotImplementedException();
    }

    public void Delete(Customer entity)
    {
      throw new System.NotImplementedException();
    }

    public bool Exists(Customer entity)
    {
      throw new System.NotImplementedException();
    }

    public Customer FindById(string id)
    {
      throw new System.NotImplementedException();
    }

    public IQueryable<Customer> GetAll()
    {
      var allCustomerItems = db.SelectItems("fast:/sitecore/content/home/data/customers//*[@@templatename='Customer']");
      return this.GetCustomesFromItems(allCustomerItems);
    }

    public void Update(Customer entity)
    {
      throw new System.NotImplementedException();
    }

    private IQueryable<Customer> GetCustomesFromItems(IEnumerable<Item> items)
    {
      var customers = new List<Customer>();
      foreach (var item in items)
      {
        customers.Add(new Customer
        {
          Id = item.ID.ToString(),
          Name = item.Fields["Name"].Value,
          Surname = item.Fields["Surname"].Value,
          Age = string.IsNullOrEmpty(item.Fields["Age"].Value) ? 0 : Convert.ToInt32(item.Fields["Age"].Value),
          HouseNumber = string.IsNullOrEmpty(item.Fields["HouseNumber"].Value) ? 0 : Convert.ToInt32(item.Fields["HouseNumber"].Value),
          Street = item.Fields["Street"].Value,
          Town = item.Fields["Town"].Value,
          ZipCode = item.Fields["ZipCode"].Value,
          Country = item.Fields["Country"].Value,
          Created = item.Statistics.Created
        });
      }
      return customers.AsQueryable();
    }
  }
}
