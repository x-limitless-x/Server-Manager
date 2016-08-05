namespace Server_Manager
{
    partial class SettingsForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.networkusagebox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.computernamebox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.localipaddressbox = new System.Windows.Forms.TextBox();
            this.publicipaddressbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(254, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Game Server Settings";
            // 
            // networkusagebox
            // 
            this.networkusagebox.Location = new System.Drawing.Point(192, 221);
            this.networkusagebox.Name = "networkusagebox";
            this.networkusagebox.Size = new System.Drawing.Size(126, 20);
            this.networkusagebox.TabIndex = 34;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(55, 221);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(137, 15);
            this.label15.TabIndex = 33;
            this.label15.Text = "Current Network Usage:";
            // 
            // computernamebox
            // 
            this.computernamebox.Location = new System.Drawing.Point(192, 143);
            this.computernamebox.Name = "computernamebox";
            this.computernamebox.Size = new System.Drawing.Size(126, 20);
            this.computernamebox.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(29, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(163, 15);
            this.label10.TabIndex = 31;
            this.label10.Text = "Game Server Base Location:";
            // 
            // localipaddressbox
            // 
            this.localipaddressbox.Location = new System.Drawing.Point(192, 195);
            this.localipaddressbox.Name = "localipaddressbox";
            this.localipaddressbox.Size = new System.Drawing.Size(126, 20);
            this.localipaddressbox.TabIndex = 30;
            // 
            // publicipaddressbox
            // 
            this.publicipaddressbox.Location = new System.Drawing.Point(192, 169);
            this.publicipaddressbox.Name = "publicipaddressbox";
            this.publicipaddressbox.Size = new System.Drawing.Size(126, 20);
            this.publicipaddressbox.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(93, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 15);
            this.label7.TabIndex = 28;
            this.label7.Text = "Designated Port:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(181, 15);
            this.label6.TabIndex = 27;
            this.label6.Text = "Game Server Configuration File:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 15);
            this.label1.TabIndex = 35;
            this.label1.Text = "Select Your Game";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 61);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(222, 32);
            this.comboBox1.TabIndex = 36;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(760, 437);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.networkusagebox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.computernamebox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.localipaddressbox);
            this.Controls.Add(this.publicipaddressbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Game Server Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox networkusagebox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox computernamebox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox localipaddressbox;
        private System.Windows.Forms.TextBox publicipaddressbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}