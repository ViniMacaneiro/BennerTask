using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBenner
{
    public class Connection
    {
        public List<int> Elements = new List<int>();
        public Connection(int element1, int element2)
        {
            Elements.Add(element1); Elements.Add(element2);
        }

        public bool VerifyElement(List<int> elements)
        {
            foreach (int element in elements)
            {
                if (Elements.Contains(element))
                {
                    return true;
                };
            }
            return false;
        }
    }
}
