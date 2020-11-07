namespace HawkLab.Courier.Models.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ThreadTests
    {
        [TestMethod]
        public void TestThreadHasTitle()
        {
            var thread = new Thread();

            Assert.IsNull(thread.Title);
        }
    }
}
