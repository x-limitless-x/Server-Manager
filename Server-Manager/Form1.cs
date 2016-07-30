using Server_Manager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;

namespace Server_Manager
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        
        private void LoadForm(object sender, EventArgs e)
        {
            string pubIp = new System.Net.WebClient().DownloadString("https://api.ipify.org");
            string localComputerName = Dns.GetHostName();
            string LocalIp = LocalIPAddress().ToString();

            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

            computernamebox.Text = localComputerName;
            publicipaddressbox.Text = pubIp;
            localipaddressbox.Text = LocalIp;
        }



        private static String GetSystemUpTimeInfo()
        {

            try
            {
                var time = GetSystemUpTime();
                var upTime = string.Format("{0:D2} hours {1:D2} minutes {2:D2} seconds", time.Hours, time.Minutes, time.Seconds);

                return String.Format("{0}", upTime);
            }

            catch (Exception)
            {
                //handle the exception your way
                return String.Empty;
            }
        }

        private static TimeSpan GetSystemUpTime()
        {
            try
            {
                using (var uptime = new PerformanceCounter("System", "System Up Time"))
                {
                    uptime.NextValue();
                    return TimeSpan.FromSeconds(uptime.NextValue());
                }
            }
            catch (Exception)
            {
                //handle the exception your way
                return new TimeSpan(0, 0, 0, 0);
            }
        }

        private IPAddress LocalIPAddress()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return null;
            }

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            return host
                .AddressList
                .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        }

        private void ReturnToCurrentServerName(object sender, EventArgs e)
        {
            //TO-DO: Assign variable when button selected so we can know what game to put here.
            //Will need to assign game name when setting up game server. Will work on a Pre-Definied list.

            statuslabelServerSelection.Text = "Project Zomboid";
        }

        private void ProjectZomboidMouseEnter(object sender, EventArgs e)
        {
            statuslabelServerSelection.Text = "Project Zomboid";
        }

        private void KillingFloor2MouseEnter(object sender, EventArgs e)
        {
            statuslabelServerSelection.Text = "Killing Floor 2";
        }

        private void MurmurServerMouseEnter(object sender, EventArgs e)
        {
            statuslabelServerSelection.Text = "Murmur Server";
        }

        private void OpenClosesplitcontainer(object sender, EventArgs e)
        {
            int SplitContainerClicked = 0;

            //Split Container Change Background Image. (NEED GLOBAL VARIABLE DEFINED)
            if (SplitContainerClicked != 0)
        { 
            showhidesplit.BackgroundImage = Resources.menucollapseleft;
        }
           else
        {
                // bool SplitContainerClicked = true;
                showhidesplit.BackgroundImage = Resources.menucollapseright;
           }          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //GetSystemUpTimeInfo();

            currentUptimeLabel.Text = GetSystemUpTimeInfo();

        }


    }


}