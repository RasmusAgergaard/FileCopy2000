using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCopy2000.BL
{
    public class Job
    {
        public Job(types type, string name, bool requiresInput)
        {
            Type = type;
            Name = name;
            RequiresInput = requiresInput;
        }

        public types? Type { get; private set; }
        public string Name { get; private set; }
        public string FromPath { get; private set; }
        public string ToPath { get; private set; }
        public bool RequiresInput { get; set; }

        public void SetFromPath(string path)
        {
            FromPath = path;
        }

        public void SetToPath(string path)
        {
            ToPath = path;
        }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Name) ||
                string.IsNullOrWhiteSpace(FromPath) ||
                string.IsNullOrWhiteSpace(ToPath) ||
                Type == null)
            {
                return false;
            }

            return true;
        }

        public void Run(string folderName)
        {
            var jobHandler = new JobHandler();

            switch (Type)
            {
                case types.Copy:
                    jobHandler.CopyAndMoveFolder(this, folderName);
                    break;
            }
        }
    }
}
