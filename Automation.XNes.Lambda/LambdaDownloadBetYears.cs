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

namespace Automation.XNes.Lambda
{
    public class LambdaDownloadBetYears : LambdaScriptBase
    {
        public LambdaSetting setting { get; set; }
        public IWebDriver driver { get; set; }
        public int startYear { get; set; }
        public int endYear { get; set; }

        public LambdaDownloadBetYears(IWebDriver d, LambdaSetting s, string startYear, string endYear) : base(d, s)
        {
            setting = s;
            driver = d;
            this.startYear = int.Parse(startYear);
            this.endYear = int.Parse(endYear);
        }

        public override ScriptState Run()
        {
            string strMonth = "";
            for (int i = startYear; i < endYear; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    if (j < 10)
                         strMonth = "0" + j.ToString();
                    else
                         strMonth = j.ToString();

                    LambdaDownloadOneMonth startSelect = new LambdaDownloadOneMonth(driver, new LambdaSetting(driver, new LambdaFinder(driver)),strMonth, i.ToString());

                    startSelect.Run();
                }

            }
            return base.State;
        }
    }
}
