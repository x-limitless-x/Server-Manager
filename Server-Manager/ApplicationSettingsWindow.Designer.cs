namespace Server_Manager
{
    partial class ApplicationSettingsWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.networkusagebox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.baselocationbox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.localipaddressbox = new System.Windows.Forms.TextBox();
            this.publicipaddressbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 15);
            this.label1.TabIndex = 46;
            this.label1.Text = "Default Settings Button";
            // 
            // networkusagebox
            // 
            this.networkusagebox.Location = new System.Drawing.Point(192, 227);
            this.networkusagebox.Name = "networkusagebox";
            this.networkusagebox.Size = new System.Drawing.Size(126, 20);
            this.networkusagebox.TabIndex = 45;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(25, 228);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(166, 15);
            this.label15.TabIndex = 44;
            this.label15.Text = "Maximum Bandwidth Usage:";
            // 
            // baselocationbox
            // 
            this.baselocationbox.Location = new System.Drawing.Point(192, 149);
            this.baselocationbox.Name = "baselocationbox";
            this.baselocationbox.Size = new System.Drawing.Size(126, 20);
            this.baselocationbox.TabIndex = 43;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(40, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(151, 15);
            this.label10.TabIndex = 42;
            this.label10.Text = "Application Base Location:";
            // 
            // localipaddressbox
            // 
            this.localipaddressbox.Location = new System.Drawing.Point(192, 201);
            this.localipaddressbox.Name = "localipaddressbox";
            this.localipaddressbox.Size = new System.Drawing.Size(126, 20);
            this.localipaddressbox.TabIndex = 41;
            // 
            // publicipaddressbox
            // 
            this.publicipaddressbox.Location = new System.Drawing.Point(192, 175);
            this.publicipaddressbox.Name = "publicipaddressbox";
            this.publicipaddressbox.Size = new System.Drawing.Size(126, 20);
            this.publicipaddressbox.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(65, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 15);
            this.label7.TabIndex = 39;
            this.label7.Text = "Refresh Interval for UI:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 15);
            this.label6.TabIndex = 38;
            this.label6.Text = "Application Configuration File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(197, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 25);
            this.label2.TabIndex = 37;
            this.label2.Text = "Application Settings";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 67);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(222, 32);
            this.comboBox1.TabIndex = 47;
            this.comboBox1.Text = "Game Server Settings";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(474, 67);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(147, 180);
            this.treeView1.TabIndex = 48;
            // 
            // ApplicationSettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(633, 407);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.networkusagebox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.baselocationbox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.localipaddressbox);
            this.Controls.Add(this.publicipaddressbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.Name = "ApplicationSettingsWindow";
            this.Text = "ApplicationSettingsWindow";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox networkusagebox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox baselocationbox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox localipaddressbox;
        private System.Windows.Forms.TextBox publicipaddressbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeView1;
    }
}