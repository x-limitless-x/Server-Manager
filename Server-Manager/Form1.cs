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
using System.Threading;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.ServiceProcess;
using System.Runtime.InteropServices;
using Humanizer;
using System.Management;
using Microsoft.VisualBasic;
using System.Security.Principal;

namespace Server_Manager
{

    public partial class Form1 : Form
    {



        public string networkusageSentVar { get; private set; }
        public string performanceCounterSent { get; private set; }
        public int SplitContainerClicked { get; private set; }
        public int ShowHidePerfClicked { get; private set; }

        private PerformanceCounter cpuPerformanceCounter = new PerformanceCounter();
        private PerformanceCounter memoryPerformanceCounter = new PerformanceCounter();
        private PerformanceCounter diskReadsPerformanceCounter = new PerformanceCounter();
        private PerformanceCounter diskWritesPerformanceCounter = new PerformanceCounter();
        private PerformanceCounter diskTransfersPerformanceCounter = new PerformanceCounter();


        public int bytesSentSpeed = 0;
        public int bytesReceivedSpeed = 0;

        public Form1()
        {
            InitializeComponent();
            PerformanceWindowOpen = 0;
        }

        

        private void LoadForm(object sender, EventArgs e)
        {


            if (IsAdministrator() == false)
            {
                MessageBox.Show("This Application Requires Administrator Privileges in order to function properly.\nPlease Restart this Program as Administrator");
                this.Close(); //to turn off current app
            }

            PerformanceInformationTimer.Enabled = true;

            InitPerformanceCounters();
            //           Thread sampleThread = new Thread(delegate ()
            //          {

            //





            //        });
            //      sampleThread.Start();

            try
            {




                IPv4InterfaceStatistics interfaceStats =
                    NetworkInterface.GetAllNetworkInterfaces()[0].GetIPv4Statistics();
                bytesSentSpeed = (int) (interfaceStats.BytesSent - bytesSentSpeed)/1024;
                bytesReceivedSpeed = (int) (interfaceStats.BytesReceived - bytesReceivedSpeed)/1024;


                string pubIp = new System.Net.WebClient().DownloadString("https://api.ipify.org");
                string localComputerName = Dns.GetHostName();
                string LocalIp = LocalIPAddress().ToString();
                SplitContainerClicked = 0;

                ShowHidePerfClicked = 2;

                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

                computernamebox.Text = localComputerName;
                publicipaddressbox.Text = pubIp;
                localipaddressbox.Text = LocalIp;
            }
            catch (Exception)
            {
                //handle the exception your way

            }
        }




