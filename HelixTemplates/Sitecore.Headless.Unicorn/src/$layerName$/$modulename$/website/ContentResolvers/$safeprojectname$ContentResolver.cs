namespace $modulenamespace$.ContentResolvers
{
  using Sitecore.LayoutService.Configuration;
  using Sitecore.LayoutService.ItemRendering.ContentsResolvers;
  using Sitecore.Mvc.Presentation;

  /// <summary>
  /// This is description of $safeprojectname$ContentResolver
  /// </summary>
  public class $safeprojectname$ContentResolver : RenderingContentsResolver
  {
    /// <inheritdoc/>
    public override object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
    {
      var contextItem = this.GetContextItem(rendering, renderingConfig);
      if (contextItem == null)
      {
        return null;
      }

      var contextItemJson = this.ProcessItem(contextItem, rendering, renderingConfig);

      // put custom resolution here

      return contextItemJson;
    }
  }
}
