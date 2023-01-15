using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoUno_WPF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void izabranled_Click(object sender, EventArgs e)
        {
            diode ledform = new diode();
            this.Hide();
            ledform.Show();
        }

        private void izabranlcd_Click(object sender, EventArgs e)
        {
            lcd lcdform = new lcd();
            lcdform.Show();
            this.Hide();
        }

        private void izabranservo_Click(object sender, EventArgs e)
        {
            servo servoform = new servo();
            servoform.Show();
            this.Hide();
        }

        private void izabranbuzzer_Click(object sender, EventArgs e)
        {
            buzzer buzzerform = new buzzer();
            buzzerform.Show();
            this.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("ArduinoUno-WPF");
            foreach (var process in processes)
            {
                process.Kill();
            }
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preferences prefs = new preferences();
            prefs.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string ardPath = "";

            // Putanja do fajla "preferences.pref"
            string filePath = "preferences.pref";

            // Pročitajte sve linije iz fajla
            string[] lines = File.ReadAllLines(filePath);

            // Prođite kroz sve linije u fajlu
            foreach (string line in lines)
            {
                // Ako linija počinje sa "arduino_path"
                if (line.StartsWith("arduino_path = "))
                {
                    // Izdvojite lokaciju koja je navedena posle "arduino_path"
                    ardPath = line.Substring("arduino_path = ".Length);
                    break;
                }
            }

            // Ukoliko nije pronađen string "arduino_path", postavi "ardPath" na prazan string
            if (ardPath == null)
            {
                ardPath = "";
            }
        }
    }
}
