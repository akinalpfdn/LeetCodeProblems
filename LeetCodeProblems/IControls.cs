using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems
{
    internal interface IControls
    {
        string Name { get; set; }
        bool visible { get; set; }

        int getId();
    }
    internal interface IControls2
    {
        string Name { get; set; }
        bool visible { get; set; }

        int getId();
    }
    internal class Controls
    {
        string Name { get; set; }
        bool visible { get; set; }

        int getId()
        {
            return 0;
        }

    }
    internal class Controls2
    {
        string Name { get; set; }
        bool visible { get; set; }

    }
    public abstract class Insan
    {

        string Name { get; set; }
        int age { get; set; }
        enum gender { kadin,erkek }
        int maas;
        public abstract void setMaas();

        public int getMaas()
        {
            return maas;
        }
    }

    public class Isveren
    {
        public string Name { get; set; }
    }

    public class Calisan
    {

    }

    public class Main
    {
        public void main1()
        {
            Insan insan = new Insan();
            IControls controls = new EbaControls();
        }
    }
}