        private static String GetSystemUpTimeInfo()
        {

            try
            {
                var time = GetSystemUpTime();
                var upTime = string.Format("Current System Uptime: {0:D0} day(s) {1:D0} hour(s) {2:D0} minute(s) {3:D0} second(s)", time.Days, time.Hours, time.Minutes, time.Seconds);

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

        //https://social.msdn.microsoft.com/Forums/windows/en-US/c27693d2-9b4e-4395-9e90-402a6af96307/splitcontainer-flickering-issue-while-resizing-it?forum=winforms
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public int PerformanceWindowOpen { get; private set; }

        private void MinimalistView_Clicked(object sender, EventArgs e)
        {
            {

                if (SplitContainerClicked == 0)
                {
 //                   this.BackgroundImage = null;
                    //Change Button Variable for ShowHidePerfClicked to "2"
                    ShowHidePerfClicked = 2;
                    //Change Text on Show / Hide Performance Button in Main Form to "Show Performance Information"
                    showhideperf_button.Text = "Show Performance Information";
                    showhidesplit.BackgroundImage = Resources.menucollapseleft;
                    showHideGamePanelToolStripMenuItem.Image = Resources.eyemgmt;

                    //                   splitContainer2.Location = new System.Drawing.Point(-5, 208);
                    splitContainer2.Width = 832;
                    splitContainer2.Panel1.Visible = false;



                    SplitContainerClicked = 1;
                    splitContainer1.Location = new System.Drawing.Point(-30, 67);
                    splitContainer1.Width = 832;

                    splitContainer1.SplitterDistance = 0;

                    splitContainer1.Panel1.Visible = false;
//                    this.BackgroundImage = Resources._27___uMwtJTu;
                }
                else
                {
//                    this.BackgroundImage = null;
                    ShowHidePerfClicked = 1;
                    showhideperf_button.Text = "Hide Performance Information";
                    showhidesplit.BackgroundImage = Resources.menucollapseright;
                    showHideGamePanelToolStripMenuItem.Image = Resources.eyemini;

                    //                   splitContainer2.Location = new System.Drawing.Point(-1, 208);
                    splitContainer2.Width = 689;
                    splitContainer2.Panel1.Visible = true;

                    splitContainer1.Location = new System.Drawing.Point(2, 67);
                    splitContainer1.Width = 802;
                    splitContainer1.Panel1.Visible = true;
                    splitContainer1.SplitterDistance = 110;
                    SplitContainerClicked = 0;
 //                   this.BackgroundImage = Resources._27___uMwtJTu;
                }
            }
        }

        private void OpenClosesplitcontainer(object sender, EventArgs e)
        {


            //Split Container Change Background Image. (NEED GLOBAL VARIABLE DEFINED)

            if (SplitContainerClicked == 0)
            {
//                this.BackgroundImage = null;
                showhidesplit.BackgroundImage = Resources.menucollapseleft;
                splitContainer2.Location = new System.Drawing.Point(-5, 208);
                splitContainer2.Width = 832;

                splitContainer1.Location = new System.Drawing.Point(-30, 67);
                splitContainer1.Width = 832;
                splitContainer1.Panel1.Visible = false;
                splitContainer1.SplitterDistance = 0;
                SplitContainerClicked = 1;
 //               this.BackgroundImage = Resources._27___uMwtJTu;
            }
            else
            {
//                this.BackgroundImage = null;
                showhidesplit.BackgroundImage = Resources.menucollapseright;
                splitContainer2.Location = new System.Drawing.Point(-1, 208);
                splitContainer2.Width = 689;

                splitContainer1.Location = new System.Drawing.Point(2, 67);
                splitContainer1.Width = 802;
                splitContainer1.Panel1.Visible = true;
                splitContainer1.SplitterDistance = 110;
                SplitContainerClicked = 0;
 //               this.BackgroundImage = Resources._27___uMwtJTu;
            }
        }

        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                    .IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void ShowHidePerfButton(object sender, EventArgs e)
        {
            if (ShowHidePerfClicked == 1)
            {
                splitContainer2.Panel1.Visible = false;
                showhideperf_button.Text = "Show Performance Information";
                ShowHidePerfClicked = 0;
            }
            else if (ShowHidePerfClicked == 0)
            {
                splitContainer2.Panel1.Visible = true;
                showhideperf_button.Text = "Hide Performance Information";
                ShowHidePerfClicked = 1;
            }
            else if (ShowHidePerfClicked == 2)
            {
                splitContainer2.Panel1.Visible = false;
                showhideperf_button.Text = "Show Performance Information";
                ShowHidePerfClicked = 0;
            }

        }

        private void ConnectivityCheck_tick(object sender, EventArgs e)
        {
            //Retrieve IP Status
            try
            {

                string localComputerName = Dns.GetHostName();
                string pubIp = new System.Net.WebClient().DownloadString("https://api.ipify.org");
                string LocalIp = LocalIPAddress().ToString();

                //Start Naming Controls
                computernamebox.Text = localComputerName;
                publicipaddressbox.Text = pubIp;
                localipaddressbox.Text = LocalIp;
                publicipaddressbox.ForeColor = Color.White;
                localipaddressbox.ForeColor = Color.White;
            }
            //            catch (SocketException ex)
            //           {
            //                publicipaddressbox.Text = "Cannot Retrieve Your IP";
            //                localipaddressbox.Text = "Cannot Retrieve Your IP";
            //                Thread.Sleep(500);
            //            }
            catch (Exception)
            {
                publicipaddressbox.Text = "No Connectivity";
                localipaddressbox.Text = "No Connectivity";
                publicipaddressbox.ForeColor = Color.Crimson;
                localipaddressbox.ForeColor = Color.Crimson;

                //catch all other exceptions



            }



        }



        private void SelectAll_ComputerName(object sender, EventArgs e)
        {
            computernamebox.SelectAll();
            computernamebox.Focus(); //you need to call this to show selection if it doesn't has focus
        }

        private void SelectAll_PublicIP(object sender, EventArgs e)
        {
            publicipaddressbox.SelectAll();
            publicipaddressbox.Focus(); //you need to call this to show selection if it doesn't has focus

        }

        private void SelectAll_LocalipAddressBox(object sender, EventArgs e)
        {
            localipaddressbox.SelectAll();
            localipaddressbox.Focus(); //you need to call this to show selection if it doesn't has focus

        }

        private void SelectAll_NetworkUsageBox(object sender, EventArgs e)
        {
            networkusagesent.SelectAll();
            networkusagesent.Focus(); //you need to call this to show selection if it doesn't has focus

        }



        private void GameServerSettings_Clicked(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            form.ShowDialog(this);
            //form.Show(); // or form.ShowDialog(this

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
            this.Close(); //to turn off current app
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Clipboard.SetText(this.ActiveControl.Name);
        }

        private void DoNothing(object sender, EventArgs e)
        {
            return;
        }


        private void ping_timer(object sender, EventArgs e)
        {
            currentPing.ForeColor = Color.White;

            try
            {
                using (Ping p = new Ping())
                {
                    currentPing.Text = "Current Ping: " + p.Send("4.2.2.1").RoundtripTime.ToString() + "ms";
                }
                serviceController1.Refresh();
                pictureBox3.Visible = false;
                pictureBox2.Visible = true;
                currentPing.ForeColor = Color.White;
            }
            catch (Exception)
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
                currentPing.Text = "Cannot Ping";
                currentPing.ForeColor = Color.Crimson;
            }
           

            //START SERVICE MONITORING
            switch (serviceController1.Status)
            {
                case ServiceControllerStatus.Running:
                    serviceStatus.Text = "Running";
                    return;
                case ServiceControllerStatus.Stopped:
                    serviceStatus.Text = "Stopped";
                    return;
                case ServiceControllerStatus.Paused:
                    serviceStatus.Text = "Paused";
                    return;
                case ServiceControllerStatus.StopPending:
                    serviceStatus.Text = "Stopping";
                    return;
                 case ServiceControllerStatus.StartPending:
                    serviceStatus.Text = "Starting";
                    return;
                default:
                    serviceStatus.Text = "Status Changing";
                    return;


            }
        }

        //Start Changing Colors of Menu Items

        private void file_ChangeColor(object sender, EventArgs e)
        {
            fileToolStripMenuItem.ForeColor = Color.FromArgb(0, 0, 0);
        }

        private void edit_ChangeColor(object sender, EventArgs e)
        {
            editToolStripMenuItem.ForeColor = Color.FromArgb(0, 0, 0);
        }

        private void settings_ChangeColor(object sender, EventArgs e)
        {
            settingsToolStripMenuItem.ForeColor = Color.FromArgb(0, 0, 0);
        }

        private void view_ChangeColor(object sender, EventArgs e)
        {
            viewToolStripMenuItem.ForeColor = Color.FromArgb(0, 0, 0);
        }

        private void help_ChangeColor(object sender, EventArgs e)
        {
            helpToolStripMenuItem.ForeColor = Color.FromArgb(0, 0, 0);
        }

        private void file_DropDownClosed(object sender, EventArgs e)
        {
            fileToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void edit_DropDownClosed(object sender, EventArgs e)
        {
            editToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void settings_DropDownClosed(object sender, EventArgs e)
        {
            settingsToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void view_DropDownClosed(object sender, EventArgs e)
        {
            viewToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
        }


        private void help_DropDownClosed(object sender, EventArgs e)
        {
            helpToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void InitPerformanceCounters()
        {

            this.cpuPerformanceCounter.CategoryName = "Processor";
            this.cpuPerformanceCounter.CounterName = "% Processor Time";
            this.cpuPerformanceCounter.InstanceName = "_Total";

            this.memoryPerformanceCounter.CategoryName = "Memory";
            this.memoryPerformanceCounter.CounterName = "Available MBytes";


            this.diskReadsPerformanceCounter.CategoryName = "PhysicalDisk";
            this.diskReadsPerformanceCounter.CounterName = "Disk Reads/sec";
            this.diskReadsPerformanceCounter.InstanceName = "_Total";

            this.diskWritesPerformanceCounter.CategoryName = "PhysicalDisk";
            this.diskWritesPerformanceCounter.CounterName = "Disk Writes/sec";
            this.diskWritesPerformanceCounter.InstanceName = "_Total";

            this.diskTransfersPerformanceCounter.CategoryName = "PhysicalDisk";
            this.diskTransfersPerformanceCounter.CounterName = "Disk Transfers/sec";
            this.diskTransfersPerformanceCounter.InstanceName = "_Total";


        }


        private void Performance_tick(object sender, EventArgs e)
        {

            try
            {
                //cpuPerformanceCounter / Environment.ProcessorCount
                

                var currentCpuUsage = this.cpuPerformanceCounter.NextValue().ToString("#.#") + "%";

                var currentMemoryUsage = this.memoryPerformanceCounter.NextValue().ToString("# MB");
                var currentDiskTransfers = this.diskTransfersPerformanceCounter.NextValue().ToString("# MB");


                

                cpuUsageBox.Text = currentCpuUsage;
                ramUsageBox.Text = currentMemoryUsage;
                diskusageBox.Text = currentDiskTransfers;

            }
            catch (Exception)
            {

            }
            //Start Network Speed Monitoring

            if (SplitContainerClicked == 0)
            {

                showhidesplit.BackgroundImage = Resources.menucollapseleft;
                showHideGamePanelToolStripMenuItem.Text = "Switch to Minimalist View";
            }
            else
            {

                showhidesplit.BackgroundImage = Resources.menucollapseright;
                showHideGamePanelToolStripMenuItem.Text = "Switch to Management View";
            }


        }

        private void PerformanceWork(object sender, DoWorkEventArgs e)
        {

        }

        private void uptime_tick(object sender, EventArgs e)
        {
            currentUptimeLabel.Text = GetSystemUpTimeInfo();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
       {
            try
            {
                serviceController1.Start();
                serviceController1.WaitForStatus(desiredStatus: ServiceControllerStatus.Running);
            }
            catch (Exception)
            {
                
                
            }

        }

        private void servicestop_click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                serviceController1.Stop();
                serviceController1.WaitForStatus(desiredStatus: ServiceControllerStatus.Stopped);
            }
            catch (Exception)
            {
                
                
            }
            
        }

        private void ExtendPerformance_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["ExtendedPeformanceWindow"] as ExtendedPeformanceWindow != null)
            {
                
                
            }
            else
            {
                ExtendedPeformanceWindow form = new ExtendedPeformanceWindow();
                form.Show(this);
            }


        }
    }
    }

