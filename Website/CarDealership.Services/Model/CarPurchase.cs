namespace CarDealership.Services.Model
{
  using System;
  using Sitecore.Services.Core.Model;

  public class CarPurchase : EntityIdentity
  {
    public string Customer { get; set; }

    public string Car { get; set; }

    public DateTime OrderDate  { get; set; }

    public string PricePaid { get; set; }

    public string SalesPerson { get; set; }
  }
}
