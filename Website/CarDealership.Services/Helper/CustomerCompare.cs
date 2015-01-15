
namespace CarDealership.Services.Helper
{
  using System.Collections.Generic;
  using CarDealership.Services.Model;

  public class CustomerComparer : IEqualityComparer<Customer>
  {
    public bool Equals(Customer x, Customer y)
    {
      return x.Id == y.Id;
    }


    public int GetHashCode(Customer obj)
    {
      return obj.Id.GetHashCode();
    }
  }
}
