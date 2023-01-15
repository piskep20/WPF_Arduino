namespace ArduinoUno_WPF
{
    partial class Form1
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
            this.izabranled = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.izabranlcd = new System.Windows.Forms.Button();
            this.izabranservo = new System.Windows.Forms.Button();
            this.izabranbuzzer = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // izabranled
            // 
            this.izabranled.Location = new System.Drawing.Point(20, 90);
            this.izabranled.Name = "izabranled";
            this.izabranled.Size = new System.Drawing.Size(120, 60);
            this.izabranled.TabIndex = 0;
            this.izabranled.Text = "Led diode";
            this.izabranled.UseVisualStyleBackColor = true;
            this.izabranled.Click += new System.EventHandler(this.izabranled_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(146, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Izaberite opciju";
            // 
            // izabranlcd
            // 
            this.izabranlcd.Location = new System.Drawing.Point(160, 90);
            this.izabranlcd.Name = "izabranlcd";
            this.izabranlcd.Size = new System.Drawing.Size(120, 60);
            this.izabranlcd.TabIndex = 2;
            this.izabranlcd.Text = "LCD displej";
            this.izabranlcd.UseVisualStyleBackColor = true;
            this.izabranlcd.Click += new System.EventHandler(this.izabranlcd_Click);
            // 
            // izabranservo
            // 
            this.izabranservo.Location = new System.Drawing.Point(300, 90);
            this.izabranservo.Name = "izabranservo";
            this.izabranservo.Size = new System.Drawing.Size(120, 60);
            this.izabranservo.TabIndex = 3;
            this.izabranservo.Text = "Servo motorici";
            this.izabranservo.UseVisualStyleBackColor = true;
            this.izabranservo.Click += new System.EventHandler(this.izabranservo_Click);
            // 
            // izabranbuzzer
            // 
            this.izabranbuzzer.Location = new System.Drawing.Point(440, 90);
            this.izabranbuzzer.Name = "izabranbuzzer";
            this.izabranbuzzer.Size = new System.Drawing.Size(120, 60);
            this.izabranbuzzer.TabIndex = 4;
            this.izabranbuzzer.Text = "Buzzer";
            this.izabranbuzzer.UseVisualStyleBackColor = true;
            this.izabranbuzzer.Click += new System.EventHandler(this.izabranbuzzer_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(582, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 174);
            this.Controls.Add(this.izabranbuzzer);
            this.Controls.Add(this.izabranservo);
            this.Controls.Add(this.izabranlcd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.izabranled);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arduino WPF - Izaberite sta zelite da kontrolisete";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button izabranled;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button izabranlcd;
        private System.Windows.Forms.Button izabranservo;
        private System.Windows.Forms.Button izabranbuzzer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
    }
}

