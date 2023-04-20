using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationZionet.Base.Scripts;
using OpenQA;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationZionet.Projects.Practice.Scripts.Gmail
{
    public class FinderGmail:Finder
    {
       
        public static FinderGmail Get(IWebDriver d)
        {
            return new FinderGmail(d);
        }

        
        public FinderGmail(IWebDriver d):base(d)
        {
            base.Elements["Input-User"] = @"//*[@id=""identifierId""]";
            base.Elements["Btn-Next"] = @"//*[@id=""identifierNext""]/div/button/span";
            base.Elements["Input-Psw"] = @"//*[@id=""password""]/div[1]/div/div[1]/input";
            base.Elements["Btn-Psw-Next"] = @"//*[@id=""passwordNext""]/div/button/span";
            base.Elements["Btn-NotNow"] = @"//*[@id=""yDmH0d""]/c-wiz/div/div/div/div[2]/div[4]/div[1]/button/span";
            base.Elements["Btn-Review"] = @"//*[@id=""wrkpb""]/span/span";
            base.Elements["Input-google"] = @"//*[@id=""APjFqb""]";
            base.Elements["Btn-Google-Search"] = @"//*[@id=""tsf""]/div[1]/div[1]/div[2]/button/div/span/svg/path]";
            

        }





    }
}
