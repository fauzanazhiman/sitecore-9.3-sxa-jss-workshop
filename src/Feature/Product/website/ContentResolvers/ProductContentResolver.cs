namespace CorporateSite.Feature.Product.ContentResolvers
{
  using CorporateSite.Feature.Product.Services;
  using Newtonsoft.Json.Linq;
  using Sitecore.LayoutService.Configuration;
  using Sitecore.LayoutService.ItemRendering.ContentsResolvers;
  using Sitecore.Mvc.Presentation;

  /// <summary>
  /// This is description of ProductContentResolver
  /// </summary>
  public class ProductContentResolver : RenderingContentsResolver
  {
    IProductService productService;


    /// <param name="productService"></param>
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductContentResolver"/> class.
    /// </summary>
    /// <param name="productService"></param>
    public ProductContentResolver(IProductService productService)
    {
      this.productService = productService;
    }

    /// <inheritdoc/>
    public override object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
    {
      var products = this.productService.GetProducts();

      var productJson = new JObject();
      productJson["products"] = JArray.FromObject(products);

      return productJson;
    }
  }
}
