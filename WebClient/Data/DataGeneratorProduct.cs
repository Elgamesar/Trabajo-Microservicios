using Bogus;
using WebClient.DTOs;

namespace WebClient.Data
{
    public class DataGeneratorProduct
    {
        Faker<CreateProductDto> _productFaker;
        public DataGeneratorProduct()
        {
            //para que siempre se inserten los mismos datos
            Randomizer.Seed = new Random(1234);

            _productFaker = new Faker<CreateProductDto>()
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price(1, 1000)))
                .RuleFor(p => p.Stock, f => f.Random.Int(0, 100));
        }
        public CreateProductDto GenerateProduct()
        {
            return _productFaker.Generate();
        }
    }
}