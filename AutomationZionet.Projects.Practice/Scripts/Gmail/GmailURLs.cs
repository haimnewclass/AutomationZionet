using AutomationZionet.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationZionet.Projects.Practice.Scripts.Gmail
{
    
    public class GmailURLs : ConfigParams
    {
        public GmailURLs()
        {
            base.Params["baseUrl"] = "https://mail.google.com/";
            base.Params["google"] = "https://www.google.com/";

        }
    }
}
