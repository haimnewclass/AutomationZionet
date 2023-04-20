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
                ScriptGmailLogin login = new Projects.Practice.Scripts.Gmail.ScriptGmailLogin(driver);
                login.Run();
            }
        }
    }
}
