using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems
{
    internal class webControls : Acontrols,  IControls,IControls2
    {
        public bool readOnly { get; set; }
        public string Name { get; set; }
        public bool visible { get; set; }

        public int getId()
        {
            throw new NotImplementedException();
        }

        public override void getId()
        {
            throw new NotImplementedException();
        }
    }
}
