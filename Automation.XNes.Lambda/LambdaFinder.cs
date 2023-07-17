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
            base.Elements["bituach-Select-All-Kupot"] = @"/html/body/div[1]/section/form/div[5]/table/tbody/tr[2]/td[1]/table/tbody/tr/td[5]/span/span/select/option[1]";
            base.Elements["bituach-Btn-Add"] = @"//*[@id='addone']";
            base.Elements["bituach-Btn-Download-Xml"] = @"//*[@id='cbXML']";
            base.Elements["bituach-Select-From-Month"] = @"//*[@id='hodashme']";
            base.Elements["bituach-Select-From-Year"] = @"/html/body/form/span/table/tbody/tr[1]/td/table/tbody/tr[2]/td/table[1]/tbody/tr[4]/td[1]/span/table/tbody/tr/td[5]/select";
            base.Elements["bituach-Select-Until-Month"] = @"//*[@id='hodashad']";
            base.Elements["bituach-Select-Until-Year"] = @"//*[@id='shanimad']";
            base.Elements["bituach-Radio-PerutMale"] = @"//*[@id='rdl_2']";
            base.Elements["bituach-Btn-Confirm"] = @"/html/body/form/span/table/tbody/tr[2]/td/table/tbody/tr/td[7]/input";

            //Pensia-net
            base.Elements["pensia-Btn-knisa"] = @"/html/body/main/section/div/div[2]/div[2]/div/div[2]/div[1]/div[3]/div[4]/a/span";
            base.Elements["pensia-Btn-options"] = @"/html/body/main/section/div/div[2]/div[2]/div/div/div[2]/div[1]/div/div[1]/div[2]/div[1]/div[2]/div/div";
            base.Elements["pensia-Btn-All-New-Option"] = @"/html/body/div[1]/div/div[2]/ul/li[1]";
            base.Elements["pensia-Input-Select-Start-Date"] = @"/html/body/main/section/div/div[2]/div[2]/div/div/div[2]/div[3]/div[1]/div[1]/span[1]/span/input";
            base.Elements["pensia-Input-Select-End-Date"] = @"/html/body/main/section/div/div[2]/div[2]/div/div/div[2]/div[3]/div[1]/div[2]/span[1]/span/input";
            base.Elements["pensia-Btn-Download-Xml"] = @"/html/body/main/section/div/div[2]/div[2]/div/div/div[2]/div[3]/div[3]/div[1]/div[3]";
            base.Elements["pensia-Radio-Full-Details"] = @"/html/body/main/section/div/div[2]/div[2]/div/div/div[2]/div[3]/div[2]/div[3]/div[2]/div/div[2]/label";
            base.Elements["pensia-Radio-General-Details"] = @"/html/body/main/section/div/div[2]/div[2]/div/div/div[2]/div[3]/div[2]/div[3]/div[1]/div/div[2]/label";
            base.Elements["pensia-Btn-Dounload-Xml-File"] = @"/html/body/main/section/div/div[2]/div[2]/div/div/div[2]/div[3]/div[2]/div[3]/div[3]/div";

        }
    }
}
