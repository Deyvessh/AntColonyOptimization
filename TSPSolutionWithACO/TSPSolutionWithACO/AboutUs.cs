﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSPSolutionWithACO
{
    /// <summary>
    /// Form Class for About us form
    /// </summary>
    public partial class AboutUs : Form
    {
        public AboutUs()
        {
            InitializeComponent();
        }

        //button click handler for close button
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
