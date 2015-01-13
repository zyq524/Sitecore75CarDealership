
namespace CarDealership.Services.Model
{
  using Sitecore.Services.Core.Model;

  public class SearchConstraint : EntityIdentity
  {
    public string Name { get; set; }

    public string RestUri { get; set; }
  }
}
