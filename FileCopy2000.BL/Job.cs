namespace FileCopy2000.BL
{
    public class Job
    {
        public Job()
        {

        }

        public Job(types type, string name, bool requiresInput)
        {
            Type = type;
            Name = name;
            RequiresInput = requiresInput;
        }

        public types? Type { get; set; }
        public string Name { get; set; }
        public string FromPath { get; set; }
        public string ToPath { get; set; }
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
