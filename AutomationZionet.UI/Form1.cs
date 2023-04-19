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
    }
}
