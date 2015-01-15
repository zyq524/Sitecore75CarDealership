
namespace CarDealership.Services.Model.ResultItem
{
  using Sitecore.ContentSearch;
  using Sitecore.ContentSearch.SearchTypes;

  public class CarItem : SearchResultItem
  {
    [IndexField("make")]
    public string Make { get; set; }

    [IndexField("model")]
    public string Model { get; set; }

    [IndexField("color")]
    public string Color { get; set; }

    [IndexField("extras")]
    public string Extras { get; set; }

    [IndexField("recommendprice")]
    public string RecommendPrice { get; set; }
  }
}
