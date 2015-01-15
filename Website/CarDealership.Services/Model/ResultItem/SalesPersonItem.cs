
namespace CarDealership.Services.Model.ResultItem
{
  using Sitecore.ContentSearch;
  using Sitecore.ContentSearch.SearchTypes;

  public class SalesPersonItem : SearchResultItem
  {
    [IndexField("salespersonname")]
    public string SalesPersonName { get; set; }

    [IndexField("jobtitle")]
    public string JobTitle { get; set; }

    [IndexField("address")]
    public string Address { get; set; }

    [IndexField("salary")]
    public string Salary { get; set; }
  }
}
