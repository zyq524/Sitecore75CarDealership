
namespace CarDealership.Services.Repository
{
  using System.Linq;
  using CarDealership.Services.Model;
  using Sitecore.Services.Core;

  public interface ICustomerRepository : IRepository<Customer>
  {
    IQueryable<Customer> FindByName(string name);

    IQueryable<Customer> FindByStreet(string street);
  }
}
