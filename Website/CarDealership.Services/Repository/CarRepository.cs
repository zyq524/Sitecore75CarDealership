
namespace CarDealership.Services.Repository
{
  using CarDealership.Services.Helper;
  using CarDealership.Services.Model;
  using CarDealership.Services.Model.ResultItem;
  using Sitecore.ContentSearch;
  using Sitecore.Data;
  using System;
  using System.Linq;
  using Sitecore.Diagnostics;

  public class CarRepository : ICarRepository
  {
    private readonly ISearchIndex searchIndex;

    public CarRepository(ISearchIndex searchIndex)
    {
      Assert.ArgumentNotNull(searchIndex, "searchIndex");

      this.searchIndex = searchIndex;
    }

    public CarRepository()
      : this(ContentSearchManager.GetIndex("cardealership_cars"))
    {
      
    }

    public void Add(Car entity)
    {
      throw new System.NotImplementedException();
    }

    public void Delete(Car entity)
    {
      throw new System.NotImplementedException();
    }

    public bool Exists(Car entity)
    {
      throw new System.NotImplementedException();
    }

    public Car FindById(string id)
    {
      Assert.ArgumentNotNullOrEmpty(id, "id");

      using (var context = this.searchIndex.CreateSearchContext())
      {
        var carItem = context.GetQueryable<CarItem>().FirstOrDefault(c => c.ItemId == ID.Parse(id));
        return carItem == null ? null : ConverterHelper.GetCarFromItem(carItem);
      }
    }

    public IQueryable<Car> GetAll()
    {
      using (var context = this.searchIndex.CreateSearchContext())
      {
        var carItems = context.GetQueryable<CarItem>().ToList();
        return ConverterHelper.GetCarsFromItems(carItems).AsQueryable();
      }
    }

    public void Update(Car entity)
    {
      throw new System.NotImplementedException();
    }

    public IQueryable<Car> FindByMake(string make)
    {
      Assert.ArgumentNotNullOrEmpty(make, "make");

      if (string.IsNullOrEmpty(make))
      {
        throw new ArgumentNullException("make");
      }

      using (var context = this.searchIndex.CreateSearchContext())
      {
        var carItems = context.GetQueryable<CarItem>().Where(c => string.Equals(make, c.Make, StringComparison.InvariantCultureIgnoreCase)).ToList();
        return ConverterHelper.GetCarsFromItems(carItems).AsQueryable();
      }
    }

    public IQueryable<Car> FindByModel(string model)
    {
      Assert.ArgumentNotNullOrEmpty(model, "model");

      using (var context = this.searchIndex.CreateSearchContext())
      {
        var carItems = context.GetQueryable<CarItem>().Where(c => string.Equals(model, c.Model, StringComparison.InvariantCultureIgnoreCase)).ToList();
        return ConverterHelper.GetCarsFromItems(carItems).AsQueryable();
      }
    }
  }
}
