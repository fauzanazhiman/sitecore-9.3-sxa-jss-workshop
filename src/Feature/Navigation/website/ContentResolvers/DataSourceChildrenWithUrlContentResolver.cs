namespace CorporateSite.Feature.Navigation.ContentResolvers
{
  using Newtonsoft.Json.Linq;
  using Sitecore.Abstractions;
  using Sitecore.LayoutService.Configuration;
  using Sitecore.LayoutService.ItemRendering.ContentsResolvers;
  using Sitecore.Mvc.Presentation;
  using System.Linq;

  /// <summary>
  /// This is description of DataSourceChildrenWithUrlContentResolver
  /// </summary>
  public class DataSourceChildrenWithUrlContentResolver : RenderingContentsResolver
  {
    private readonly BaseLinkManager linkManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="DataSourceChildrenWithUrlContentResolver"/> class.
    /// </summary>
    /// <param name="linkManager"></param>
    public DataSourceChildrenWithUrlContentResolver(BaseLinkManager linkManager)
    {
      this.linkManager = linkManager;
    }

    /// <inheritdoc/>
    public override object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
    {
      var contextItem = this.GetContextItem(rendering, renderingConfig);
      var resultJson = new JObject();
      if (contextItem == null)
      {
        resultJson["items"] = null;
      }

      resultJson["items"] = new JArray(contextItem.GetChildren().Select(item =>
      {
        var procesedItem = this.ProcessItem(item, rendering, renderingConfig);
        procesedItem["url"] = this.linkManager.GetItemUrl(item);

        return procesedItem;
      }).ToArray());
        
      return resultJson;
    }
  }
}
