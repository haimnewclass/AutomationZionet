using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationZionet.Base;


namespace AutomationZionet.Projects.Practice.Scripts.Gmail
{
    public class GmailConfig : ConfigParams
    {
        public GmailConfig()
        {
            base.Params["User"] = "taiziavi15@gmail.com";
            base.Params["Password"] = "1234567890!@#$%^&*()";
        }
    }
}
