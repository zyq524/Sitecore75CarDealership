
namespace CarDealership.Services.Model
{
  using Sitecore.Services.Core.Model;

  public class SalesPerson : EntityIdentity
  {
    public string SalesPersonName { get; set; }

    public string JobTitle { get; set; }

    public string Address { get; set; }

    public string Salary { get; set; }
  }
}
