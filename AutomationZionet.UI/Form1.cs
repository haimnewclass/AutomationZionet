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
using Automation.XNes.Lambda.Runner;
using Automation.XNes.Lambda;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutomationZionet.Base.Driver;
using System.IO;
using Automation.XNes.Lambda.Runner.Gemel;
using Automation.XNes.Lambda.Runner.Bituach;
using Automation.XNes.Lambda.Scripts.Bituach;
using Automation.XNes.Lambda.Scripts.Gemel;
using Automation.XNes.Lambda.Runner.Pensia;

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
            //LambdaRunner.startRun();  
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //LambdaRunner l = new LambdaRunner();
            //string  month="", year="";
            //month=textBox1.Text;
            //year=textBox2.Text;
            //l.SelectMonthRun(month,year);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //LambdaRunner l = new LambdaRunner();
            //string startYear = "", endYear = "";
            //startYear = textBox3.Text;
            //endYear = textBox4.Text;
            //l.SelectYearsRun(startYear, endYear);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {
          // string path = @"C:\projects_excellence\Automation2\";

          //SingleRunner s1 = new SingleRunner(); 
          //  s1.Run(path, "01", "2001");
        }
        public void afterFileCreated(object sender, FileSystemEventArgs e)
        {
            //l1.CopyCompleatedFileToTargetFolder();
        }




        //-----------------------------------------------------------------------------------------------------------------------------------
        private void button6_Click(object sender, EventArgs e)
        {
            string path = @"C:\projects_excellence\Automation_New\dwonloadedFiles\gemel\";
            LambdaRunAll l1 =new LambdaRunAll();
            l1.Run(path, true);
            l1.RunChevrot(path, false);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string path = @"C:\projects_excellence\Automation_New\dwonloadedFiles\bituach\";
            LambdaRunAll_Bituach l1 = new LambdaRunAll_Bituach();
            //l1.Run(path, true);
            l1.RunChevrot(path, false);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string path = @"C:\projects_excellence\Automation_New\dwonloadedFiles\pensia\";
            LambdaRunAll_Pensia l1 = new LambdaRunAll_Pensia();
            //l1.Run(path, true);
            l1.RunChevrot(path, false);
        }

        private void button9_Click(object sender, EventArgs e)
        { 
            string path = @"C:\projects_excellence\Automation_New\dwonloadedFiles\pensia\";
            LambdaRunAll_Pensia l1 = new LambdaRunAll_Pensia();
            l1.RunOneMonth(3, 2014, path, true);
            l1.RunOneMonth(2, 2013, path, false);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            string path = @"C:\projects_excellence\Automation_New\dwonloadedFiles\bituach\";
            LambdaRunAll_Bituach l1 = new LambdaRunAll_Bituach();
            l1.RunOneMonth(3, 2014, path, true);
            l1.RunOneMonth(2, 2013, path, false);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string path = @"C:\projects_excellence\Automation_New\dwonloadedFiles\gemel\";
            LambdaRunAll l1 = new LambdaRunAll();
            l1.RunOneMonth(3, 2014, path, true);
            l1.RunOneMonth(2, 2013, path, false);
        }
    }
}
