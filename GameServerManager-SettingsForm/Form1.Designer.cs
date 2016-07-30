namespace GameServerManager_SettingsForm
{
    partial class GameServerSettingsForm
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
            this.networkusage = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.computernamebox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.localipaddressbox = new System.Windows.Forms.TextBox();
            this.publicipaddressbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).BeginInit();
            this.SuspendLayout();
            // 
            // networkusage
            // 
            this.networkusage.Location = new System.Drawing.Point(206, 182);
            this.networkusage.Name = "networkusage";
            this.networkusage.Size = new System.Drawing.Size(126, 20);
            this.networkusage.TabIndex = 34;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(63, 184);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(137, 15);
            this.label15.TabIndex = 33;
            this.label15.Text = "Current Network Usage:";
            // 
            // computernamebox
            // 
            this.computernamebox.Location = new System.Drawing.Point(206, 104);
            this.computernamebox.MaxLength = 6253;
            this.computernamebox.Name = "computernamebox";
            this.computernamebox.Size = new System.Drawing.Size(126, 20);
            this.computernamebox.TabIndex = 32;
            this.computernamebox.WordWrap = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(64, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 15);
            this.label10.TabIndex = 31;
            this.label10.Text = "Location of Game Files:";
            // 
            // localipaddressbox
            // 
            this.localipaddressbox.Location = new System.Drawing.Point(206, 156);
            this.localipaddressbox.Name = "localipaddressbox";
            this.localipaddressbox.Size = new System.Drawing.Size(126, 20);
            this.localipaddressbox.TabIndex = 30;
            // 
            // publicipaddressbox
            // 
            this.publicipaddressbox.Location = new System.Drawing.Point(206, 130);
            this.publicipaddressbox.Name = "publicipaddressbox";
            this.publicipaddressbox.Size = new System.Drawing.Size(126, 20);
            this.publicipaddressbox.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(42, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 15);
            this.label7.TabIndex = 28;
            this.label7.Text = "Current Local IP Address(s):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(199, 15);
            this.label6.TabIndex = 27;
            this.label6.Text = "Settings File Location (settings.cfg):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 24);
            this.label1.TabIndex = 35;
            this.label1.Text = "Current Game:";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Are",
            "Cool",
            "Words"});
            this.comboBox1.Location = new System.Drawing.Point(163, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(183, 32);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 36;
            this.comboBox1.Text = "Test Text";
            // 
            // GameServerSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(654, 434);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.networkusage);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.computernamebox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.localipaddressbox);
            this.Controls.Add(this.publicipaddressbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "GameServerSettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Server Settings";
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox networkusage;
        private System.Windows.Forms.Label label15;
        protected internal System.Windows.Forms.TextBox computernamebox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox localipaddressbox;
        private System.Windows.Forms.TextBox publicipaddressbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Diagnostics.PerformanceCounter performanceCounter1;
    }
}

