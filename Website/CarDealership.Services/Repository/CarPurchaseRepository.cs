
namespace CarDealership.Services.Repository
{
  using CarDealership.Services.Helper;
  using CarDealership.Services.Model;
  using CarDealership.Services.Model.ResultItem;
  using Sitecore.ContentSearch;
  using Sitecore.Data;
  using Sitecore.Diagnostics;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  public class CarPurchaseRepository : ICarPurchaseRepository
  {
    private readonly ISearchIndex searchIndex;

    public CarPurchaseRepository(ISearchIndex searchIndex)
    {
      Assert.ArgumentNotNull(searchIndex, "searchIndex");

      this.searchIndex = searchIndex;
    }

    public CarPurchaseRepository()
      : this(ContentSearchManager.GetIndex("cardealership_carpurchases"))
    {
      
    }

    public void Add(CarPurchase entity)
    {
      throw new NotImplementedException();
    }

    public void Delete(CarPurchase entity)
    {
      throw new NotImplementedException();
    }

    public bool Exists(CarPurchase entity)
    {
      throw new NotImplementedException();
    }

    public CarPurchase FindById(string id)
    {
      Assert.ArgumentNotNullOrEmpty(id, "id");

      using (var context = this.searchIndex.CreateSearchContext())
      {
        var carPurchaseItem = context.GetQueryable<CarPurchaseItem>().FirstOrDefault(c => c.ItemId == ID.Parse(id));
        return carPurchaseItem == null ? null : ConverterHelper.GetCarPurchaseFromItem(carPurchaseItem);
      }
    }

    public IQueryable<CarPurchase> GetAll()
    {
      using (var context = this.searchIndex.CreateSearchContext())
      {
        var carPurchaseItems = context.GetQueryable<CarPurchaseItem>().ToList();
        return ConverterHelper.GetCarPurchasesFromItems(carPurchaseItems).AsQueryable();
      }
    }

    public IQueryable<CarPurchase> FindByCar(List<string> carIds)
    {
      Assert.ArgumentNotNull(carIds, "carIds");
      if (carIds.Count == 0)
      {
        return new List<CarPurchase>().AsQueryable();
      }

      using (var context = this.searchIndex.CreateSearchContext())
      {
        var carPurchaseItems = context.GetQueryable<CarPurchaseItem>().Where(carPurchaseItem => carIds.Contains(carPurchaseItem.Car)).ToList();
        return ConverterHelper.GetCarPurchasesFromItems(carPurchaseItems).AsQueryable();
      }
    }

    public IQueryable<CarPurchase> FindBySalesPerson(List<string> salesPersonIds)
    {
      Assert.ArgumentNotNull(salesPersonIds, "salesPersonIds");
      if (salesPersonIds.Count == 0)
      {
        return new List<CarPurchase>().AsQueryable();
      }

      using (var context = this.searchIndex.CreateSearchContext())
      {
        var carPurchaseItems = context.GetQueryable<CarPurchaseItem>().Where(carPurchaseItem => salesPersonIds.Contains(carPurchaseItem.SalesPerson)).ToList();
        return ConverterHelper.GetCarPurchasesFromItems(carPurchaseItems).AsQueryable();
      }
    }

    public IQueryable<CarPurchase> FindByCustomer(string customerId)
    {
      Assert.ArgumentNotNullOrEmpty(customerId, "customerId");

      using (var context = this.searchIndex.CreateSearchContext())
      {
        var carPurchaseItems = context.GetQueryable<CarPurchaseItem>().Where(carPurchaseItem => carPurchaseItem.Customer == customerId).ToList();
        return ConverterHelper.GetCarPurchasesFromItems(carPurchaseItems).AsQueryable();
      }
    }

    public void Update(CarPurchase entity)
    {
      throw new NotImplementedException();
    }
  }
}
