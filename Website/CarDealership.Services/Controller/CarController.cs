
namespace CarDealership.Services.Controller
{
  using CarDealership.Services.Model;
  using CarDealership.Services.Repository;
  using Sitecore.Services.Core;
  using Sitecore.Services.Infrastructure.Sitecore.Services;

  [ServicesController]
  public class CarController : EntityService<Car>
  {

    public CarController(ICarRepository carRepository)
      : base(carRepository)
    {

    }

    public CarController()
      : this(new CarRepository())
    {
    }
  }
}