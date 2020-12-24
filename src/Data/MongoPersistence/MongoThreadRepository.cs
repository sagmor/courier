using System;
using System.Collections.Generic;
using System.Linq;
using HawkLab.Data.Core.Persistence;
using HawkLab.Data.Core.Types;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HawkLab.Data.MongoPersistence
{
    public class MongoThreadRepository : IThreadRepository
    {
        public Thread Add(Thread newThread)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("courier");
            var collection = database.GetCollection<Thread>("threads");
            collection.InsertOne(newThread);
            return newThread;
        
        }

        public int Commit()
        {
            return 0;
        }

        public Thread GetById(Guid id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Thread> GetThreadsBySubject(string subject = null)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("courier");
            var collection = database.GetCollection<Thread>("threads");
            var documents = collection.Find(new BsonDocument()).ToList();
            return documents;
        }

        public Thread Update(Thread updatedThread)
        {
            throw new System.NotImplementedException();
        }
    }


}
