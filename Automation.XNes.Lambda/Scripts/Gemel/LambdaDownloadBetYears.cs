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

namespace Automation.XNes.Lambda.Scripts.Gemel
{
    public class LambdaDownloadBetYears : LambdaScriptBase
    {
        public LambdaSetting setting { get; set; }
        public IWebDriver driver { get; set; }
        public int startYear { get; set; }
        public int endYear { get; set; }
        public bool isFullDetail { get; set; }

        public FileSystemEventHandler fileSystemEventHandler;
        public LambdaDownloadOneMonth oneMonth { get; set; }
        public LambdaDownloadBetYears(IWebDriver d, LambdaSetting s, string startYear, string endYear, bool isFullDetail, FileSystemEventHandler fileSystemEventHandler) : base(d, s)
        {
            setting = s;
            driver = d;
            this.startYear = int.Parse(startYear);
            this.endYear = int.Parse(endYear);
            this.fileSystemEventHandler= fileSystemEventHandler;    
            this.isFullDetail = isFullDetail;
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

                    oneMonth = new LambdaDownloadOneMonth(driver, setting,strMonth, i.ToString(), isFullDetail, fileSystemEventHandler);

                    oneMonth.Run();
                }

            }
            return base.State;
        }
    }
}
