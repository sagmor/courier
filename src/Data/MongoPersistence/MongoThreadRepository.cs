using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using HawkLab.Data.Core.Persistence;
using HawkLab.Data.Core.Types;
using Microsoft.VisualBasic;
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
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("courier");
            var collection = database.GetCollection<Thread>("threads");

            var documents = collection.Find(new BsonDocument()).ToList();
            var document = documents.SingleOrDefault(t => t.Id == id);
            
            // Failing for some reason
            // var filter = Builders<Thread>.Filter.Eq("Id", id);
            // var document = collection.Find(filter).First();
            // var document = collection.Find(t => t.Id == id).Single();

            return document;
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
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("courier");
            var collection = database.GetCollection<Thread>("threads");
            // collection.UpdateOne(updatedThread);

            var result = collection.ReplaceOne(
                new BsonDocument("_id", updatedThread.Id), 
                updatedThread,
                new UpdateOptions { IsUpsert = true});
            return updatedThread;
            // throw new System.NotImplementedException();
        }
    }


}
