using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationZionet.Base.Scripts;
using OpenQA;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationZionet.Projects.Practice.Scripts.GalerU
{
    public class FinderGalerU : Finder
    {

        public static FinderGalerU Get(IWebDriver d)
        {
            return new FinderGalerU(d);
        }


        public FinderGalerU(IWebDriver d) : base(d)
        {
            base.Elements["Btn-Login"] = @"//*[@id=""root""]/div/button";
            base.Elements["Input-User"] = @"//*[@id=""username""]";
            base.Elements["Btn-Next"] = @"/html/body/div/main/section/div/div[2]/div/div[1]/div/form/div[2]/button";
            base.Elements["Input-Psw"] = @"//*[@id=""password""]";
            base.Elements["Btn-Psw-Next"] = @"/html/body/div/main/section/div/div/div/form/div[3]/button";
            //base.Elements["Btn-NotNow"] = @"//*[@id=""yDmH0d""]/c-wiz/div/div/div/div[2]/div[4]/div[1]/button/span";
            //base.Elements["Btn-Review"] = @"//*[@id=""wrkpb""]/span/span";
            //base.Elements["Input-google"] = @"//*[@id=""APjFqb""]";
            //base.Elements["Btn-Google-Search"] = @"//*[@id=""tsf""]/div[1]/div[1]/div[2]/button/div/span/svg/path]";
        }
    }
}