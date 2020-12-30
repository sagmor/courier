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
            var filter = Builders<Thread>.Filter.Eq("Id", id);
            var document = collection.Find(filter).First();
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
            var filter = Builders<Thread>.Filter.Eq("Id", updatedThread.Id);
            var update = Builders<Thread>.Update.Set("Subject", updatedThread.Subject)
                                                .Set("Summary", updatedThread.Summary);
            collection.UpdateOne(filter, update);
            return updatedThread;
        }
    }
}