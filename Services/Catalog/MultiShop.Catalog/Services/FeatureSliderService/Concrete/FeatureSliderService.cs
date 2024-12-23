using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.FeatureSliderService.Abstract;
using MultiShop.Catalog.Settings.Abstract;

namespace MultiShop.Catalog.Services.FeatureSliderService.Concrete
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;
        private readonly IMapper _mapper;

        public FeatureSliderService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _featureSliderCollection = database.GetCollection<FeatureSlider>(_databaseSettings.FeatureSliderCollectionName);
            _mapper = mapper;
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var fetureSlider = await _featureSliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureSliderDto>>(fetureSlider);
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var value = _mapper.Map<FeatureSlider>(createFeatureSliderDto);
            await _featureSliderCollection.InsertOneAsync(value);
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var value = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
            await _featureSliderCollection.FindOneAndReplaceAsync(x =>
                x.FeatureSliderID == updateFeatureSliderDto.FeatureSliderID, value);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _featureSliderCollection.FindOneAndDeleteAsync(x => x.FeatureSliderID == id);

        }

        public async Task<GetByIdFeatureSliderDto> GetFeatureSliderByIdAsync(string id)
        {
            var value = await _featureSliderCollection.Find(x => x.FeatureSliderID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeatureSliderDto>(value);
        }

        public async Task FeatureSliderChangeStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task FeatureSliderChangeStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }
    }
}
