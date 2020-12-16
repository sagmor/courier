namespace HawkLab.Courier.Data.Core.UnitTests
{
    using HawkLab.Data.Core.Types;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void TestThreadHasTitle()
        {
            var account = new Account();

            Assert.IsNull(account.Handle);
        }
    }
}
