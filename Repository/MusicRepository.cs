
// MusicRepository.cs
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using MusicAPI.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace MusicAPI.Repository
{
    // MusicRepository.cs
    public class MusicRepository
    {
        private readonly IDynamoDBContext _dynamoDbContext;

        public MusicRepository(IDynamoDBContext dynamoDbContext)
        {
            _dynamoDbContext = dynamoDbContext;
        }

        public async Task<List<MusicEntity>> GetAllMusic()
        {
            var scanConditions = new List<ScanCondition>();
            return await _dynamoDbContext.ScanAsync<MusicEntity>(scanConditions).GetRemainingAsync();
        }

        public async Task<MusicEntity> GetMusicById(string id)
        {
            return await _dynamoDbContext.LoadAsync<MusicEntity>(id);
        }

        public async Task CreateMusic(MusicEntity music)
        {
            await _dynamoDbContext.SaveAsync(music);
        }

        public async Task UpdateMusic(MusicEntity music)
        {
            await _dynamoDbContext.SaveAsync(music);
        }

        public async Task DeleteMusic(string id)
        {
            var music = await _dynamoDbContext.LoadAsync<MusicEntity>(id);
            if (music != null)
            {
                await _dynamoDbContext.DeleteAsync(music);
            }
        }
    }

}
