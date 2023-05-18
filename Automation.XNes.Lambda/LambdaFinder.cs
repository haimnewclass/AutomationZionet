using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AutomationZionet.Base;
using AutomationZionet.Base.Scripts;

namespace Automation.XNes.Lambda
{
    public class LambdaFinder : Finder
    {
        public LambdaFinder Get(IWebDriver d)
        {
            return new LambdaFinder(d);
        }
        public LambdaFinder(IWebDriver d) : base(d)
        {
            base.Elements["Btn-knisa"] = @"//*[@id='knisa']";
            base.Elements["Select-All-Kupot"] = @"//*[@id='selActiveKupot']/option[1]";
            base.Elements["Btn-Add"] = @"//*[@id='btnAdd']";
            base.Elements["Btn-Download-Xml"] = @"//*[@id='cbHoradatXML']";
            base.Elements["Select-From-Month"] = @"//*[@id='selXMLHodashimMe']";
            base.Elements["Select-From-Year"] = @"//*[@id='selXMLShanimMe']";
            base.Elements["Select-Until-Month"] = @"//*[@id='selXMLHodashimAd']";
            base.Elements["Select-Until-Year"] = @"//*[@id='selXMLShanimAd']";
            base.Elements["Radio-PerutMale"] = @"//*[@id='rbXMLPerutMale']";
            base.Elements["Btn-Confirm"] = @"//*[@id='cbBatzeaXML']";

            //select 
            base.Elements["Select-one"] = @"//*[@id='selXMLHodashimMe']";
            base.Elements["Select-two"] = @"//*[@id='selXMLShanimMe']";
            base.Elements["Select-three"] = @"//*[@id='selXMLHodashimAd']";
            base.Elements["Select-four"] = @"//*[@id='selXMLShanimAd']";



        }
    }
}
