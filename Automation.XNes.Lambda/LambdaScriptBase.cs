using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationZionet.Base.Scripts;
using OpenQA.Selenium;

namespace Automation.XNes.Lambda
{
    public abstract class LambdaScriptBase:ScriptBase
    {
        protected LambdaSetting setting;
        protected LambdaScriptBase(IWebDriver d, LambdaSetting s) : base(d)
        {
            base.Config = new LambdaConfig();
            base.URLs = new LambdaUrls();
            setting = s;
        }
    }
}
