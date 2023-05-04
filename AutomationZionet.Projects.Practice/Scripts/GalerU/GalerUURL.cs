using AutomationZionet.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationZionet.Projects.Practice.Scripts.GalerU
{
    public class GalerUURL : ConfigParams
    {
        public GalerUURL()
        {
            base.Params["GalerU"] = "https://blue-field-01c0eaf03.3.azurestaticapps.net/";
        }
    }
}
