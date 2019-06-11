using System;
using FileCopy2000.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileCopy2000.BL_Test
{
    [TestClass]
    public class FileActionTest
    {
        [TestMethod]
        public void IsValidTest()
        {
            //Arrange
            var action1 = new FileAction(types.Copy, "Copy folder to location");
            action1.SetFromPath("//DS212J2/test1");
            action1.SetToPath("//DS212J2/test2");
            var expected = true;

            //Act
            var actual = action1.IsValid();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MissingToPathValidTest()
        {
            //Arrange
            var action1 = new FileAction(types.Copy, "Copy folder to location");
            action1.SetFromPath("//DS212J2/test1");
            var expected = false;

            //Act
            var actual = action1.IsValid();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MissingFromPathValidTest()
        {
            //Arrange
            var action1 = new FileAction(types.Copy, "Copy folder to location");
            action1.SetToPath("//DS212J2/test2");
            var expected = false;

            //Act
            var actual = action1.IsValid();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MissingNameValidTest()
        {
            //Arrange
            var action1 = new FileAction(types.Copy, "");
            action1.SetFromPath("//DS212J2/test1");
            action1.SetToPath("//DS212J2/test2");
            var expected = false;

            //Act
            var actual = action1.IsValid();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
