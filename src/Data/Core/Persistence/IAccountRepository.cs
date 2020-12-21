namespace HawkLab.Data.Core.Persistence
{
    using HawkLab.Data.Core.Types;

    public interface IAccountRepository
    {
        public Account Get(string accountId);
    }
}
