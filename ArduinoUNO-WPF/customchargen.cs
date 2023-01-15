using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ArduinoUno_WPF
{
    public partial class customchargen : Form
    {

        private readonly Dictionary<CheckBox, Label> _checkBoxLabelMap;
        public customchargen()
        {
            InitializeComponent();

            _checkBoxLabelMap = new Dictionary<CheckBox, Label>()
            {
                { c1, l1 },
                { c2, l2 },
                { c3, l3 },
                { c4, l4 },
                { c5, l5 },
                { c6, l6 },
                { c7, l7 },
                { c8, l8 },
                { c9, l9 },
                { c10, l10 },
                { c11, l11 },
                { c12, l12 },
                { c13, l13 },
                { c14, l14 },
                { c15, l15 },
                { c16, l16 },
                { c17, l17 },
                { c18, l18 },
                { c19, l19 },
                { c20, l20 },
                { c21, l21 },
                { c22, l22 },
                { c23, l23 },
                { c24, l24 },
                { c25, l25 },
                { c26, l26 },
                { c27, l27 },
                { c28, l28 },
                { c29, l29 },
                { c30, l30 },
                { c31, l31 },
                { c32, l32 },
                { c33, l33 },
                { c34, l34 },
                { c35, l35 },
                { c36, l36 },
                { c37, l37 },
                { c38, l38 },
                { c39, l39 },
                { c40, l40 },
            };

            string folder = "customcharacters";
            string filter = "*.chgn";
            string[] files = Directory.GetFiles(folder, filter);

            if (files.Length > 0)
            {
                foreach (string file in files)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    charlist.Items.Add(fileName);
                }
            }
        }

        private void customchargen_Load(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists("customcharacters"))
            {
                //Do nothing
            }
            else
            {
                System.IO.Directory.CreateDirectory("customcharacters");
            }
        }

        string code = "";
        string stcd = "0b";

        private void button1_Click(object sender, EventArgs e)
        {
            string charfil = "customcharacters\\" + textBox1.Text + ".chgn";
            string cjk = "";
            code = "";
            bool lrow = false;

            string[] firstrow = { l1.Text, l2.Text, l3.Text, l4.Text, l5.Text };
            string[] secondrow = { l6.Text, l7.Text, l8.Text, l9.Text, l10.Text };
            string[] thirdrow = { l11.Text, l12.Text, l13.Text, l14.Text, l15.Text };
            string[] fourthrow = { l16.Text, l17.Text, l18.Text, l19.Text, l20.Text };
            string[] fifthrow = { l21.Text, l22.Text, l23.Text, l24.Text, l25.Text };
            string[] sixthrow = { l26.Text, l27.Text, l28.Text, l29.Text, l30.Text };
            string[] seventhrow = { l31.Text, l32.Text, l33.Text, l34.Text, l35.Text };
            string[] eightthrow = { l36.Text, l37.Text, l38.Text, l39.Text, l40.Text };

            createstrng(firstrow, lrow);
            createstrng(secondrow, lrow);
            createstrng(thirdrow, lrow);
            createstrng(fourthrow, lrow);
            createstrng(fifthrow, lrow);
            createstrng(sixthrow, lrow);
            createstrng(seventhrow, lrow);
            lrow = true;
            createstrng(eightthrow, lrow);

            cjk += "byte " + textBox1.Text + "[8] = { \n" +
                   code +
                   "}; \n";

            label2.Text = cjk;

            try
            {
                using (StreamWriter sw = new StreamWriter(charfil))
                {
                    sw.Write(cjk);
                    //MessageBox.Show("Fajl je kreiran i ispisan");
                }
            }
            catch (System.IO.IOException k)
            {
                MessageBox.Show("Greska prilikom kreiranja dokumenta: \n" + k.Message, "Upozorenje!!!");
            }

            charlist.Items.Add(textBox1.Text);

        }

        private void createstrng(string[] niz, bool lastrow)
        {
            int i;
            string cd = "";
            for (i = 0; i < 5; i++)
            {
                cd += niz[i];
            }
            code += "\t" + stcd + cd;
            if (!lastrow)
            {
                code += "," + "\n";
            }
            else
            {
                code += "\n";
            }
        }

        private void charlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filenamee = charlist.SelectedItem as string;
            string filename = filenamee + ".chgn";
            string path = "customcharacters\\";
            string fpath = Path.Combine(path, filename);

            if (File.Exists(fpath))
            {
                label2.Text = File.ReadAllText(fpath);
            }

            if (charlist.SelectedIndex != -1)
            {
                button2.Visible = true;
            }
            else
            {
                button2.Visible = false;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string selectedchlist = charlist.SelectedItem.ToString();
            if (charlist.SelectedIndex != -1)
            {
                charlist.Items.RemoveAt(charlist.SelectedIndex);
                try
                {
                    System.IO.File.Delete("customcharacters\\" + selectedchlist + ".chgn");
                }
                catch (System.IO.IOException k)
                {
                    MessageBox.Show("Greska prilikom brisanja dokumenta: \n" + k.Message, "Upozorenje!!!");
                }
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            _checkBoxLabelMap[checkBox].Text = checkBox.Checked ? "1" : "0";
        }

        private void customchargen_FormClosing(object sender, FormClosingEventArgs e)
        {
            lcdi2c lcdi2cfrm = new lcdi2c();
            lcdi2cfrm.Show();
        }
    }
}