namespace CorporateSite.Feature.SitecoreCustomizations.Pipelines
{
  using Sitecore.LayoutService.Placeholders;
  using Sitecore.Mvc.Presentation;
  using Sitecore.Shell.Web.UI.WebControls;

  /// <summary>
  /// Resolve placeholder with sufix within rendering.
  /// </summary>
  public class CustomPlaceholdersResolver : DynamicPlaceholdersResolver
  {
    /// <summary>
    /// Rendering parameters field name.
    /// </summary>
    protected const string SectionColumnParameterName = "Number of Columns";

    /// <inheritdoc/>
    protected override int GetPlaceholderCount(Rendering ownerRendering, PlaceholderItem placeholderItem)
    {
      if (ownerRendering.Parameters.Contains(SectionColumnParameterName))
      {
        if (int.TryParse(ownerRendering.Parameters[SectionColumnParameterName], out int placeholderCount))
        {
          return placeholderCount;
        }
      }

      return 1;
    }
  }
}
