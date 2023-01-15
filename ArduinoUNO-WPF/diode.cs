using ArduinoUno_WPF.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using CheckBox = System.Windows.Forms.CheckBox;

namespace ArduinoUno_WPF
{
    public partial class diode : Form
    {
        String[] dostupniPortovi;
        List<int> bodneBrzine = new List<int>();
        SerialPort port;
        bool jeKonektovan = false;
        int bodnaBrzina;
        String izabraniPort;
        int checkedCount = 0;
        int brdioda = 0;
        int[] nizPinova = new int[14];
        bool jeUploadovan = false;
        string apath;

        List<string> portovi = new List<string>();
        List<CheckBox> checkBoxList = new List<CheckBox>();
        List<PictureBox> pictureBoxList = new List<PictureBox>();


        public diode()
        {
            InitializeComponent();
            dohvatiDostupnePortove();
            ucitajElementeListi();
            sakrijSveNaTrecemPanelu();

            int[] bodneBrzineNiz = bodneBrzine.ToArray();

            foreach (string port in dostupniPortovi)
            {
                if (dostupniPortovi[0] != null)
                {
                    comboBox1.SelectedItem = dostupniPortovi[0];
                }
            }
            foreach(int bbrzina in bodneBrzineNiz)
            {
                comboBox2.Items.Add(bbrzina);
            }

            comboBox2.SelectedIndex = 5;

            if (dostupniPortovi.Length > 0)
            {
                izabraniPort = dostupniPortovi[0];
                //portlabel.Text = "Port: " + izabraniPort;
                bbrzinalabel.Text = "Bodna brzina: " + comboBox2.SelectedItem.ToString();
            }
            else
            {
                if(MessageBox.Show("Nema otvorenih portova, konekcija nije moguca!!!", "Upozorenje!!!", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //Ne radi nista pusti ga da nastavi
                }
            }
        }
        private void diode_Load(object sender, EventArgs e)
        {
            string ardPath = "";

            // Putanja do fajla "preferences.pref"
            string filePath = "preferences.pref";

            // Pročitajte sve linije iz fajla
            string[] lines = File.ReadAllLines(filePath);

            // Prođite kroz sve linije u fajlu
            foreach (string line in lines)
            {
                // Ako linija sadrži string "arduino_path"
                if (line.Contains("arduino_path"))
                {
                    // Sacuvajte liniju u promenljivu "ardPath"
                    ardPath = ardPath = line.Substring("arduino_path".Length);
                    break;
                }
            }

            // Ukoliko nije pronađena linija sa "arduino_path", postavi "ardPath" na prazan string
            if (ardPath == null)
            {
                ardPath = "";
            }

            //MessageBox.Show(ardPath);
            apath = ardPath;
            //MessageBox.Show(ardPath + "\n" + apath);

            trecipanel.Hide();
            drugipanel.Hide();
            prvipanel.Show();
            prvipanel.BringToFront();
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
                    if(port != trenutniPortovi.ToString())
                    {
                        portovi.Remove(port);
                        comboBox1.Items.Clear();
                        comboBox1.Text = "Port";
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
                    comboBox1.Items.Add(port);
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
            catch(Exception ex)
            {
                return ex;
            }
            
        }

        private void prikazitrecipanel()
        {
            trecipanel.Show();
            trecipanel.BringToFront();
        }

        private void diskonektujArduino()
        {
            konekcija.Text = "Konektuj";
            jeKonektovan = false;
            port.Close();
            trecipanel.Hide();
            trecipanel.SendToBack();
        }

        private void izabranipin_checkedchanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            int maxbrdioda = brdioda;

            if (checkBox.Checked == true)
            {
                
                for (int i = 0; i < brdioda; i++)
                {
                    int brPina;
                    Int32.TryParse(checkBox.Text, out brPina);
                    nizPinova[checkedCount] = brPina;
                }
                checkedCount++;
                int j = 13;
                if (checkedCount > maxbrdioda)
                {
                    for(j = 13; j>maxbrdioda; j--)
                    {
                        nizPinova[j] = 0;
                    }
                    nizPinova[j] = 0;
                    checkBox.Checked = false;
                    checkedCount = maxbrdioda;
                }
            }
            else
            {
                checkedCount--;
            }

            if(checkedCount < maxbrdioda)
            {
                label2.Text = "Izaberi pin na koji je " + (checkedCount + 1) + ". dioda vezana";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            checkedCount = 0;
            Int32.TryParse(brdiodatxt.Text, out brdioda);
            drugipanel.Show();
            drugipanel.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            drugipanel.Hide();
            jeUploadovan = false;
            brdioda = 0;
            checkedCount = 0;
            prvipanel.Show();
            prvipanel.BringToFront();
            for(int i = 13; i>0; i--)
            {
                nizPinova[i] = 0;
            }
        }

        private void diode_FormClosing(object sender, FormClosingEventArgs e)
        { 
            Form1 form = new Form1();
            form.Show();
            if(jeKonektovan == true)
            {
                port.Close();
            }
        }

        private void drugipanel_VisibleChanged(object sender, EventArgs e)
        {
            izabranpin0.Checked = false;
            izabranpin1.Checked = false;
            izabranpin2.Checked = false;
            izabranpin3.Checked = false;
            izabranpin4.Checked = false;
            izabranpin5.Checked = false;
            izabranpin6.Checked = false;
            izabranpin7.Checked = false;
            izabranpin8.Checked = false;
            izabranpin9.Checked = false;
            izabranpin10.Checked = false;
            izabranpin11.Checked = false;
            izabranpin12.Checked = false;
            izabranpin13.Checked = false;
        }

        private void trecipanel_VisibleChanged(object sender, EventArgs e)
        {
            if (brdioda > 0 && brdioda <= 14)
            {
                for (int i = 0; i < brdioda; i++)
                {
                    checkBoxList[i].Show();
                    pictureBoxList[i].Show();
                }
            }
        }

        private void sakrijSveNaTrecemPanelu()
        {
            for (int i = 1; i < 14; i++)
            {
                checkBoxList[i].Hide();
                pictureBoxList[i].Hide();
            }
        }

        private void ucitajElementeListi()
        {
            checkBoxList.Add(cdioda1);
            checkBoxList.Add(cdioda2);
            checkBoxList.Add(cdioda3);
            checkBoxList.Add(cdioda4);
            checkBoxList.Add(cdioda5);
            checkBoxList.Add(cdioda6);
            checkBoxList.Add(cdioda7);
            checkBoxList.Add(cdioda8);
            checkBoxList.Add(cdioda9);
            checkBoxList.Add(cdioda10);
            checkBoxList.Add(cdioda11);
            checkBoxList.Add(cdioda12);
            checkBoxList.Add(cdioda13);
            checkBoxList.Add(cdioda14);

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

            pictureBoxList.Add(pdioda1);
            pictureBoxList.Add(pdioda2);
            pictureBoxList.Add(pdioda3);
            pictureBoxList.Add(pdioda4);
            pictureBoxList.Add(pdioda5);
            pictureBoxList.Add(pdioda6);
            pictureBoxList.Add(pdioda7);
            pictureBoxList.Add(pdioda8);
            pictureBoxList.Add(pdioda9);
            pictureBoxList.Add(pdioda10);
            pictureBoxList.Add(pdioda11);
            pictureBoxList.Add(pdioda12);
            pictureBoxList.Add(pdioda13);
            pictureBoxList.Add(pdioda14);



            
        }

        private void btndalje3_Click(object sender, EventArgs e)
        {
            cetvrtipanel.Show();
            cetvrtipanel.BringToFront();
            kreirajSketch();
        }

        public void kreirajSketch()
        {
            int led1 = nizPinova[0], led2 = nizPinova[1], led3 = nizPinova[2], led4 = nizPinova[3], led5 = nizPinova[4], led6 = nizPinova[5], led7 = nizPinova[6], led8 = nizPinova[7], led9 = nizPinova[8], led10 = nizPinova[9], led11 = nizPinova[10], led12 = nizPinova[11], led13 = nizPinova[12], led14 = nizPinova[13];
            string leddir = "led_controls";
            string ledfil = "led_controls\\led_controls.ino";


            string code = "int LED_PIN1 = " + led1 + ";\n" +
                          "int LED_PIN2 = " + led2 + ";\n" +
                          "int LED_PIN3 = " + led3 + ";\n" +
                          "int LED_PIN4 = " + led4 + ";\n" +
                          "int LED_PIN5 = " + led5 + ";\n" +
                          "int LED_PIN6 = " + led6 + ";\n" +
                          "int LED_PIN7 = " + led7 + ";\n" +
                          "int LED_PIN8 = " + led8 + ";\n" +
                          "int LED_PIN9 = " + led9 + ";\n" +
                          "int LED_PIN10 = " + led10 + ";\n" +
                          "int LED_PIN11 = " + led11 + ";\n" +
                          "int LED_PIN12 = " + led12 + ";\n" +
                          "int LED_PIN13 = " + led13 + ";\n" +
                          "int LED_PIN14 = " + led14 + ";\n" +
                          "String inputString;\n" +
                          "String Action;\n" +
                          "String LED_Command;\n" +
                          "void setup() {\n" +
                          "  Serial.begin(9600);\n" +
                          "  Serial.setTimeout(10);\n" +
                          "  pinMode(LED_PIN1, OUTPUT);\n" +
                          "  pinMode(LED_PIN2, OUTPUT);\n" +
                          "  pinMode(LED_PIN3, OUTPUT);\n" +
                          "  pinMode(LED_PIN4, OUTPUT);\n" +
                          "  pinMode(LED_PIN5, OUTPUT);\n" +
                          "  pinMode(LED_PIN6, OUTPUT);\n" +
                          "  pinMode(LED_PIN7, OUTPUT);\n" +
                          "  pinMode(LED_PIN8, OUTPUT);\n" +
                          "  pinMode(LED_PIN9, OUTPUT);\n" +
                          "  pinMode(LED_PIN10, OUTPUT);\n" +
                          "  pinMode(LED_PIN11, OUTPUT);\n" +
                          "  pinMode(LED_PIN12, OUTPUT);\n" +
                          "  pinMode(LED_PIN13, OUTPUT);\n" +
                          "  pinMode(LED_PIN14, OUTPUT);\n" +
                          "}\n" +
                          "void loop() {\n" +
                          "  ukljuciDiode();\n" +
                          "}\n" +
                          "void ukljuciDiode(){\n" +
                          "  while(Serial.available()){\n" +
                          "    char c = Serial.read();\n" +
                          "    if(c=='$'){\n" +
                          "      inputString = Serial.readString();\n" +
                          "      Action = inputString.substring(0,5);\n" +
                          "    }\n" +
                          "    if(Action==\"DIODA\"){\n" +
                          "    LED_Command = inputString.substring(5, 8);\n" +
                          "      if(LED_Command==\"1ON\"){\n" +
                          "        turnLedOn(LED_PIN1);\n" +
                          "      } else if (LED_Command==\"2ON\"){\n" +
                          "        turnLedOn(LED_PIN2);\n" +
                          "      }else if (LED_Command==\"3ON\"){\n " +
                          "        turnLedOn(LED_PIN3);\n" +
                          "      }else if (LED_Command==\"4ON\"){\n" +
                          "        turnLedOn(LED_PIN4);\n" +
                          "      }else if (LED_Command==\"5ON\"){\n" +
                          "        turnLedOn(LED_PIN5);\n" +
                          "      }else if (LED_Command==\"6ON\"){\n" +
                          "        turnLedOn(LED_PIN6);\n" +
                          "      }else if (LED_Command==\"7ON\"){\n" +
                          "        turnLedOn(LED_PIN7);\n" +
                          "      }else if (LED_Command==\"8ON\"){\n" +
                          "        turnLedOn(LED_PIN8);\n" +
                          "      }else if (LED_Command==\"9ON\"){\n" +
                          "        turnLedOn(LED_PIN9);\n" +
                          "      }else if (LED_Command==\"10N\"){\n" +
                          "        turnLedOn(LED_PIN10);\n" +
                          "      }else if (LED_Command==\"11N\"){\n" +
                          "        turnLedOn(LED_PIN11);\n" +
                          "      }else if (LED_Command==\"12N\"){\n" +
                          "        turnLedOn(LED_PIN12);\n" +
                          "      }else if (LED_Command==\"13N\"){\n" +
                          "        turnLedOn(LED_PIN13);\n" +
                          "      }else if (LED_Command==\"14N\"){\n" +
                          "        turnLedOn(LED_PIN14);\n" +
                          "      }else if (LED_Command==\"1OF\"){\n" +
                          "        turnLedOff(LED_PIN1);\n" +
                          "      }else if (LED_Command==\"2OF\"){\n" +
                          "        turnLedOff(LED_PIN2);\n" +
                          "      }else if (LED_Command==\"3OF\"){\n" +
                          "        turnLedOff(LED_PIN3);\n" +
                          "      }else if (LED_Command==\"4OF\"){\n" +
                          "        turnLedOff(LED_PIN4);\n" +
                          "      }else if (LED_Command==\"5OF\"){\n" +
                          "        turnLedOff(LED_PIN5);\n" +
                          "      }else if (LED_Command==\"6OF\"){\n" +
                          "        turnLedOff(LED_PIN6);\n" +
                          "      }else if (LED_Command==\"7OF\"){\n" +
                          "        turnLedOff(LED_PIN7);\n" +
                          "      }else if (LED_Command==\"8OF\"){\n" +
                          "        turnLedOff(LED_PIN8);\n" +
                          "      }else if (LED_Command==\"9OF\"){\n" +
                          "        turnLedOff(LED_PIN9);\n" +
                          "      }else if (LED_Command==\"10F\"){\n" +
                          "        turnLedOff(LED_PIN10);\n" +
                          "      }else if (LED_Command==\"11F\"){\n" +
                          "        turnLedOff(LED_PIN11);\n" +
                          "      }else if (LED_Command==\"12F\"){\n" +
                          "        turnLedOff(LED_PIN12);\n" +
                          "      }else if (LED_Command==\"13F\"){\n" +
                          "        turnLedOff(LED_PIN13);\n" +
                          "      }else if (LED_Command==\"14F\"){\n" +
                          "        turnLedOff(LED_PIN14);\n" +
                          "      }\n" +
                          "    }\n" +
                          "  }\n" +
                          "}\n" +
                          "void turnLedOn(int pinNumber){\n" +
                          "     digitalWrite(pinNumber,HIGH);\n" +
                          "}\n" +
                          "void turnLedOff(int pinNumber){\n" +
                          "     digitalWrite(pinNumber,LOW);\n" +
                          "}\n";

            try
            {
                System.IO.Directory.CreateDirectory(leddir);
                using (StreamWriter sw = new StreamWriter(ledfil))
                {
                sw.Write(code);
                }
            }
            catch (System.IO.IOException e)
            {
                MessageBox.Show("Greska prilikom kreiranja dokumenta: \n" + e.Message, "Upozorenje!!!");
            }

            Thread.Sleep(1000);
        }

        void uploadujSketch()
        {

            diskonektujArduino();

            // Pronalazi ime porta, lokaciju arduino IDE-a i lokaciju sketcha u string-ovima
            string portName = comboBox1.SelectedItem.ToString() + " ";       //"COM7 ";
            string arduinoLoc = apath + " ";                                  //"\"C:\\Program Files (x86)\\Arduino\\arduino.exe\" ";
            string sketchLoc = "\"led_controls\\led_controls.ino\" ";
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
                prikazitrecipanel();
            }
            else
            {
                MessageBox.Show("Port nije otvoren, proverite da li je port otvoren i pokusajte ponovo!!!", "Upozorenje!!!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
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
                    if(jeUploadovan == false)
                    {
                        uploadujSketch();
                    }
                    prikazitrecipanel();
                }
                else
                {
                    MessageBox.Show("Port nije otvoren, proverite da li je port otvoren i pokusajte ponovo!!!", "Upozorenje!!!");
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            bbrzinalabel.Text = "Bodna brzina: " + comboBox2.SelectedItem.ToString();
            Int32.TryParse(comboBox2.SelectedItem.ToString(), out bodnaBrzina);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            portlabel.Text = "Port: " + comboBox1.SelectedItem.ToString();
            izabraniPort = comboBox1.SelectedItem.ToString();
            if(jeKonektovan == false)
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
                    if(jeUploadovan == false)
                    {
                        uploadujSketch();
                    }
                }
                else
                {
                    MessageBox.Show("Port nije otvoren, proverite da li je port otvoren i pokusajte ponovo!!!", "Upozorenje!!!");
                }
            } else
            {
                diskonektujArduino();
                ProveriPortove();
            }
            
        }

        private void serialPort1_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            ProveriPortove();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            ProveriPortove();
        }

