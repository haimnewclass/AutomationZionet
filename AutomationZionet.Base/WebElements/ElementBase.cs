using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationZionet.Base.WebElements
{
    public interface IElement
    { 
        bool Exists { get; }
        bool Hidden { get; }
    }

    public class ElementBase
    {
    }
}
