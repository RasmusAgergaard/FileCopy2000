using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCopy2000.BL
{
    public class FileAction
    {
        public FileAction(types type, string name)
        {
            Type = type;
            Name = name;
        }

        public types? Type { get; private set; }
        public string Name { get; private set; }
        public string FromPath { get; private set; }
        public string ToPath { get; private set; }

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
    }
}
