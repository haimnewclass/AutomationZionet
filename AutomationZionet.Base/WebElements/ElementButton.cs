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
        public virtual bool Exists
        {
            get { return false; }
        }

        public virtual bool Hidden
        {
            get { return false; }
        }


    }
}
