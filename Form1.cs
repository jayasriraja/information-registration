﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();  // this is used to connect form2
            f1.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f2 = new Form3();  //this is used to connect form3
            f2.Show();
        }
    }
}
