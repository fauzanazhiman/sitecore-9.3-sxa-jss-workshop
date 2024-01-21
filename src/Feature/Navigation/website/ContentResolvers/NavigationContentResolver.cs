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
  public class NavigationContentResolver : RenderingContentsResolver
  {

    private readonly BaseLinkManager linkManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationContentResolver"/> class.
    /// </summary>
    /// <param name="linkManager"></param>
    public NavigationContentResolver(BaseLinkManager linkManager)
    {
      this.linkManager = linkManager;
    }

    /// <inheritdoc/>
    public override object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
    {
      var homeItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);

      var resultJson = new JObject();
      if (homeItem == null)
      {
        resultJson["items"] = null;
      }

      var itemsToAdd = new List<Item>();
      itemsToAdd.Add(homeItem);

      // get level 1 children
      var homeChildrenItems = homeItem.GetChildren();
      itemsToAdd.AddRange(homeChildrenItems);

      resultJson["items"] = new JArray(itemsToAdd.Where(item => item.TemplateID == new Sitecore.Data.ID("{16A37E6F-2299-48BE-8B60-3A1101FC040A}"))
      .Select(item =>
      {
        var procesedItem = this.ProcessItem(item, rendering, renderingConfig);
        procesedItem["url"] = this.linkManager.GetItemUrl(item);

        return procesedItem;
      }).ToArray());

      return resultJson;
    }
  }
}