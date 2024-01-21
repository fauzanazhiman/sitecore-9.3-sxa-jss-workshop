namespace CorporateSite.Feature.Product.Services
{
  using Newtonsoft.Json;
  using RestSharp;
  using Sitecore.Configuration;
  using System.Collections.Generic;

  public class ProductService : IProductService
  {
    public static List<Models.Product> CachedProducts;

    public List<Models.Product> GetProducts()
    {
      if(CachedProducts == null)
      {
        CachedProducts = this.GetProductsFromApi();
      }

      return CachedProducts;
    }

    public List<Models.Product> GetProductsFromApi()
    {
      string url = Settings.GetSetting("ProductApiUrl");

      // send GET request with RestSharp
      var client = new RestClient(url);
      var request = new RestRequest();
      var response = client.ExecuteGet(request);

      // deserialize json string response to JsonNode object
      var data = JsonConvert.DeserializeObject<List<Models.Product>>(response.Content);
      return data;
    }
  }
}
