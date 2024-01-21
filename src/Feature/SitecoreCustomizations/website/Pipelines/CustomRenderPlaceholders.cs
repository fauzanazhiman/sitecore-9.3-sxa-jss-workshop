/// <summary>
/// Split dynamic placeholders within one rendering into separate json nodes in LayoutService.
/// </summary>
namespace CorporateSite.Feature.SitecoreCustomizations.Pipelines
{
  using System.Collections.Generic;

  using Sitecore.LayoutService.Configuration;
  using Sitecore.LayoutService.ItemRendering;
  using Sitecore.LayoutService.Presentation.Pipelines.RenderJsonRendering;

  /// <summary>
  /// Rendering parameters field name.
  /// </summary>
  public class CustomRenderPlaceholders : RenderPlaceholders
  {
    /// <summary>
    /// Rendering parameters field name.
    /// </summary>
    protected const string SectionColumnParameterName = "Number of Columns";

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomRenderPlaceholders"/> class.
    /// </summary>
    /// <param name="configuration">Configuration.</param>
    public CustomRenderPlaceholders(IConfiguration configuration)
      : base(configuration)
    {
    }

    /// <inheritdoc/>
    protected override IList<RenderedPlaceholder> GetRenderedPlaceholders(RenderJsonRenderingArgs args)
    {
      var placeholders = base.GetRenderedPlaceholders(args);

      if (args.Rendering?.Parameters != null && (args.Rendering?.Parameters?.Contains(SectionColumnParameterName) == true))
      {
        return this.SplitPlaceholders(placeholders);
      }

      return placeholders;
    }

    /// <summary>
    /// Split dynamic placeholders within one rendering into separate json nodes.
    /// </summary>
    /// <param name="placeholders">Placeholders list.</param>
    /// <returns>Splitted placeholders list.</returns>
    protected virtual IList<RenderedPlaceholder> SplitPlaceholders(IList<RenderedPlaceholder> placeholders)
    {
      int i = 1;
      foreach (var pl in placeholders)
      {
        pl.Name = $"{pl.Name}-{i}";
        i++;
      }

      return placeholders;
    }
  }
}
