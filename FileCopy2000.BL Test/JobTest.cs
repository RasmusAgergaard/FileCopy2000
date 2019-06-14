using System;
using FileCopy2000.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileCopy2000.BL_Test
{
    [TestClass]
    public class JobTest
    {
        [TestMethod]
        public void IsValidTest()
        {
            ////Arrange
            //var job1 = new Job(types.Copy, "Copy folder to location");
            //job1.SetFromPath("//DS212J2/test1");
            //job1.SetToPath("//DS212J2/test2");
            //var expected = true;

            ////Act
            //var actual = job1.IsValid();

            ////Assert
            //Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MissingToPathValidTest()
        {
            ////Arrange
            //var job1 = new Job(types.Copy, "Copy folder to location");
            //job1.SetFromPath("//DS212J2/test1");
            //var expected = false;

            ////Act
            //var actual = job1.IsValid();

            ////Assert
            //Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MissingFromPathValidTest()
        {
            ////Arrange
            //var job1 = new Job(types.Copy, "Copy folder to location");
            //job1.SetToPath("//DS212J2/test2");
            //var expected = false;

            ////Act
            //var actual = job1.IsValid();

            ////Assert
            //Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MissingNameValidTest()
        {
            ////Arrange
            //var job1 = new Job(types.Copy, "");
            //job1.SetFromPath("//DS212J2/test1");
            //job1.SetToPath("//DS212J2/test2");
            //var expected = false;

            ////Act
            //var actual = job1.IsValid();

            ////Assert
            //Assert.AreEqual(expected, actual);
        }
    }
}
