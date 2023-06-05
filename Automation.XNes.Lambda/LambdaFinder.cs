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
            //gemel-net
            base.Elements["Btn-knisa"] = @"//*[@id='knisa']";
            base.Elements["Select-All-Kupot"] = @"//*[@id='selActiveKupot']/option[1]";
            base.Elements["Btn-Add"] = @"//*[@id='btnAdd']";
            base.Elements["Btn-Download-Xml"] = @"//*[@id='cbHoradatXML']";
            base.Elements["Radio-PerutMale"] = @"//*[@id='rbXMLPerutMale']";
            base.Elements["Btn-Confirm"] = @"//*[@id='cbBatzeaXML']";
            base.Elements["Select-one"] = @"//*[@id='selXMLHodashimMe']";
            base.Elements["Select-two"] = @"//*[@id='selXMLShanimMe']";
            base.Elements["Select-three"] = @"//*[@id='selXMLHodashimAd']";
            base.Elements["Select-four"] = @"//*[@id='selXMLShanimAd']";

            //bituach-net
            base.Elements["bituach-Btn-knisa"] = @"//*[@id='knisa']";
            base.Elements["bituach-Select-All-Kupot"] = @"//*[@id='output']/option[1]";
            base.Elements["bituach-Btn-Add"] = @"//*[@id='addone']";
            base.Elements["bituach-Btn-Download-Xml"] = @"//*[@id='cbXML']";
            base.Elements["bituach-Select-From-Month"] = @"//*[@id='hodashme']";
            base.Elements["bituach-Select-From-Year"] = @"//*[@id'shanimme']";
            base.Elements["bituach-Select-Until-Month"] = @"//*[@id='hodashad']";
            base.Elements["bituach-Select-Until-Year"] = @"//*[@id='shanimad']";
            base.Elements["bituach-Radio-PerutMale"] = @"//*[@id='rdl_2']";
            base.Elements["bituach-Btn-Confirm"] = @"//*[@id='cbReturn']";

        }
    }
}
