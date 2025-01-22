using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.StatisticServices.Abstract;
using MultiShop.Catalog.Settings.Abstract;

namespace MultiShop.Catalog.Services.StatisticServices.Concrete
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Brand> _brandCollection;

        public StatisticService(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
        }

        public async Task<long> GetCategoryCount()
        {
            return await _categoryCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
        }

        public async Task<long> GetProductCount()
        {
            return await _productCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);
        }

        public async Task<long> GetBrandCount()
        {
            return await _brandCollection.CountDocumentsAsync(FilterDefinition<Brand>.Empty);
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            var products = await _productCollection.Find(FilterDefinition<Product>.Empty).ToListAsync();
            var prices = products
                .Select(p => p.ProductPrice)
                .Where(price => price >= 0);

            if (prices.Any())
            {
                return prices.Average();
            }
            return 0m;
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Descending(x => x.ProductPrice);
            // Sadece ProductName alanını dahil ediyoruz
            var projection = Builders<Product>.Projection.Include(y => y.ProductName);
            var product = await _productCollection.Find(filter)
                .Sort(sort)
                .Project(projection)
                .FirstOrDefaultAsync();
            // ProductName değerini döndürüyoruz
            return product.GetValue("ProductName").AsString;
        }

        public async Task<string> GetMinPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Ascending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y =>y.ProductName);
            var product = await _productCollection.Find(filter)
                .Sort(sort)
                .Project(projection)
                .FirstOrDefaultAsync();
            return product.GetValue("ProductName").AsString;
        }
    }
}
