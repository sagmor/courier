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
        public Message Add(Message newMessage)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("courier");
            var collection = database.GetCollection<Message>("messages");
            collection.InsertOne(newMessage);
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