using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ArduinoUno_WPF
{
    public partial class preferences : Form
    {
        public preferences()
        {
            InitializeComponent();
        }

        string ardide;

        private void button1_Click(object sender, EventArgs e)
        {
            // Kreirajte novi OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Postavite filter za .exe fajlove
            openFileDialog.Filter = "Executable files (*.exe)|*.exe";

            // Postavite naslov prozora dijaloga
            openFileDialog.Title = "Izaberite .exe fajl";

            // Ako korisnik klikne na dugme "Open" u dijalogu
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Preuzmite putanju do izabranog fajla i prikažite je u textbox-u
                string filePath = openFileDialog.FileName;
                textBox1.Text = filePath;
                ardide = "arduino_path " + "\"" + filePath + "\"";
            } else if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                textBox1.Text = "";
                MessageBox.Show("Niste izabrali nijedan dokument!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string preffile = "preferences.pref";

            try
            {
                using (StreamWriter sw = new StreamWriter(preffile))
                {
                    sw.Write(ardide);
                }
            }
            catch (System.IO.IOException r)
            {
                MessageBox.Show("Greska prilikom kreiranja dokumenta: \n" + r.Message);
            }

            this.Close();
        }

        private void preferences_Load(object sender, EventArgs e)
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

            textBox1.Text = ardPath;
        }
    }
}
