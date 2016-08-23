using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_Manager
{
    public partial class ApplicationSettingsWindow : Form
    {
        public ApplicationSettingsWindow()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            baselocationbox.Text = AppDomain.CurrentDomain.BaseDirectory;

        }
    }
}
