
namespace CarDealership.Services.Model.ResultItem
{
  using Sitecore.ContentSearch;
  using Sitecore.ContentSearch.SearchTypes;

  public class SearchConstraintItem : SearchResultItem
  {
    [IndexField("searchconstraintname")]
    public string SearchConstraintName { get; set; }

    [IndexField("resturi")]
    public string RestUri { get; set; }
  }
}
