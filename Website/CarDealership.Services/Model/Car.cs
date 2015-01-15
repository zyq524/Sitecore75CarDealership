
namespace CarDealership.Services.Model
{
  using Sitecore.Services.Core.Model;

  public class Car : EntityIdentity
  {
    public string Make { get; set; }

    public string Model { get; set; }

    public string Color { get; set; }

    public string Extras { get; set; }

    public string RecommendPrice { get; set; }
  }
}