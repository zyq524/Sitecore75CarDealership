
namespace CarDealership.Services.Model.ResultItem
{
  using System;
  using Sitecore.ContentSearch;
  using Sitecore.ContentSearch.SearchTypes;

  public class CustomerItem : SearchResultItem
  {
    [IndexField("customername")]
    public string CustomerName { get; set; }

    [IndexField("surname")]
    public string Surname { get; set; }

    [IndexField("age")]
    public int Age { get; set; }

    [IndexField("housenumber")]
    public int HouseNumber { get; set; }

    [IndexField("street")]
    public string Street { get; set; }

    [IndexField("town")]
    public string Town { get; set; }

    [IndexField("zipcode")]
    public string ZipCode { get; set; }

    [IndexField("country")]
    public string Country { get; set; }

    [IndexField("__Created")]
    public DateTime Created { get; set; }
  }
}
