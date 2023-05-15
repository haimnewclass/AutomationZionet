using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutomationZionet.Base;
using AutomationZionet.Projects;
using AutomationZionet.Projects.Practice.Scripts.Gmail;
using Automation.XNes.Lambda;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutomationZionet.Base.Driver;

namespace AutomationZionet.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Runner.Run1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LambdaRunner.startRun();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string  month="", year="";
            month=textBox1.Text;
            year=textBox2.Text;
            LambdaRunner.SelectMonthRun(month,year);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string startYear = "", endYear = "";
            startYear = textBox3.Text;
            endYear = textBox4.Text;
            LambdaRunner.SelectYearsRun(startYear, endYear);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\user\learning\xnesLearning\xnes_react\AutomationZionet\files";
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory", path);
            //chromeOptions.AddUserProfilePreference("intl.accept_languages", "nl");
            //chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");

            //using (IWebDriver driver = new ChromeDriver("Driver_Path", chromeOptions))
            using (IWebDriver driver = ChromeDriverBase.Get(chromeOptions).ChromeDriver)
            {
            LambdaDownloadOneMonth l1 = new LambdaDownloadOneMonth(driver, new LambdaSetting(driver, new LambdaFinder(driver),path), "01","2004");

                
            }
        }
    }
}
