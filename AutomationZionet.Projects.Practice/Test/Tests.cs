using AutomationZionet.Projects.Practice.Scripts.GalerU;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationZionet.Projects.Practice.Test
{
    [TestFixture]
    public class Tests
    {

        [Test, Order(1), NUnit.Framework.Category("Check Email")]
        public static void emailNotValid()
        {
            string textString = "the email is not valid";

            Runner.Run1();

            // stripRunner.Login("achiya", "");
            // Assert.AreEqual(textString, responseMsg, "should be Equal");

        }
    }
}
