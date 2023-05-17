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
using System.IO;

namespace AutomationZionet.UI
{
    public partial class Form1 : Form
    { 
        public LambdaDownloadOneMonth l1;
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
            LambdaRunner.SelectMonthRun(l1,month,year, afterFileCreated);
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
           string path = @"C:\Users\user\learning\xnesLearning\xnes_react\AutomationZionet\";

          SingleRunner s1 = new SingleRunner(); 
            s1.Run(path, "01", "2001");
 
            //Guid guid = Guid.NewGuid();
            //string newFolderPath = path + guid.ToString();

            //if (!System.IO.Directory.Exists(newFolderPath))
            //    System.IO.Directory.CreateDirectory(newFolderPath);

            //ChromeOptions chromeOptions = new ChromeOptions();
            //chromeOptions.AddUserProfilePreference("download.default_directory", newFolderPath);
            //using (IWebDriver driver = ChromeDriverBase.Get(chromeOptions).ChromeDriver)
            //{
            // l1 = new LambdaDownloadOneMonth(driver, new LambdaSetting(driver, new LambdaFinder(driver), newFolderPath), "01","2004", afterFileCreated);

            //    l1.Run();

            //}
        }
        public void afterFileCreated(object sender, FileSystemEventArgs e)
        {
            l1.CopyCompleatedFileToTargetFolder();
        }



    }
}
