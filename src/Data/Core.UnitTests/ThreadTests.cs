namespace HawkLab.Courier.Models.UnitTests
{
    using HawkLab.Data.Core.Types;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ThreadTests
    {
        [TestMethod]
        public void TestThreadHasTitle()
        {
            var thread = new Thread();

            Assert.IsNull(thread.Subject);
        }
    }
}
