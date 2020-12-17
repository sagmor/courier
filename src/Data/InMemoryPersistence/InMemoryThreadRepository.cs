using System.Collections.Generic;
using System.Linq;
using HawkLab.Data.Core.Persistence;
using HawkLab.Data.Core.Types;


namespace HawkLab.Data.InMemoryPersistence
{
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

        public Thread GetById(int id)
        {
            return threads.SingleOrDefault(t => t.Id == id);
        }

        public Thread Add(Thread newThread)
        {
            threads.Add(newThread);
            newThread.Id = threads.Max(r => r.Id) + 1;
            return newThread;
        }


        public Thread Update(Thread updatedThread)
        {
            var thread = threads.SingleOrDefault(t => t.Id == updatedThread.Id);
            if (thread != null)
            {
                thread.Subject = updatedThread.Subject;
                thread.Summary = updatedThread.Summary;
            }

            return thread;
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Thread> GetThreadsBySubject(string subject = null)
        {
            return from t in threads
                   where string.IsNullOrEmpty(subject) || t.Subject.StartsWith(subject)
                   orderby t.Subject
                   select t;
        }
    }

    
}
