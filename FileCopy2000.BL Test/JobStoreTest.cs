using System;
using FileCopy2000.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileCopy2000.BL_Test
{
    [TestClass]
    public class JobStoreTest
    {
        [TestMethod]
        public void ListTest()
        {
            var jobStore = new JobStore();

            jobStore.Jobs[0].Run();
            jobStore.Jobs[1].Run();
            jobStore.Jobs[2].Run();
        }
    }
}
