using System.IO;

namespace FileCopy2000.BL
{
    public class JobHandler
    {
        public void CopyAndMoveFolder(Job job, string folderName)
        {
            //TODO: Validate that the folder exists before trying to copy from it

            foreach (string dirPath in Directory.GetDirectories(job.FromPath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(job.FromPath, job.ToPath + folderName));
            }

            foreach (string newPath in Directory.GetFiles(job.FromPath, "*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(job.FromPath, job.ToPath + folderName), true);
            }
        }
    }
}
