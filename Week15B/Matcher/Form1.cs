﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matcher
{
    public partial class Form1 : Form
    {
        private Regex m_Regex = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void listBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void patternTextBox_TextChanged(object sender, EventArgs e)
        {
            this.ValidateTestBox();
        }

        private void ValidateTestBox()
        {

            }
        }
    }

