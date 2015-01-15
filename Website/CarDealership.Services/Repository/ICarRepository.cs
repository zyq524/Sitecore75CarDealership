
namespace CarDealership.Services.Repository
{
  using CarDealership.Services.Model;
  using Sitecore.Services.Core;
  using System.Linq;

  public interface ICarRepository : IRepository<Car>
  {
    IQueryable<Car> FindByMake(string make);

    IQueryable<Car> FindByModel(string model);
  }
}
