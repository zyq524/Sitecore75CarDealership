
namespace CarDealership.Services.Helper
{
  using CarDealership.Services.Model;
  using CarDealership.Services.Model.ResultItem;
  using System.Collections.Generic;
  using System.Linq;
  using Sitecore.Diagnostics;

  public static class ConverterHelper
  {
    public static Customer GetCustomerFromItem(CustomerItem item)
    {
      return new Customer
      {
        Id = item.ItemId.ToString(),
        CustomerName = item.CustomerName,
        Surname = item.Surname,
        Age = item.Age,
        HouseNumber = item.HouseNumber,
        Street = item.Street,
        Town = item.Town,
        ZipCode = item.ZipCode,
        Country = item.Country,
        Created = item.Created
      };
    }

    public static Car GetCarFromItem(CarItem item)
    {
      Assert.ArgumentNotNull(item, "item");

      return new Car
      {
        Id = item.ItemId.ToString(),
        Make = item.Make,
        Model = item.Model,
        Color = item.Color,
        Extras = item.Extras,
        RecommendPrice = item.RecommendPrice
      };
    }

    public static SalesPerson GetSalesPersonFromItem(SalesPersonItem item)
    {
      Assert.ArgumentNotNull(item, "item");

      return new SalesPerson
      {
        Id = item.ItemId.ToString(),
        SalesPersonName = item.SalesPersonName,
        JobTitle = item.JobTitle,
        Salary = item.Salary,
        Address = item.Address,
      };
    }

    public static CarPurchase GetCarPurchaseFromItem(CarPurchaseItem item)
    {
      Assert.ArgumentNotNull(item, "item");

      return new CarPurchase
      {
        Id = item.ItemId.ToString(),
        Customer = item.Customer,
        Car = item.Car,
        OrderDate = item.OrderDate,
        PricePaid = item.PricePaid,
        SalesPerson = item.SalesPerson,
      };
    }

    public static IEnumerable<Customer> GetCustomersFromItems(IEnumerable<CustomerItem> items)
    {
      Assert.ArgumentNotNull(items, "items");

      return items.Select(GetCustomerFromItem);
    }

    public static IEnumerable<Car> GetCarsFromItems(IEnumerable<CarItem> items)
    {
      Assert.ArgumentNotNull(items, "items");

      return items.Select(GetCarFromItem);
    }

    public static IEnumerable<SalesPerson> GetSalesPersonsFromItems(IEnumerable<SalesPersonItem> items)
    {
      Assert.ArgumentNotNull(items, "items");

      return items.Select(GetSalesPersonFromItem);
    }

    public static IEnumerable<CarPurchase> GetCarPurchasesFromItems(IEnumerable<CarPurchaseItem> items)
    {
      Assert.ArgumentNotNull(items, "items");

      return items.Select(GetCarPurchaseFromItem);
    }

    public static IEnumerable<SearchConstraint> GetSearchConstraintsFromItems(IEnumerable<SearchConstraintItem> items)
    {
      Assert.ArgumentNotNull(items, "items");

      return items.Select(item => new SearchConstraint
      {
        Id = item.ItemId.ToString(),
        SearchConstraintName = item.SearchConstraintName,
        RestUri = item.RestUri
      });
    }
  }
}
