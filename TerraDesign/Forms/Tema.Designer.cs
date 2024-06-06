namespace TerraDesign.Forms
{
    partial class Tema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tema));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLS = new System.Windows.Forms.Button();
            this.buttonWF = new System.Windows.Forms.Button();
            this.buttonFVOE = new System.Windows.Forms.Button();
            this.buttonSPWR = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.enterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(238, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(435, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите вид расчёта";
            // 
            // buttonLS
            // 
            this.buttonLS.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLS.Location = new System.Drawing.Point(73, 104);
            this.buttonLS.Name = "buttonLS";
            this.buttonLS.Size = new System.Drawing.Size(304, 133);
            this.buttonLS.TabIndex = 1;
            this.buttonLS.Text = "Расчёт боковых резервов";
            this.buttonLS.UseVisualStyleBackColor = true;
            this.buttonLS.Click += new System.EventHandler(this.buttonLS_Click);
            // 
            // buttonWF
            // 
            this.buttonWF.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonWF.Location = new System.Drawing.Point(73, 295);
            this.buttonWF.Name = "buttonWF";
            this.buttonWF.Size = new System.Drawing.Size(304, 133);
            this.buttonWF.TabIndex = 2;
            this.buttonWF.Text = "Расчёт водоотводных канав";
            this.buttonWF.UseVisualStyleBackColor = true;
            this.buttonWF.Click += new System.EventHandler(this.buttonWF_Click);
            // 
            // buttonFVOE
            // 
            this.buttonFVOE.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFVOE.Location = new System.Drawing.Point(498, 104);
            this.buttonFVOE.Name = "buttonFVOE";
            this.buttonFVOE.Size = new System.Drawing.Size(304, 133);
            this.buttonFVOE.TabIndex = 3;
            this.buttonFVOE.Text = "Расчёт итоговых объёмов земляных работ";
            this.buttonFVOE.UseVisualStyleBackColor = true;
            this.buttonFVOE.Click += new System.EventHandler(this.buttonFVOE_Click);
            // 
            // buttonSPWR
            // 
            this.buttonSPWR.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSPWR.Location = new System.Drawing.Point(498, 295);
            this.buttonSPWR.Name = "buttonSPWR";
            this.buttonSPWR.Size = new System.Drawing.Size(304, 133);
            this.buttonSPWR.TabIndex = 4;
            this.buttonSPWR.Text = "Расчёт объёмов работ по рекультивации";
            this.buttonSPWR.UseVisualStyleBackColor = true;
            this.buttonSPWR.Click += new System.EventHandler(this.buttonSPWR_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SkyBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enterToolStripMenuItem,
            this.testingToolStripMenuItem,
            this.creditsToolStripMenuItem,
            this.managementToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(875, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // enterToolStripMenuItem
            // 
            this.enterToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.enterToolStripMenuItem.Name = "enterToolStripMenuItem";
            this.enterToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.enterToolStripMenuItem.Text = "Вход";
            this.enterToolStripMenuItem.Click += new System.EventHandler(this.enterStripMenuItem1_Click);
            // 
            // testingToolStripMenuItem
            // 
            this.testingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lSToolStripMenuItem,
            this.wFToolStripMenuItem});
            this.testingToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.testingToolStripMenuItem.Name = "testingToolStripMenuItem";
            this.testingToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.testingToolStripMenuItem.Text = "Тестирование";
            // 
            // lSToolStripMenuItem
            // 
            this.lSToolStripMenuItem.Name = "lSToolStripMenuItem";
            this.lSToolStripMenuItem.Size = new System.Drawing.Size(287, 24);
            this.lSToolStripMenuItem.Text = "Боковые резервы";
            this.lSToolStripMenuItem.Click += new System.EventHandler(this.lSToolStripMenuItem_Click);
            // 
            // wFToolStripMenuItem
            // 
            this.wFToolStripMenuItem.Name = "wFToolStripMenuItem";
            this.wFToolStripMenuItem.Size = new System.Drawing.Size(287, 24);
            this.wFToolStripMenuItem.Text = "Водоотводные сооружения";
            this.wFToolStripMenuItem.Click += new System.EventHandler(this.wFToolStripMenuItem_Click);
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.creditsToolStripMenuItem.Text = "О программе";
            this.creditsToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // managementToolStripMenuItem
            // 
            this.managementToolStripMenuItem.Name = "managementToolStripMenuItem";
            this.managementToolStripMenuItem.Size = new System.Drawing.Size(113, 24);
            this.managementToolStripMenuItem.Text = "Управление";
            this.managementToolStripMenuItem.Click += new System.EventHandler(this.managementToolStripMenuItem_Click);
            // 
            // Tema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(875, 477);
            this.Controls.Add(this.buttonSPWR);
            this.Controls.Add(this.buttonFVOE);
            this.Controls.Add(this.buttonWF);
            this.Controls.Add(this.buttonLS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Tema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Программа  расчётов водоотводных сооружений и объёмов земляных работ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Tema_FormClosed);
            this.Load += new System.EventHandler(this.Tema_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLS;
        private System.Windows.Forms.Button buttonWF;
        private System.Windows.Forms.Button buttonFVOE;
        private System.Windows.Forms.Button buttonSPWR;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem creditsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managementToolStripMenuItem;
    }
}