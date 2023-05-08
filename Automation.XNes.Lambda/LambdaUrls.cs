using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationZionet.Base;
namespace Automation.XNes.Lambda
{
    public class LambdaUrls : ConfigParams
    {
        public LambdaUrls()
        {
          base.Params["baseUrl"] = "https://gemelnet.cma.gov.il/";

        }
    }
}
