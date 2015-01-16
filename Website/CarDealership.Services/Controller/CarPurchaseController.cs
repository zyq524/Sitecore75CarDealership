
namespace CarDealership.Services.Controller
{
  using System.Collections.Generic;
  using System.Web.Http;
  using CarDealership.Services.Model;
  using CarDealership.Services.Repository;
  using Sitecore.Diagnostics;
  using Sitecore.Services.Core;
  using Sitecore.Services.Infrastructure.Sitecore.Services;

  [ServicesController]
  public class CarPurchaseController : EntityService<CarPurchase>
  {
    private readonly ICarPurchaseRepository carPurchaseRepository;

    public CarPurchaseController(ICarPurchaseRepository carPurchaseRepository)
      : base(carPurchaseRepository)
    {
      Assert.ArgumentNotNull(carPurchaseRepository, "carPurchaseRepository");

      this.carPurchaseRepository = carPurchaseRepository;
    }

    public CarPurchaseController()
      : this(new CarPurchaseRepository())
    {
    }

    [HttpGet]
    public IEnumerable<CarPurchase> GetByCustomerId(string customerId)
    {
      Assert.ArgumentNotNullOrEmpty(customerId, "customerId");

      return this.carPurchaseRepository.FindByCustomer(customerId);
    }
  }
}
