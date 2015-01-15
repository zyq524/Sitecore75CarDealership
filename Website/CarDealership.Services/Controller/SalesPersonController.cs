
namespace CarDealership.Services.Controller
{
  using CarDealership.Services.Model;
  using CarDealership.Services.Repository;
  using Sitecore.Services.Core;
  using Sitecore.Services.Infrastructure.Sitecore.Services;

  [ServicesController]
  public class SalesPersonController : EntityService<SalesPerson>
  {
    public SalesPersonController(ISalesPersonRepository salesPersonRepository)
      : base(salesPersonRepository)
    {

    }

    public SalesPersonController()
      : this(new SalesPersonRepository())
    {
    }
  }
}

