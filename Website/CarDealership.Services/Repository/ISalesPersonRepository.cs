
namespace CarDealership.Services.Repository
{
  using System.Linq;
  using CarDealership.Services.Model;
  using Sitecore.Services.Core;

  public interface ISalesPersonRepository : IRepository<SalesPerson>
  {
    IQueryable<SalesPerson> FindByName(string name);
  }
}
