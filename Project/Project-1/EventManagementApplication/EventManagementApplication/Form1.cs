﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManagementApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Event eobj = new Event();
            eobj.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Participants par = new Participants();
            par.ShowDialog();
        }
        

        private void button2_Click_1(object sender, EventArgs e)
        {
            Schedules sch = new Schedules();
            sch.ShowDialog();
        }
    }
}
