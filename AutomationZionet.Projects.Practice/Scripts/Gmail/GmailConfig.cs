using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationZionet.Base;
using AutomationZionet.Base.Scripts;
using OpenQA.Selenium;

namespace AutomationZionet.Projects.Practice.Scripts.Gmail
{
    public class GmailConfig : ConfigParams
    {
        public GmailConfig()
        {
            base.Params["User"] = "taiziavi15@gmail.com";
            base.Params["Password"] = "1234567890!@#$%^&*()";
            base.Params["SearchLogiosteam"] = "logisteam.co.il";
            
        }
    }

    public class GmailSetting : Setting {

        public GmailSetting(IWebDriver d, Finder f):base(d,f)
        {
             
        }

        public GmailConfig gmailConfig = new GmailConfig();
    }

}
