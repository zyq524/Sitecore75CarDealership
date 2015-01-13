
namespace CarDealership.Services.Controller
{
  using CarDealership.Services.Model;
  using CarDealership.Services.Repository;
  using Sitecore.Services.Core;
  using Sitecore.Services.Infrastructure.Sitecore.Services;

  [ServicesController]
  public class SearchConstraintController : EntityService<SearchConstraint>
  {
    public SearchConstraintController(SearchConstraintRepository repository)
      : base(repository)
    {
    }

    public SearchConstraintController()
      : this(new SearchConstraintRepository())
    {
    }
  }
}
