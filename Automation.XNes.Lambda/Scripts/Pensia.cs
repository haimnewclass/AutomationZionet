using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AutomationZionet.Base.Scripts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.IO;
using AutomationZionet.Base.WebElements;
using OpenQA.Selenium.Chrome;

namespace Automation.XNes.Lambda
{
    public class Pensia : LambdaScriptBase
    {
        public LambdaSetting setting { get; set; }
        public IWebDriver driver { get; set; }
      

       

        public Pensia(IWebDriver d, LambdaSetting s) : base(d, s)
        {

            setting = s;
            driver = d;
        }

        public override ScriptState Run()
        {
          
            base.State = ScriptState.Started;

            

            GoToUrl("pensiaBituchUrl");
            ElementButton.Get(setting, "pensia-Btn-knisa").Click();
           

            return base.State;
        }

       

      

    }


}
