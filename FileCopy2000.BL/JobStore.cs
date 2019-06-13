using System.Collections.Generic;

namespace FileCopy2000.BL
{
    public class JobStore
    {
        public JobStore()
        {
            //********** TEST JOBS **********//
            var testJobs = new List<Job>()
            {
                new Job(types.Copy, "Test1", true) {},
                new Job(types.Copy, "Test2", true) {},
                new Job(types.Copy, "Test3", true) {},
                new Job(types.Copy, "Test4", false) {}
            };

            testJobs[0].SetFromPath("C:/Code/Test1");
            testJobs[0].SetToPath("C:/Code/");
            testJobs[1].SetFromPath("C:/Code/Test1");
            testJobs[1].SetToPath("C:/Code/");
            testJobs[2].SetFromPath("C:/Code/Test1");
            testJobs[2].SetToPath("C:/Code/");
            testJobs[3].SetFromPath("");
            testJobs[3].SetToPath("C:/Code/");

            Jobs = testJobs;
        }

        public List<Job> Jobs { get; set; }
    }
}
