namespace ArduinoUno_WPF
{
    partial class lcd16x2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button4 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.bkursor = new System.Windows.Forms.CheckBox();
            this.pkursor = new System.Windows.Forms.CheckBox();
            this.skrllevo = new System.Windows.Forms.CheckBox();
            this.skrldesno = new System.Windows.Forms.CheckBox();
            this.bgsvetlo = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ptxtnadisplejbtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.konekcija = new System.Windows.Forms.Button();
            this.bbrzinalabel = new System.Windows.Forms.Label();
            this.portlabel = new System.Windows.Forms.Label();
            this.bbrzinacbox = new System.Windows.Forms.ComboBox();
            this.portcbox = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(271, 120);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(226, 33);
            this.button4.TabIndex = 15;
            this.button4.Text = "Uploaduj sketch";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.bkursor);
            this.panel2.Controls.Add(this.pkursor);
            this.panel2.Controls.Add(this.skrllevo);
            this.panel2.Controls.Add(this.skrldesno);
            this.panel2.Controls.Add(this.bgsvetlo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(13, 171);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(484, 276);
            this.panel2.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 45);
            this.button1.TabIndex = 7;
            this.button1.Text = "Custom character generator";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bkursor
            // 
            this.bkursor.AutoSize = true;
            this.bkursor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bkursor.Location = new System.Drawing.Point(222, 157);
            this.bkursor.Name = "bkursor";
            this.bkursor.Size = new System.Drawing.Size(158, 24);
            this.bkursor.TabIndex = 6;
            this.bkursor.Text = "Neka kursor blinka";
            this.bkursor.UseVisualStyleBackColor = true;
            this.bkursor.CheckedChanged += new System.EventHandler(this.bkursor_CheckedChanged);
            // 
            // pkursor
            // 
            this.pkursor.AutoSize = true;
            this.pkursor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pkursor.Location = new System.Drawing.Point(222, 99);
            this.pkursor.Name = "pkursor";
            this.pkursor.Size = new System.Drawing.Size(122, 24);
            this.pkursor.TabIndex = 5;
            this.pkursor.Text = "Prikazi kursor";
            this.pkursor.UseVisualStyleBackColor = true;
            this.pkursor.CheckedChanged += new System.EventHandler(this.pkursor_CheckedChanged);
            // 
            // skrllevo
            // 
            this.skrllevo.AutoSize = true;
            this.skrllevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skrllevo.Location = new System.Drawing.Point(24, 157);
            this.skrllevo.Name = "skrllevo";
            this.skrllevo.Size = new System.Drawing.Size(169, 24);
            this.skrllevo.TabIndex = 4;
            this.skrllevo.Text = "Skroluj tekst na levo";
            this.skrllevo.UseVisualStyleBackColor = true;
            this.skrllevo.CheckedChanged += new System.EventHandler(this.skrllevo_CheckedChanged);
            // 
            // skrldesno
            // 
            this.skrldesno.AutoSize = true;
            this.skrldesno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skrldesno.Location = new System.Drawing.Point(24, 99);
            this.skrldesno.Name = "skrldesno";
            this.skrldesno.Size = new System.Drawing.Size(185, 24);
            this.skrldesno.TabIndex = 3;
            this.skrldesno.Text = "Skroluj tekst na desno";
            this.skrldesno.UseVisualStyleBackColor = true;
            this.skrldesno.CheckedChanged += new System.EventHandler(this.skrldesno_CheckedChanged);
            // 
            // bgsvetlo
            // 
            this.bgsvetlo.AutoSize = true;
            this.bgsvetlo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bgsvetlo.Location = new System.Drawing.Point(222, 29);
            this.bgsvetlo.Name = "bgsvetlo";
            this.bgsvetlo.Size = new System.Drawing.Size(212, 24);
            this.bgsvetlo.TabIndex = 2;
            this.bgsvetlo.Text = "Pozadinsko svetlo displeja";
            this.bgsvetlo.UseVisualStyleBackColor = true;
            this.bgsvetlo.CheckedChanged += new System.EventHandler(this.bgsvetlo_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pinout";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.numericUpDown3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numericUpDown2);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ptxtnadisplejbtn);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(503, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(487, 436);
            this.panel1.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Red ( max. 1):";
            this.label6.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(146, 94);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 24);
            this.button3.TabIndex = 16;
            this.button3.Text = "Clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(7, 94);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown3.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(334, 378);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Posalji karakter na displej";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(333, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Pozicija karaktera";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(333, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Kolona (max. 15):";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(333, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Red ( max. 1):";
            this.label3.Visible = false;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(337, 304);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown2.TabIndex = 10;
            this.numericUpDown2.Visible = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(337, 202);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.Visible = false;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(7, 136);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(320, 279);
            this.listBox1.TabIndex = 8;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(324, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Unesite tekst koji ce se prikazivati na displeju";
            // 
            // ptxtnadisplejbtn
            // 
            this.ptxtnadisplejbtn.Location = new System.Drawing.Point(327, 94);
            this.ptxtnadisplejbtn.Margin = new System.Windows.Forms.Padding(2);
            this.ptxtnadisplejbtn.Name = "ptxtnadisplejbtn";
            this.ptxtnadisplejbtn.Size = new System.Drawing.Size(139, 24);
            this.ptxtnadisplejbtn.TabIndex = 2;
            this.ptxtnadisplejbtn.Text = "Posalji tekst na displej";
            this.ptxtnadisplejbtn.UseVisualStyleBackColor = true;
            this.ptxtnadisplejbtn.Click += new System.EventHandler(this.ptxtnadisplejbtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(2, 41);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(483, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // konekcija
            // 
            this.konekcija.Location = new System.Drawing.Point(12, 120);
            this.konekcija.Margin = new System.Windows.Forms.Padding(2);
            this.konekcija.Name = "konekcija";
            this.konekcija.Size = new System.Drawing.Size(226, 33);
            this.konekcija.TabIndex = 12;
            this.konekcija.Text = "Ceka na konekciju...";
            this.konekcija.UseVisualStyleBackColor = true;
            this.konekcija.Click += new System.EventHandler(this.konekcija_Click);
            // 
            // bbrzinalabel
            // 
            this.bbrzinalabel.AutoSize = true;
            this.bbrzinalabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbrzinalabel.Location = new System.Drawing.Point(212, 7);
            this.bbrzinalabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bbrzinalabel.Name = "bbrzinalabel";
            this.bbrzinalabel.Size = new System.Drawing.Size(145, 25);
            this.bbrzinalabel.TabIndex = 11;
            this.bbrzinalabel.Text = "Bodna brzina:";
            // 
            // portlabel
            // 
            this.portlabel.AutoSize = true;
            this.portlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portlabel.Location = new System.Drawing.Point(8, 7);
            this.portlabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.portlabel.Name = "portlabel";
            this.portlabel.Size = new System.Drawing.Size(63, 25);
            this.portlabel.TabIndex = 10;
            this.portlabel.Text = "Port: ";
            // 
            // bbrzinacbox
            // 
            this.bbrzinacbox.FormattingEnabled = true;
            this.bbrzinacbox.Location = new System.Drawing.Point(217, 52);
            this.bbrzinacbox.Margin = new System.Windows.Forms.Padding(2);
            this.bbrzinacbox.Name = "bbrzinacbox";
            this.bbrzinacbox.Size = new System.Drawing.Size(125, 21);
            this.bbrzinacbox.TabIndex = 9;
            this.bbrzinacbox.SelectedIndexChanged += new System.EventHandler(this.bbrzinacbox_SelectedIndexChanged);
            // 
            // portcbox
            // 
            this.portcbox.FormattingEnabled = true;
            this.portcbox.Location = new System.Drawing.Point(12, 50);
            this.portcbox.Margin = new System.Windows.Forms.Padding(2);
            this.portcbox.Name = "portcbox";
            this.portcbox.Size = new System.Drawing.Size(125, 21);
            this.portcbox.TabIndex = 8;
            this.portcbox.DropDown += new System.EventHandler(this.portcbox_DropDown);
            this.portcbox.SelectedIndexChanged += new System.EventHandler(this.portcbox_SelectedIndexChanged);
            // 
            // serialPort1
            // 
            this.serialPort1.PinChanged += new System.IO.Ports.SerialPinChangedEventHandler(this.serialPort1_PinChanged);
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(24, 43);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(169, 23);
            this.button5.TabIndex = 8;
            this.button5.Text = "Pogledaj veze";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // lcd16x2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 453);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.konekcija);
            this.Controls.Add(this.bbrzinalabel);
            this.Controls.Add(this.portlabel);
            this.Controls.Add(this.bbrzinacbox);
            this.Controls.Add(this.portcbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "lcd16x2";
            this.Text = "lcd16x2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.lcd16x2_FormClosing);
            this.Load += new System.EventHandler(this.lcd16x2_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox bkursor;
        private System.Windows.Forms.CheckBox pkursor;
        private System.Windows.Forms.CheckBox skrllevo;
        private System.Windows.Forms.CheckBox skrldesno;
        private System.Windows.Forms.CheckBox bgsvetlo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ptxtnadisplejbtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button konekcija;
        private System.Windows.Forms.Label bbrzinalabel;
        private System.Windows.Forms.Label portlabel;
        private System.Windows.Forms.ComboBox bbrzinacbox;
        private System.Windows.Forms.ComboBox portcbox;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button button5;
    }
}