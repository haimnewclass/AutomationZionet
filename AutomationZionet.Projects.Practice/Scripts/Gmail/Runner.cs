using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationZionet.Projects.Practice.Scripts.Gmail
{
    public class Runner
    {
        public static void Run1()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                ScriptGmailLogout scriptGmailLogout = new Projects.Practice.Scripts.Gmail.ScriptGmailLogout(driver);
                scriptGmailLogout.Run();
            }
        }
    }
}
