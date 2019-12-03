using DevGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DevGames.Services
{
    public class GameService
    {
        private readonly IMongoCollection<Games>  _games;

        public GameService(IGamesstoreDatabaseSettings _bd)
        {
            var client = new MongoClient(_bd.ConnectionString);
            var database = client.GetDatabase(_bd.DatabaseName);
            _games = database.GetCollection<Games>(_bd.GamesCollectionName);
        }

        public async Task<List<Games>> Get()
        {
            return await _games.Find(game => true).ToListAsync();
        }

        public async Task<Games> GetById(string id)
        {
            return await _games.Find(game => game.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Games> Create(Games game)
        {
             await _games.InsertOneAsync(game);
            return game;
        }


    }
}
