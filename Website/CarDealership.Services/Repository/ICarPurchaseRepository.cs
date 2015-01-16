
namespace CarDealership.Services.Repository
{
  using System.Collections.Generic;
  using CarDealership.Services.Model;
  using Sitecore.Services.Core;
  using System.Linq;

  public interface ICarPurchaseRepository : IRepository<CarPurchase>
  {
    IQueryable<CarPurchase> FindByCar(List<string> carIds);

    IQueryable<CarPurchase> FindBySalesPerson(List<string> salesPersonIds);

    IQueryable<CarPurchase> FindByCustomer(string customerId);
  }
}
