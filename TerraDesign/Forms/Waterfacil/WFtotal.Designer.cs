namespace TerraDesign.Forms.Waterfacil
{
    partial class WFtotal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFtotal));
            this.textBoxHk = new System.Windows.Forms.TextBox();
            this.labelH = new System.Windows.Forms.Label();
            this.labelDepth = new System.Windows.Forms.Label();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.labelB = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.wordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxHk
            // 
            this.textBoxHk.Location = new System.Drawing.Point(544, 140);
            this.textBoxHk.Name = "textBoxHk";
            this.textBoxHk.ReadOnly = true;
            this.textBoxHk.Size = new System.Drawing.Size(151, 29);
            this.textBoxHk.TabIndex = 14;
            // 
            // labelH
            // 
            this.labelH.AutoSize = true;
            this.labelH.Location = new System.Drawing.Point(449, 140);
            this.labelH.Name = "labelH";
            this.labelH.Size = new System.Drawing.Size(24, 24);
            this.labelH.TabIndex = 13;
            this.labelH.Text = "H";
            // 
            // labelDepth
            // 
            this.labelDepth.AutoSize = true;
            this.labelDepth.Location = new System.Drawing.Point(91, 128);
            this.labelDepth.Name = "labelDepth";
            this.labelDepth.Size = new System.Drawing.Size(152, 24);
            this.labelDepth.TabIndex = 12;
            this.labelDepth.Text = "Глубина канавы";
            // 
            // textBoxB
            // 
            this.textBoxB.Location = new System.Drawing.Point(544, 71);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.ReadOnly = true;
            this.textBoxB.Size = new System.Drawing.Size(151, 29);
            this.textBoxB.TabIndex = 11;
            // 
            // labelB
            // 
            this.labelB.AutoSize = true;
            this.labelB.Location = new System.Drawing.Point(449, 71);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(22, 24);
            this.labelB.TabIndex = 10;
            this.labelB.Text = "B";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(91, 71);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(211, 24);
            this.labelWidth.TabIndex = 9;
            this.labelWidth.Text = "Ширина канавы по дну";
            // 
            // buttonEnter
            // 
            this.buttonEnter.Location = new System.Drawing.Point(232, 214);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(269, 62);
            this.buttonEnter.TabIndex = 15;
            this.buttonEnter.Text = "Подтвердить";
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(466, 84);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(17, 16);
            this.label21.TabIndex = 92;
            this.label21.Text = "к.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(467, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 16);
            this.label5.TabIndex = 93;
            this.label5.Text = "к.";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SkyBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordToolStripMenuItem,
            this.ExcelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(785, 32);
            this.menuStrip1.TabIndex = 94;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // wordToolStripMenuItem
            // 
            this.wordToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wordToolStripMenuItem.Name = "wordToolStripMenuItem";
            this.wordToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.wordToolStripMenuItem.Text = "Перенос в Word";
            this.wordToolStripMenuItem.Click += new System.EventHandler(this.wordToolStripMenuItem_Click);
            // 
            // ExcelToolStripMenuItem
            // 
            this.ExcelToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ExcelToolStripMenuItem.Name = "ExcelToolStripMenuItem";
            this.ExcelToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.ExcelToolStripMenuItem.Text = "Перенос в Excel";
            this.ExcelToolStripMenuItem.Click += new System.EventHandler(this.ExcelToolStripMenuItem_Click);
            // 
            // WFtotal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(785, 299);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.buttonEnter);
            this.Controls.Add(this.textBoxHk);
            this.Controls.Add(this.labelH);
            this.Controls.Add(this.labelDepth);
            this.Controls.Add(this.textBoxB);
            this.Controls.Add(this.labelB);
            this.Controls.Add(this.labelWidth);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "WFtotal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Расчёт водоотводных сооружений";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WFtotal_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxHk;
        private System.Windows.Forms.Label labelH;
        private System.Windows.Forms.Label labelDepth;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem wordToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem ExcelToolStripMenuItem;
    }
}