        private void bgimageon(int index)
        {
            var on = Resources.diodaon;
            pictureBoxList[index].BackgroundImage = on;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (jeKonektovan && port.IsOpen)
            {
                if (cdioda1.Checked)
                {
                    port.Write("$DIODA1ON");
                }
                else
                {
                    port.Write("$DIODA1OF");
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (jeKonektovan && port.IsOpen)
            {
                if (cdioda2.Checked)
                {
                    port.Write("$DIODA2ON");
                }
                else
                {
                    port.Write("$DIODA2OF");
                }
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (jeKonektovan && port.IsOpen)
            {
                if (cdioda3.Checked)
                {
                    port.Write("$DIODA3ON");
                }
                else
                {
                    port.Write("$DIODA3OF");
                }
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (jeKonektovan && port.IsOpen)
            {
                if (cdioda4.Checked)
                {
                    port.Write("$DIODA4ON");
                }
                else
                {
                    port.Write("$DIODA4OF");
                }
            }
        }

        private void cdioda5_CheckedChanged(object sender, EventArgs e)
        {
            if (jeKonektovan && port.IsOpen)
            {
                if (cdioda5.Checked)
                {
                    port.Write("$DIODA5ON");
                }
                else
                {
                    port.Write("$DIODA5OF");
                }
            }
        }

        private void cdioda6_CheckedChanged(object sender, EventArgs e)
        {
            if (jeKonektovan && port.IsOpen)
            {
                if (cdioda6.Checked)
                {
                    port.Write("$DIODA6ON");
                }
                else
                {
                    port.Write("$DIODA6OF");
                }
            }
        }

        private void cdioda7_CheckedChanged(object sender, EventArgs e)
        {
            if (jeKonektovan && port.IsOpen)
            {
                if (cdioda7.Checked)
                {
                    port.Write("$DIODA7ON");
                }
                else
                {
                    port.Write("$DIODA7OF");
                }
            }
        }

        private void cdioda8_CheckedChanged(object sender, EventArgs e)
        {
            if (jeKonektovan && port.IsOpen)
            {
                if (cdioda8.Checked)
                {
                    port.Write("$DIODA8ON");
                }
                else
                {
                    port.Write("$DIODA8OF");
                }
            }
        }

        private void cdioda9_CheckedChanged(object sender, EventArgs e)
        {
            if (jeKonektovan && port.IsOpen)
            {
                if (cdioda9.Checked)
                {
                    port.Write("$DIODA9ON");
                }
                else
                {
                    port.Write("$DIODA9OF");
                }
            }
        }

        private void cdioda10_CheckedChanged(object sender, EventArgs e)
        {
            if (jeKonektovan && port.IsOpen)
            {
                if (cdioda10.Checked)
                {
                    port.Write("$DIODA10N");
                }
                else
                {
                    port.Write("$DIODA10F");
                }
            }
        }

        private void cdioda11_CheckedChanged(object sender, EventArgs e)
        {
            if (jeKonektovan && port.IsOpen)
            {
                if (cdioda11.Checked)
                {
                    port.Write("$DIODA11N");
                }
                else
                {
                    port.Write("$DIODA11F");
                }
            }
        }

        private void cdioda12_CheckedChanged(object sender, EventArgs e)
        {
            if (jeKonektovan && port.IsOpen)
            {
                if (cdioda12.Checked)
                {
                    port.Write("$DIODA12N");
                }
                else
                {
                    port.Write("$DIODA12F");
                }
            }
        }

        private void cdioda13_CheckedChanged(object sender, EventArgs e)
        {
            if (jeKonektovan && port.IsOpen)
            {
                if (cdioda13.Checked)
                {
                    port.Write("$DIODA13N");
                }
                else
                {
                    port.Write("$DIODA13F");
                }
            }
        }

        private void cdioda14_CheckedChanged(object sender, EventArgs e)
        {
            if (jeKonektovan && port.IsOpen)
            {
                if (cdioda14.Checked)
                {
                    port.Write("$DIODA14N");
                }
                else
                {
                    port.Write("$DIODA14F");
                }
            }
        }
    }
}
