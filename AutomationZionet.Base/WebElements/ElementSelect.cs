using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationZionet.Base.WebElements
{
    public class ElementSelect : ElementBase, IElement
    {
        public ElementSelect(Setting s, string name) : base(s, name)
        {

        }

        public static ElementSelect Get(Setting s, string name)
        {
            return new ElementSelect(s, name);
        }

        public bool SendKeys(string keys, bool wait = false)
        {

            if (!ExistsW)
                return false;




            return true;
        }
    }
}
