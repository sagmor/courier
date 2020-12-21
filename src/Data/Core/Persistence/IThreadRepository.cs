namespace HawkLab.Data.Core.Persistence
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HawkLab.Data.Core.Types;
    
    public interface IThreadRepository
    {

        Thread Update(Thread updatedThread);

        Thread Add(Thread newThread);
        int Commit();
    }

    
}
