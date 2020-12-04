namespace HawkLab.Courier.Models.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public class ThreadRepository
    {
        private const string DatabaseName = "courier";
        private const string CollectionName = "threads";
        private IMongoCollection<Thread> threadsCollection;

        public ThreadRepository(IMongoClient mongoClient)
        {
            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            threadsCollection = mongoDatabase.GetCollection<Thread>(CollectionName);
        }

        public async Task<IEnumerable<Thread>> GetThreadsAsync()
        {
            return await threadsCollection.Find(new BsonDocument()).ToListAsync();
        }
    }
}
