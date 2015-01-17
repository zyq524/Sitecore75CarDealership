
namespace CarDealership.Services.Repository
{
  using CarDealership.Services.Helper;
  using CarDealership.Services.Model;
  using CarDealership.Services.Model.ResultItem;
  using Sitecore.ContentSearch;
  using Sitecore.Data;
  using System;
  using System.Linq;
  using Sitecore.Diagnostics;

  public class CustomerRepository : ICustomerRepository
  {
    private readonly ISearchIndex searchIndex;

    public CustomerRepository(ISearchIndex searchIndex)
    {
      Assert.ArgumentNotNull(searchIndex, "searchIndex");

      this.searchIndex = searchIndex;
    }

    public CustomerRepository()
      : this(ContentSearchManager.GetIndex("cardealership_customers"))
    {
      
    }

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
      Assert.ArgumentNotNullOrEmpty(id, "id");

      using (var context = this.searchIndex.CreateSearchContext())
      {
        var customerItem = context.GetQueryable<CustomerItem>().FirstOrDefault(c => c.ItemId == ID.Parse(id));
        return customerItem == null ? null : ConverterHelper.GetCustomerFromItem(customerItem);
      }
    }

    public IQueryable<Customer> GetAll()
    {
      using (var context = this.searchIndex.CreateSearchContext())
      {
        var customerItems = context.GetQueryable<CustomerItem>().ToList();
        return ConverterHelper.GetCustomersFromItems(customerItems).AsQueryable();
      }
    }

    public void Update(Customer entity)
    {
      throw new System.NotImplementedException();
    }

    public IQueryable<Customer> FindByName(string name)
    {
      Assert.ArgumentNotNullOrEmpty(name, "name");

      using (var context = this.searchIndex.CreateSearchContext())
      {
        var customerItems = context.GetQueryable<CustomerItem>().Where(c => string.Equals(name, c.CustomerName, StringComparison.InvariantCultureIgnoreCase)).ToList();
        return ConverterHelper.GetCustomersFromItems(customerItems).AsQueryable();
      }
    }

    public IQueryable<Customer> FindByStreet(string street)
    {
      Assert.ArgumentNotNullOrEmpty(street, "street");

      using (var context = this.searchIndex.CreateSearchContext())
      {
        var customerItems = context.GetQueryable<CustomerItem>().Where(c => string.Equals(street, c.Street, StringComparison.InvariantCultureIgnoreCase)).ToList();
        return ConverterHelper.GetCustomersFromItems(customerItems).AsQueryable();
      }
    }
  }
}
