namespace CorporateSite.Feature.Product.Tests
{
  using System;
  using CorporateSite.Feature.Product.Services;
  using FluentAssertions;

  using NSubstitute;

  using Sitecore.FakeDb;

  using Xunit;

  /// <summary>
  /// Tests of Product Feature.
  /// </summary>
  public class ProductTests
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductTests"/> class.
    /// </summary>
    public ProductTests()
    {
    }

    [Fact]
    public void TestedMethodName_StateUnderTest_ExpectedBehavior()
    {
      // Arrange
      var productService = new ProductService();

      // Act
      var result = productService.GetProducts();

      // Assert
      result.Count.Should().Be(20);
    }
  }
}
