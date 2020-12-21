namespace HawkLab.Data.Core.Persistence
{
    using System.Collections.Generic;
    using HawkLab.Data.Core.Types;

    public interface IThreadRepository
    {
        Thread GetById(int id);

        IEnumerable<Thread> GetThreadsBySubject(string subject = null);

        Thread Update(Thread updatedThread);

        Thread Add(Thread newThread);

        int Commit();
    }
}
