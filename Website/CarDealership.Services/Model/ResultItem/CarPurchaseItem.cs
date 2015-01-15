
namespace CarDealership.Services.Model.ResultItem
{
  using System;
  using Sitecore.ContentSearch;
  using Sitecore.ContentSearch.SearchTypes;

  public class CarPurchaseItem : SearchResultItem
  {
    [IndexField("customer")]
    public string Customer { get; set; }

    [IndexField("car")]
    public string Car { get; set; }

    [IndexField("orderdate")]
    public DateTime OrderDate { get; set; }

    [IndexField("pricepaid")]
    public string PricePaid { get; set; }

    [IndexField("salesperson")]
    public string SalesPerson { get; set; }
  }
}
