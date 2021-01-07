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
    public class MongoMessageRepository : IMessageRepository
    {
        
        public Message Add(Message newMessage, Thread aThread)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("courier");
            var collection = database.GetCollection<Thread>("threads");
            var filter = Builders<Thread>
                .Filter.Eq(t => t.Id, aThread.Id);
            var update = Builders<Thread>.Update
            .Push<Message>(t => t.Messages, newMessage);
            collection.FindOneAndUpdate(filter, update);
            return newMessage;
        }

        public int Commit()
        {
            return 0;
        }

        // public Message GetById(Guid id)
        // {  

        // }

        public Message Update(Message updatedMessage)
        {
             throw new NotImplementedException();
        }

        public void Delete(Message theMessage)
        {
             throw new NotImplementedException();
        }
    }
}