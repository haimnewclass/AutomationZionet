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
          base.Params["baseGemelUrl"] = "https://gemelnet.cma.gov.il/";
            base.Params["baseBituchUrl"] = "https://bituachnet.cma.gov.il/";
            base.Params["pensiaBituchUrl"] = "https://pensyanet.cma.gov.il/";
            base.Params["newPage"] = "https://bituachnet.cma.gov.il/bituachTsuotUI/Tsuot/UI/horadatXMLMain.aspx";

        }
    }
}
