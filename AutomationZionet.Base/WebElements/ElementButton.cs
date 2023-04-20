using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationZionet.Base.WebElements
{
    public class ElementButton : ElementBase, IElement
    {
        public ElementButton(Setting s,string name) : base(s, name)
        {

        }

       

        public static ElementButton Get(Setting s, string name)
        {
            return new ElementButton(s, name);
        }

        public bool Click()
        {
                if (!ExistsW)
                    return false;

                WebElementW.Click();
            return true;
        }

    }
}
