using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoUno_WPF
{
    public partial class lcd16x2 : Form
    {
        String[] dostupniPortovi;
        String izabraniPort;
        String apath = "";
        String lcdadr = "";
        String allChars = "";

        SerialPort port;

        bool jeKonektovan = false;
        bool jeUploadovan = false;
        bool jeKreiran = false;
        bool scrollleft, scrollright, blight, cursorblink, showcursor;

        int bodnaBrzina;

        List<int> bodneBrzine = new List<int>();
        List<string> portovi = new List<string>();

        public lcd16x2()
        {
            InitializeComponent();
            dohvatiDostupnePortove();

            bodneBrzine.Add(300);
            bodneBrzine.Add(600);
            bodneBrzine.Add(1200);
            bodneBrzine.Add(2400);
            bodneBrzine.Add(4800);
            bodneBrzine.Add(9600);
            bodneBrzine.Add(14400);
            bodneBrzine.Add(19200);
            bodneBrzine.Add(28800);
            bodneBrzine.Add(38400);
            bodneBrzine.Add(57600);
            bodneBrzine.Add(115200);

            int[] bodneBrzineNiz = bodneBrzine.ToArray();

            string folder = "customcharacters";
            string filter = "*.chgn";
            string[] files = Directory.GetFiles(folder, filter);

            if (files.Length > 0)
            {
                foreach (string file in files)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    listBox1.Items.Add(fileName);
                }
            }

            foreach (string port in dostupniPortovi)
            {
                if (dostupniPortovi[0] != null)
                {
                    portcbox.SelectedItem = dostupniPortovi[0];
                }
            }
            foreach (int bbrzina in bodneBrzineNiz)
            {
                bbrzinacbox.Items.Add(bbrzina);
            }

            bbrzinacbox.SelectedIndex = 5;

            if (dostupniPortovi.Length > 0)
            {
                izabraniPort = dostupniPortovi[0];
                //portlabel.Text = "Port: " + izabraniPort;
                bbrzinalabel.Text = "Bodna brzina: " + bbrzinacbox.SelectedItem.ToString();
            }
            else
            {
                if (MessageBox.Show("Nema otvorenih portova, konekcija nije moguca!!!", "Upozorenje!!!", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //Ne radi nista pusti ga da nastavi
                }
            }
        }

        private void lcd16x2_Load(object sender, EventArgs e)
        {
            jeKonektovan = false;
            jeUploadovan = false;
            jeKreiran = false;

            string ardPath = "";
            string filePath = "preferences.pref";
            string folderPath = "customcharacters\\";

            string[] files = Directory.GetFiles(folderPath, "*.chgn");

            foreach (string file in files)
            {
                string textFromFile = File.ReadAllText(file);
                allChars += textFromFile;
            }

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (line.Contains("arduino_path"))
                {
                    ardPath = ardPath = line.Substring("arduino_path".Length);
                    break;
                }
            }

            if (ardPath == null)
            {
                MessageBox.Show("Nije pronadjena lokacija ARDUINO IDE-a!!!", "Upozorenje!!!");
            }
            apath = ardPath;
        }

        private void dohvatiDostupnePortove()
        {
            dostupniPortovi = SerialPort.GetPortNames();
        }

        private void ProveriPortove()
        {
            // Pronađite trenutno otvorene portove
            string[] trenutniPortovi = SerialPort.GetPortNames();

            foreach (string port in trenutniPortovi)
            {
                if (!portovi.Contains(port))
                {
                    if (port != trenutniPortovi.ToString())
                    {
                        portovi.Remove(port);
                        portcbox.Items.Clear();
                        portcbox.Text = "Port";
                        dohvatiDostupnePortove();
                    }
                }
            }

            // Proverite da li je neki port otvoren ili zatvoren
            foreach (string port in trenutniPortovi)
            {
                if (!portovi.Contains(port))
                {
                    // Ako je neki port otvoren, dodajte ga u listu i u stripmenu
                    portovi.Add(port);
                    portcbox.Items.Add(port);
                }
            }
        }

        public object otvoriPort(string pport, int brzina)
        {
            try
            {
                port = new SerialPort(pport, brzina, Parity.None, 8, StopBits.One);
                port.Open();
                return true;
            }
            catch (Exception ex)
            {
                return ex;
            }

        }

        private void diskonektujArduino()
        {
            konekcija.Text = "Konektuj";
            jeKonektovan = false;
            port.Close();
        }

        private void lcd16x2_FormClosing(object sender, FormClosingEventArgs e)
        {
            lcd lcdfm = new lcd();
            lcdfm.Show();
            port.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customchargen chgen = new customchargen();
            chgen.Show();
            port.Close();
            this.Hide();
        }

        private void ptxtnadisplejbtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Length > 16 ? textBox1.Text.Substring(0, 16) : textBox1.Text;
            int value1 = (int)numericUpDown3.Value;
            string message = String.Format("$Text_{0}_{1}", value1, textBox1.Text);
            port.Write(message);
        }

        private void skrldesno_CheckedChanged(object sender, EventArgs e)
        {
            if (skrldesno.Checked)
            {
                scrollright = true;
            }
            else
            {
                scrollright = false;
            }
            jeUploadovan = false;
        }

        private void skrllevo_CheckedChanged(object sender, EventArgs e)
        {
            if (skrllevo.Checked)
            {
                scrollleft = true;
            }
            else
            {
                scrollleft = false;
            }
            jeUploadovan = false;
        }

        private void bgsvetlo_CheckedChanged(object sender, EventArgs e)
        {
            if (bgsvetlo.Checked)
            {
                blight = true;
            }
            else
            {
                blight = false;
            }
            jeUploadovan = false;
        }

        private void pkursor_CheckedChanged(object sender, EventArgs e)
        {
            if (pkursor.Checked)
            {
                showcursor = true;
            }
            else
            {
                showcursor = false;
            }
            jeUploadovan = false;
        }

        private void bkursor_CheckedChanged(object sender, EventArgs e)
        {
            if (bkursor.Checked)
            {
                cursorblink = true;
            }
            else
            {
                cursorblink = false;
            }
            jeUploadovan = false;
        }

        private void lcd16x2_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                button2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
            }
            else
            {
                button2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
            }
        }

        private void bbrzinacbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bbrzinalabel.Text = "Bodna brzina: " + bbrzinacbox.SelectedItem.ToString();
            Int32.TryParse(bbrzinacbox.SelectedItem.ToString(), out bodnaBrzina);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            jeUploadovan = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;
            int value1 = (int)numericUpDown1.Value;
            int value2 = (int)numericUpDown2.Value;
            string message = string.Format("$Values_{0}_{1}_{2}", selectedIndex, value2, value1);
            port.Write(message);
        }

        private void serialPort1_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            ProveriPortove();
        }

        private void portcbox_DropDown(object sender, EventArgs e)
        {
            ProveriPortove();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string message = "$Clear";
            port.Write(message);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (jeKreiran == false)
            {
                kreirajSketch();
            }
            if (jeUploadovan == false)
            {
                uploadujSketch();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            pinout pnt = new pinout();
            pnt.Show();
        }

        private void portcbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            portlabel.Text = "Port: " + portcbox.SelectedItem.ToString();
            izabraniPort = portcbox.SelectedItem.ToString();
            if (jeKonektovan == false)
            {
                object rezultat = otvoriPort(izabraniPort, bodnaBrzina);

                if (rezultat is Exception)
                {
                    MessageBox.Show("Doslo je do greske prilikom konektovanja na port:\n\n" + rezultat, "Upozorenje!!!");
                }
                else if (rezultat is bool b && b)
                {
                    konekcija.Text = "Diskonektuj";
                    jeKonektovan = true;
                    /*if (jeUploadovan == false)
                    {
                        kreirajSketch();
                    }*/
                }
                else
                {
                    MessageBox.Show("Port nije otvoren, proverite da li je port otvoren i pokusajte ponovo!!!", "Upozorenje!!!");
                }
            }
            else
            {
                diskonektujArduino();
                ProveriPortove();
            }
        }

        private void konekcija_Click(object sender, EventArgs e)
        {
            if (jeKonektovan)
            {
                diskonektujArduino();
            }
            else
            {
                object rezultat = otvoriPort(izabraniPort, bodnaBrzina);

                if (rezultat is Exception)
                {
                    MessageBox.Show("Doslo je do greske prilikom konektovanja na port:\n\n" + rezultat, "Upozorenje!!!");
                }
                else if (rezultat is bool b && b)
                {
                    konekcija.Text = "Diskonektuj";
                    jeKonektovan = true;
                    /*if (jeUploadovan == false)
                    {
                        kreirajSketch();
                    }*/

                }
                else
                {
                    MessageBox.Show("Port nije otvoren, proverite da li je port otvoren i pokusajte ponovo!!!", "Upozorenje!!!");
                }
            }

        }

        private void kreirajSketch()
        {
                string lcddir = "displej16x2";
                string lcdfil = "displej16x2\\displej16x2.ino";
                string skrlevo, skrdesno, psvetlo, pkursor, bkursor;
                string createchars = "";

                int index = 0;

                foreach (string file in Directory.EnumerateFiles("customcharacters"))
                {
                    index++;
                    createchars += string.Format("\tlcd.createChar({0},{1});\n", index - 1, Path.GetFileNameWithoutExtension(file));
                }

                skrdesno = scrollright ? "\tlcd.scrollDisplayRight();\n" : "";
                skrlevo = scrollleft ? "\tlcd.ScrollDislayLeft();\n" : "";
                psvetlo = blight ? "\tlcd.backlight();\n" : "";
                pkursor = showcursor ? "\tlcd.cursor();" : "\tlcd.noCursor();";
                bkursor = cursorblink ? "\tlcd.blink();" : "\tlcd.noBlink();";

                string ardsketch = "#include <LiquidCrystal.h> \n" +
                                   "LiquidCrystal lcd(12, 11, 5, 4, 3, 2); \n" +
                                   allChars + "\n" +
                                   "String inputString;\n" +
                                   "String message;\n" +
                                   "void setup() {\n" +
                                   "\tSerial.begin(9600);\n" +
                                   "\tSerial.setTimeout(10);\n" +
                                   "\tlcd.begin(16, 2);\n" +
                                   "\tlcd.clear();\n" +
                                   createchars + "\n" +
                                   psvetlo +
                                   "} \n" +
                                   "void loop() { \n" +
                                   skrdesno +
                                   skrlevo +
                                   pkursor + "\n" +
                                   bkursor + "\n" +
                                   "\tif (Serial.available() > 0) {\n" +
                                   "\tString inputString = Serial.readString();\n" +
                                   "\tif (inputString.startsWith(\"$Values_\")) {\n" +
                                   "\t\tint index = inputString.substring(8, inputString.indexOf(\"_\", 8)).toInt();\n" +
                                   "\t\tint value1 = inputString.substring(inputString.indexOf(\"_\", 8) + 1, inputString.indexOf(\"_\", inputString.indexOf(\"_\", 8) + 1)).toInt();\n" +
                                   "\t\tint value2 = inputString.substring(inputString.indexOf(\"_\", inputString.indexOf(\"_\", 8) + 1) + 1).toInt();\n" +
                                   "\tlcd.setCursor(value1, value2);\n" +
                                   "\t\tlcd.write(index);\n" +
                                   "\t}\n" +
                                   "\telse if (inputString.startsWith(\"$Text_\")) {\n" +
                                   "\t\tint value3 = inputString.substring(6, inputString.indexOf(\"_\", 6)).toInt();\n" +
                                   "\t\tString text = inputString.substring(inputString.indexOf(\"_\", 6) + 1);\n" +
                                   "\t\tlcd.setCursor(0, value3);\n" +
                                   "\t\tlcd.print(text);\n" +
                                   "\t}\n" +
                                   "\telse if (inputString.startsWith(\"$Clear\")){\n" +
                                   "\t\tlcd.clear();\n" +
                                   "\t}\n" +
                                   "}\n" +
                                   "}\n";

                try
                {
                    System.IO.Directory.CreateDirectory(lcddir);
                    using (StreamWriter sw = new StreamWriter(lcdfil))
                    {
                        sw.Write(ardsketch);
                    }
                }
                catch (System.IO.IOException e)
                {
                    MessageBox.Show("Greska prilikom kreiranja dokumenta: \n" + e.Message, "Upozorenje!!!");
                }

                Thread.Sleep(2000);
                jeKreiran = true;
        }

        private void uploadujSketch()
        {
            diskonektujArduino();

            // Pronalazi ime porta, lokaciju arduino IDE-a i lokaciju sketcha u string-ovima
            string portName = portcbox.SelectedItem.ToString() + " ";       //"COM7 ";
            string arduinoLoc = apath + " ";                                  //"\"C:\\Program Files (x86)\\Arduino\\arduino.exe\" ";
            string sketchLoc = "\"displej16x2\\displej16x2.ino\" ";
            string boardType = "arduino:avr:uno";

            MessageBox.Show(portName + arduinoLoc + sketchLoc + boardType);

            // Povezuje se na port sa odgovarajućim imenom i tipom pločice i upload-uje sketch
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = arduinoLoc,
                    Arguments = " --port " + portName + " --board " + boardType + " --upload " + sketchLoc,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            try
            {
                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    sw.Write(output);
                }
            }
            catch (System.IO.IOException e)
            {
                MessageBox.Show("Greska prilikom kreiranja dokumenta: \n" + e.Message, "Upozorenje!!!");
            }
            MessageBox.Show("Upload uspesno zavrsen!!!", "Obavestenje", MessageBoxButtons.OK);
            jeUploadovan = true;

            object rezultat = otvoriPort(izabraniPort, bodnaBrzina);

            if (rezultat is Exception)
            {
                MessageBox.Show("Doslo je do greske prilikom konektovanja na port:\n\n" + rezultat, "Upozorenje!!!");
            }
            else if (rezultat is bool b && b)
            {
                konekcija.Text = "Diskonektuj";
                jeKonektovan = true;
            }
            else
            {
                MessageBox.Show("Port nije otvoren, proverite da li je port otvoren i pokusajte ponovo!!!", "Upozorenje!!!");
            }
        }
    }
}
