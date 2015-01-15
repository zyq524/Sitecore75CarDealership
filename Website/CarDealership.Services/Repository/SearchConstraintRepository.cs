
namespace CarDealership.Services.Repository
{
  using CarDealership.Services.Helper;
  using CarDealership.Services.Model;
  using CarDealership.Services.Model.ResultItem;
  using Sitecore.ContentSearch;
  using System.Linq;

  public class SearchConstraintRepository : ISearchConstraintRepository
  {
    private readonly string indexName = "cardealership_search_constraints";

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
      using (var context = ContentSearchManager.GetIndex(indexName).CreateSearchContext())
      {
        var searchItems = context.GetQueryable<SearchConstraintItem>().ToList();
        return ConverterHelper.GetSearchConstraintsFromItems(searchItems).AsQueryable(); 
      }
    }

    public void Update(SearchConstraint entity)
    {
      throw new System.NotImplementedException();
    }
  }
}
