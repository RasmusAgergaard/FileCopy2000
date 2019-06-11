using System;
using FileCopy2000.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileCopy2000.BL_Test
{
    [TestClass]
    public class FileActionHandlerTest
    {
        [TestMethod]
        public void CopyAndMoveFolderTest()
        {
            //Arrange
            var actionCopy = new FileAction(types.Copy, "Copy folder to location");
            actionCopy.SetFromPath("C:/Code/Test1");
            actionCopy.SetToPath("C:/Code/Test2");

            var actionHandler = new FileActionHandler();

            //Act
            actionHandler.RunAction(actionCopy);

            //Assert
        }
    }
}
