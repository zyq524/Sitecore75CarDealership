
namespace CarDealership.Services.Model
{
  using Sitecore.Services.Core.Model;
  using System;

  public class Customer : EntityIdentity
  {
    public string Name { get; set; }

    public string Surname { get; set; }

    public int Age { get; set; }

    public int HouseNumber { get; set; }

    public string Street { get; set; }

    public string Town { get; set; }

    public string ZipCode { get; set; }

    public string Country { get; set; }

    public DateTime Created { get; set; }
  }
}
