
namespace CarDealership.Services.Repository
{
  using System;
  using System.Linq;
  using CarDealership.Services.Helper;
  using CarDealership.Services.Model;
  using CarDealership.Services.Model.ResultItem;
  using Sitecore.ContentSearch;
  using Sitecore.Data;
  using Sitecore.Diagnostics;

  public class SalesPersonRepository : ISalesPersonRepository
  {
    private readonly string indexName = "cardealership_salespersons";

    public void Add(SalesPerson entity)
    {
      throw new NotImplementedException();
    }

    public void Delete(SalesPerson entity)
    {
      throw new NotImplementedException();
    }

    public bool Exists(SalesPerson entity)
    {
      throw new NotImplementedException();
    }

    public SalesPerson FindById(string id)
    {
      Assert.ArgumentNotNullOrEmpty(id, "id");
      using (var context = ContentSearchManager.GetIndex(indexName).CreateSearchContext())
      {
        var salesPersonItem = context.GetQueryable<SalesPersonItem>().First(s => s.ItemId == ID.Parse(id));
        return ConverterHelper.GetSalesPersonFromItem(salesPersonItem);
      }
    }

    public IQueryable<SalesPerson> GetAll()
    {
      using (var context = ContentSearchManager.GetIndex(indexName).CreateSearchContext())
      {
        var salesPersonItems = context.GetQueryable<SalesPersonItem>().ToList();
        return ConverterHelper.GetSalesPersonsFromItems(salesPersonItems).AsQueryable();
      }
    }

    public IQueryable<SalesPerson> FindByName(string name)
    {
      Assert.ArgumentNotNullOrEmpty(name, "name");

      using (var context = ContentSearchManager.GetIndex(indexName).CreateSearchContext())
      {
        var salesPersonItems = context.GetQueryable<SalesPersonItem>().Where(s => string.Equals(name, s.SalesPersonName, StringComparison.InvariantCultureIgnoreCase)).ToList();
        return ConverterHelper.GetSalesPersonsFromItems(salesPersonItems).AsQueryable();
      }
    }

    public void Update(SalesPerson entity)
    {
      throw new NotImplementedException();
    }
  }
}
