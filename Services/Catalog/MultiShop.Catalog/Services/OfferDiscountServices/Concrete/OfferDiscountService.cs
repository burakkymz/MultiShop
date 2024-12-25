using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.OfferDiscountServices.Abstract;
using MultiShop.Catalog.Settings.Abstract;

namespace MultiShop.Catalog.Services.OfferDiscountServices.Concrete
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly IMongoCollection<OfferDiscount> _offerDiscountCollection;
        private readonly IMapper _mapper;

        public OfferDiscountService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _offerDiscountCollection = database.GetCollection<OfferDiscount>(_databaseSettings.OfferDiscountCollectionName);
            _mapper = mapper;
        }

        public async Task<List<ResultOfferDiscountDto>> GettAllOfferDiscountAsync()
        {
            var values = await _offerDiscountCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultOfferDiscountDto>>(values);
        }

        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            var value = _mapper.Map<OfferDiscount>(createOfferDiscountDto);
            await _offerDiscountCollection.InsertOneAsync(value);
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            var value = _mapper.Map<OfferDiscount>(updateOfferDiscountDto);
            await _offerDiscountCollection.FindOneAndReplaceAsync(x =>
                x.OfferDiscountId == updateOfferDiscountDto.OfferDiscountId, value);
        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _offerDiscountCollection.DeleteOneAsync(x => x.OfferDiscountId == id);
        }

        public async Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
        {
            var values = await _offerDiscountCollection.Find(x => x.OfferDiscountId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdOfferDiscountDto>(values);
        }
    }
}
