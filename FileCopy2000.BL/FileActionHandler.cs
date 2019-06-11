using System.IO;

namespace FileCopy2000.BL
{
    public class FileActionHandler
    {
        public void RunAction(FileAction action)
        {
            switch (action.Type)
            {
                case types.Copy:
                    CopyAndMoveFolder(action);
                    break;
            }
        }

        private void CopyAndMoveFolder(FileAction action)
        {
            //TODO: Validate that the folder exists before trying to copy from it

            foreach (string dirPath in Directory.GetDirectories(action.FromPath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(action.FromPath, action.ToPath));
            }

            foreach (string newPath in Directory.GetFiles(action.FromPath, "*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(action.FromPath, action.ToPath), true);
            }
        }
    }
}
