using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationZionet.Base.WebElements
{
    public class ElementInput : ElementBase, IElement
    {
        public ElementInput(Setting s ,string name):base(s,name)
        {

        }

        public static ElementInput Get(Setting s, string name)
        {
            return new ElementInput(s, name);
        }

        public bool SendKeys(string keys,bool wait = false)
        {
            
                if (!ExistsW)
                    return false;
                
           
             
                WebElementW.SendKeys(keys);

            return true;
        }

    }
}
