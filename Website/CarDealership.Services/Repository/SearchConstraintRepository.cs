
namespace CarDealership.Services.Repository
{
  using CarDealership.Services.Helper;
  using CarDealership.Services.Model;
  using CarDealership.Services.Model.ResultItem;
  using Sitecore.ContentSearch;
  using System.Linq;
  using Sitecore.Diagnostics;

  public class SearchConstraintRepository : ISearchConstraintRepository
  {
    private readonly ISearchIndex searchIndex;

    public SearchConstraintRepository(ISearchIndex searchIndex)
    {
      Assert.ArgumentNotNull(searchIndex, "searchIndex");

      this.searchIndex = searchIndex;
    }

    public SearchConstraintRepository()
      : this(ContentSearchManager.GetIndex("cardealership_search_constraints"))
    {

    }

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
      using (var context = this.searchIndex.CreateSearchContext())
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
