using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems
{
    internal class EbaControls :Controls, IControls
    {
        public string Name { get; set; }
        public bool visible { get; set; }

        public bool enabled { get; set; }

        public int getId()
        {
            throw new NotImplementedException();
        }
    }
}
