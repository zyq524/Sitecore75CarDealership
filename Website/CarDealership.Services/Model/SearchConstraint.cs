
namespace CarDealership.Services.Model
{
  using Sitecore.Services.Core.Model;
  using System;

  public class SearchConstraint : EntityIdentity
  {
    public string SearchConstraintName { get; set; }

    public string RestUri { get; set; }

    public DateTime Created { get; set; }
  }
}
