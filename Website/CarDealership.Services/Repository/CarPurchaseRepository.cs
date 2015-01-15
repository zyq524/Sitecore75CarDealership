
namespace CarDealership.Services.Repository
{
  using CarDealership.Services.Helper;
  using CarDealership.Services.Model;
  using CarDealership.Services.Model.ResultItem;
  using Sitecore.ContentSearch;
  using Sitecore.Data;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  public class CarPurchaseRepository : ICarPurchaseRepository
  {
    private readonly string indexName = "cardealership_carpurchases";

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
      using (var context = ContentSearchManager.GetIndex(indexName).CreateSearchContext())
      {
        var carPurchaseItem = context.GetQueryable<CarPurchaseItem>().First(c => c.ItemId == ID.Parse(id));
        return ConverterHelper.GetCarPurchaseFromItem(carPurchaseItem);
      }
    }

    public IQueryable<CarPurchase> GetAll()
    {
      using (var context = ContentSearchManager.GetIndex(indexName).CreateSearchContext())
      {
        var carPurchaseItems = context.GetQueryable<CarPurchaseItem>().ToList();
        return ConverterHelper.GetCarPurchasesFromItems(carPurchaseItems).AsQueryable();
      }
    }

    public IQueryable<CarPurchase> FindByCar(List<string> carIds)
    {
      using (var context = ContentSearchManager.GetIndex(indexName).CreateSearchContext())
      {
        var carPurchaseItems = context.GetQueryable<CarPurchaseItem>().Where(carPurchaseItem => carIds.Contains(carPurchaseItem.Car)).ToList();
        return ConverterHelper.GetCarPurchasesFromItems(carPurchaseItems).AsQueryable();
      }
    }

    public IQueryable<CarPurchase> FindBySalesPerson(List<string> salesPersonIds)
    {
      using (var context = ContentSearchManager.GetIndex(indexName).CreateSearchContext())
      {
        var carPurchaseItems = context.GetQueryable<CarPurchaseItem>().Where(carPurchaseItem => salesPersonIds.Contains(carPurchaseItem.SalesPerson)).ToList();
        return ConverterHelper.GetCarPurchasesFromItems(carPurchaseItems).AsQueryable();
      }
    }

    public void Update(CarPurchase entity)
    {
      throw new NotImplementedException();
    }
  }
}
