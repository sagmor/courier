namespace HawkLab.Courier.Models.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System.Linq;
    using HawkLab.Courier.Models;

    public interface IThreadRepository
    {
        IEnumerable<Thread> GetAll();
    }

    public class InMemoryThreadRepository : IThreadRepository
    {

        readonly List<Thread> threads;
        public InMemoryThreadRepository()
        {
            threads = new List<Thread>()
            {
                new Thread { Id = 1, Subject = "December Projects", Summary = "List of projects we want to finish before Christmas" },
                new Thread { Id = 2, Subject = "Hawk Lab Ideas", Summary = "List of projects we want to finish before Christmas" },
                new Thread { Id = 3, Subject = "Home Renovation", Summary = "List of projects we want to finish before Christmas" },
                new Thread { Id = 4, Subject = "2021 Chile Trip", Summary = "List of projects we want to finish before Christmas" },
            };
        }
        public IEnumerable<Thread> GetAll()
        {
            return from t in threads
                   orderby t.Subject
                   select t;
        }
    }
}
