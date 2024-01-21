namespace CorporateSite.Feature.Product.DI
{
  using CorporateSite.Feature.Product.Services;
  using Microsoft.Extensions.DependencyInjection;
  using Sitecore.DependencyInjection;

  /// <summary>
  /// Register container class.
  /// </summary>
  public class RegisterContainer : IServicesConfigurator
  {
    /// <summary>
    /// Configure container.
    /// </summary>
    /// <param name="serviceCollection">IServiceCollection object parameter.</param>
    public void Configure(IServiceCollection serviceCollection)
    {
      serviceCollection.AddTransient<IProductService, ProductService>();
    }
  }
}
