
namespace CarDealership.Serives.Test.Repository
{
  using System.Collections.Generic;
  using System.Linq;
  using CarDealership.Services.Model.ResultItem;
  using CarDealership.Services.Repository;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Moq;
  using Sitecore.ContentSearch;
  using Sitecore.ContentSearch.Security;
  using Sitecore.Data;

  [TestClass]
  public class SearchConstraintRepositoryTest
  {
    private Mock<ISearchIndex> mockSearchIndex;
    private Mock<IProviderSearchContext> mockSearchContext;

    private ID searchConstraintId1, searchConstraintId2, searchConstraintId3;

    private List<SearchConstraintItem> searchConstraintItems;

    [TestInitialize]
    public void Setup()
    {
      this.mockSearchIndex = new Mock<ISearchIndex>();
      this.mockSearchContext = new Mock<IProviderSearchContext>();
      this.mockSearchIndex.Setup(i => i.CreateSearchContext(SearchSecurityOptions.EnableSecurityCheck)).Returns(this.mockSearchContext.Object);

      this.searchConstraintId1 = ID.NewID;
      this.searchConstraintId2 = ID.NewID;
      this.searchConstraintId3 = ID.NewID;

      this.searchConstraintItems = new List<SearchConstraintItem>
      {
        new SearchConstraintItem
        {
          ItemId = this.searchConstraintId1
        },
        new SearchConstraintItem
        {
          ItemId = this.searchConstraintId2
        },
        new SearchConstraintItem
        {
          ItemId = this.searchConstraintId3
        }
      };
    }

    [TestMethod]
    public void GetAll_ShouldReturnAllSearchConstraints()
    {
      // Arrange
      this.mockSearchContext.Setup(s => s.GetQueryable<SearchConstraintItem>()).Returns(this.searchConstraintItems.AsQueryable);

      // Act
      var searchConstraintRepository = new SearchConstraintRepository(this.mockSearchIndex.Object);
      var result = searchConstraintRepository.GetAll();

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(3, result.Count());
    }
  }
}
