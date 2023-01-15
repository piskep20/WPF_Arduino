using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO.Ports;
using System.Diagnostics;
using System.Threading;
using System.Management;

namespace ArduinoUno_WPF
{
    public partial class lcd : Form
    {
        public lcd()
        {
            InitializeComponent();
        }

        private void btnlcd_Click(object sender, EventArgs e)
        {
            lcd16x2 lcd16x2frm = new lcd16x2();
            lcd16x2frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lcdi2c lcdi2cfrm = new lcdi2c();
            lcdi2cfrm.Show();
            this.Hide();
        }

        private void lcd_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
        }
    }
}
