namespace CorporateSite.Feature.Navigation.ContentResolvers
{
  using System.Collections.Generic;
  using System.Linq;
  using Newtonsoft.Json.Linq;
  using Sitecore.Abstractions;
  using Sitecore.Data.Items;
  using Sitecore.LayoutService.Configuration;
  using Sitecore.LayoutService.ItemRendering.ContentsResolvers;
  using Sitecore.Mvc.Presentation;

  /// <summary>
  /// Content resolver for Breadcrumbs component
  /// </summary>
  public class BreadcrumbsContentResolver : RenderingContentsResolver
  {

    private readonly BaseLinkManager linkManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="BreadcrumbsContentResolver"/> class.
    /// </summary>
    /// <param name="linkManager"></param>
    public BreadcrumbsContentResolver(BaseLinkManager linkManager)
    {
      this.linkManager = linkManager;
    }

    /// <inheritdoc/>
    public override object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
    {
      var homeItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);
      var contextItem = Sitecore.Context.Item;

      var resultJson = new JObject();
      if (contextItem == null || homeItem == null)
      {
        resultJson["items"] = null;
      }

      // build breadcrumb items by looking up parent item
      var breadcrumbItems = new List<Item>();
      var iteratingItem = contextItem;
      while (iteratingItem.ID.ToString() != homeItem.ID.ToString())
      {
        breadcrumbItems.Add(iteratingItem);
        iteratingItem = iteratingItem.Parent;
      }
      breadcrumbItems.Add(homeItem);

      resultJson["items"] = new JArray(breadcrumbItems.Select(item =>
      {
        var procesedItem = this.ProcessItem(item, rendering, renderingConfig);
        procesedItem["url"] = this.linkManager.GetItemUrl(item);

        return procesedItem;
      }).ToArray());

      return resultJson;
    }
  }
}