using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationZionet.Base;
using AutomationZionet.Base.Scripts;
using OpenQA.Selenium;

namespace Automation.XNes.Lambda
{
    public class LambdaConfig:ConfigParams
    {
        public LambdaConfig()
        {
            base.Params["Year_from"] = "1999";
            base.Params["Year_to"] = "2023";
            base.Params["New_Driver_Path"] = @"C:\Users\user\learning\xnesLearning\xnes_react\AutomationZionet\gemelFiles";
            base.Params["Driver_Path"] = @"C:\Users\user\learning\xnesLearning\xnes_react\AutomationZionet\DownloadFiles";
           
        }

    }
    public class LambdaSetting : Setting
    {
        public LambdaConfig lambdaConfig;
        public LambdaSetting(IWebDriver d, Finder f) : base(d, f)
        {
            lambdaConfig = new LambdaConfig();
        }
        public LambdaSetting(IWebDriver d, Finder f,string destFolder) : base(d, f)
        {

            lambdaConfig = new LambdaConfig();
            lambdaConfig["DestFolder"] = destFolder;
        }
    }
}
