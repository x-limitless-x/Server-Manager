using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Server_Manager
{
    public partial class ExtendedPeformanceWindow : Form
    {
        public ExtendedPeformanceWindow()
        {
            
            InitializeComponent();
            PerformanceWindowOpen = 1;
        }

        public int PerformanceWindowOpen { get; private set; }
    }
}
