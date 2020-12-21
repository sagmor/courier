namespace HawkLab.Data.MongoPersistence
{
    using System.Collections.Generic;
    using HawkLab.Data.Core.Persistence;
    using HawkLab.Data.Core.Types;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public class MongoThreadRepository : IThreadRepository
    {
        private const string DatabaseName = "courier";

        private const string CollectionName = "threads";

        private readonly IMongoCollection<Thread> threadsCollection;

        public MongoThreadRepository(IMongoClient mongoClient)
        {
            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            threadsCollection = mongoDatabase.GetCollection<Thread>(CollectionName);
        }

        public Thread GetById(int id)
        {
            var filter = Builders<Thread>.Filter.Eq("_id", id);
            return threadsCollection.Find(filter).First();
        }

        public IEnumerable<Thread> GetThreadsBySubject(string subject = null)
        {
            return threadsCollection.Find(new BsonDocument()).ToList();
        }

        public Thread Add(Thread newThread)
        {
            threadsCollection.InsertOne(newThread);
            return newThread;
        }

        public int Commit()
        {
            return 0;
        }

        public Thread Update(Thread updatedThread)
        {
            throw new System.NotImplementedException();
        }
    }
}
