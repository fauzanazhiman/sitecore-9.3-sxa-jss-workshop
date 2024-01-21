namespace CorporateSite.Feature.Product.Services
{
  using CorporateSite.Feature.Product.Models;
  using System.Collections.Generic;

  public interface IProductService
  {
    List<Product> GetProducts();
  }
}
