using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace FileCopy2000.BL
{
    public class JobStore
    {
        public string FilePath { get; set; }

        public JobStore()
        {
            FilePath = Path.Combine(Environment.CurrentDirectory, "jobs.xml");
        }

        public void SaveJobs(List<Job> jobs)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Job>));
            var file = File.Create(FilePath);

            xmlSerializer.Serialize(file, jobs);

            file.Close();
        }

        public List<Job> LoadJobs()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Job>));
            var file = new StreamReader(FilePath);

            var loadedJobs = (List<Job>)xmlSerializer.Deserialize(file);

            file.Close();

            return loadedJobs;
        }

        public List<Job> TestJobs()
        {
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

            return testJobs;
        }
    }
}
