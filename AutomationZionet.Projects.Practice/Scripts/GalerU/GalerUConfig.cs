using AutomationZionet.Base;
using AutomationZionet.Base.Scripts;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationZionet.Projects.Practice.Scripts.GalerU
{
    public class GalerUConfig : ConfigParams
    {
        public GalerUConfig()
        {
            base.Params["NameOnly"] = "achiya";
            base.Params["Without_@"] = "achiyagmail.com";
            base.Params["Without_Domain"] = "achiya@.com";
            base.Params["Without_TLD"] = "achiya@gmail";
            base.Params["User"] = "achiya@gmail.com";

            base.Params["ShortPassword"] = "Ab!2";
            base.Params["NumbersOnly"] = "12345678";
            base.Params["UpperMissing"] = "1234567a";
            base.Params["SpecialCharMissing"] = "123456aA";
            base.Params["Password"] = "Abcd!2#$";
            base.Params["SearchLogiosteam"] = "logisteam.co.il";
        }
    }

    public class GalerUSetting : Setting
    {

        public GalerUSetting(IWebDriver d, Finder f) : base(d, f)
        {

        }

        public GalerUConfig galerUConfig = new GalerUConfig();
    }
}
