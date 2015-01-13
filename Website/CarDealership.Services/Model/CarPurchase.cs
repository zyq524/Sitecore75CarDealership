namespace CarDealership.Services.Model
{
  using System;

  public class CarPurchase
  {
    public string Car { get; set; }

    public DateTime Ordered { get; set; }

    public string PricePaid { get; set; }

    public string SalesPerson { get; set; }
  }
}
