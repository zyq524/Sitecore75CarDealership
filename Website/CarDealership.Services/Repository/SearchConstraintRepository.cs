
namespace CarDealership.Services.Repository
{
  using System.Collections.Generic;
  using System.Linq;
  using CarDealership.Services.Model;
  using Sitecore.Data;
  using Sitecore.Data.Items;
  using Sitecore.Services.Core;

  public class SearchConstraintRepository : IRepository<SearchConstraint>
  {
    private readonly Database db = Database.GetDatabase("master");

    public void Add(SearchConstraint entity)
    {
      throw new System.NotImplementedException();
    }

    public void Delete(SearchConstraint entity)
    {
      throw new System.NotImplementedException();
    }

    public bool Exists(SearchConstraint entity)
    {
      throw new System.NotImplementedException();
    }

    public SearchConstraint FindById(string id)
    {
      throw new System.NotImplementedException();
    }

    public IQueryable<SearchConstraint> GetAll()
    {
      var all = db.SelectItems("fast:/sitecore/content/home/data/SearchConstraints//*[@@templatename='SearchConstraint']");
      return this.GetSearchConstraintsFromItems(all);
    }

    private IQueryable<SearchConstraint> GetSearchConstraintsFromItems(IEnumerable<Item> items)
    {
      var searchConstraints = new List<SearchConstraint>();
      foreach (var item in items)
      {
        searchConstraints.Add(new SearchConstraint
        {
          Id = item.ID.ToString(),
          Name = item.Fields["Name"].Value,
          RestUri = item.Fields["Uri"].Value,
        });
      }
      return searchConstraints.AsQueryable();
    }

    public void Update(SearchConstraint entity)
    {
      throw new System.NotImplementedException();
    }
  }
}
