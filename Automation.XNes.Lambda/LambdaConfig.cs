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
            //gemel
            base.Params["Year_from"] = "1999";
            base.Params["Year_to"] = "2023";
            base.Params["New_Driver_Path"] = @"C:\projects_excellence\Automation_New\savedFiles\gemel";
            base.Params["Driver_Path"] = @"C:\projects_excellence\Automation_New\dwonloadedFiles\gemel";

            //bituach
            base.Params["bituach_Year_from"] = "1999";
            base.Params["bituach_Year_to"] = "2023";
            base.Params["bituach_New_Driver_Path"] = @"C:\projects_excellence\Automation_New\savedFiles\bituach";
            base.Params["bituach_Driver_Path"] = @"C:\projects_excellence\Automation_New\dwonloadedFiles\bituach";

            //pensia
            base.Params["pensia_Year_from"] = "1999";
            base.Params["pensia_Year_to"] = "2023";
            base.Params["pensia_New_Driver_Path"] = @"C:\projects_excellence\Automation_New\savedFiles\pensia";
            base.Params["pensia_Driver_Path"] = @"C:\projects_excellence\Automation_New\dwonloadedFiles\pensia";
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
