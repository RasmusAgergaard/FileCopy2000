using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCopy2000.BL
{
    public class Action
    {
        public Action(types type, string name)
        {
            Type = type;
            Name = name;
        }

        public types Type { get; private set; }
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
    }
}
