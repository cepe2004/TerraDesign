namespace TerraDesign.Forms.ScopeOfWorksReclamation
{
    partial class SPWRtotal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SPWRtotal));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IdRes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Square = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VRemovedVS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VRestoreR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.wordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdRes,
            this.Square,
            this.VRemovedVS,
            this.VRestoreR});
            this.dataGridView1.Location = new System.Drawing.Point(0, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1042, 552);
            this.dataGridView1.TabIndex = 0;
            // 
            // IdRes
            // 
            this.IdRes.HeaderText = "Номер резерва";
            this.IdRes.Name = "IdRes";
            // 
            // Square
            // 
            this.Square.HeaderText = "Площадь, кв.м";
            this.Square.Name = "Square";
            // 
            // VRemovedVS
            // 
            this.VRemovedVS.HeaderText = "Объём снимаемого растительного грунта, куб.м";
            this.VRemovedVS.Name = "VRemovedVS";
            this.VRemovedVS.Width = 400;
            // 
            // VRestoreR
            // 
            this.VRestoreR.HeaderText = "Объём грунта для восстановления резерва, куб.м";
            this.VRestoreR.Name = "VRestoreR";
            this.VRestoreR.Width = 400;
            // 
            // buttonEnter
            // 
            this.buttonEnter.Location = new System.Drawing.Point(403, 589);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(208, 58);
            this.buttonEnter.TabIndex = 60;
            this.buttonEnter.Text = "Подтвердить";
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.SkyBlue;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordToolStripMenuItem,
            this.ExcelToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.menuStrip2.Size = new System.Drawing.Size(1045, 32);
            this.menuStrip2.TabIndex = 97;
            this.menuStrip2.Text = "menuStrip2";
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
            // SPWRtotal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1045, 660);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.buttonEnter);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "SPWRtotal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Расчёт объёма работ по рекультивации земель";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SPWRtotal_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdRes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Square;
        private System.Windows.Forms.DataGridViewTextBoxColumn VRemovedVS;
        private System.Windows.Forms.DataGridViewTextBoxColumn VRestoreR;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem wordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExcelToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}