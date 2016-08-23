using Server_Manager.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Humanizer;



namespace Server_Manager
{

    public partial class MainForm : Form
    {
        public int SplitContainerClicked { get; private set; }
        public int ShowHidePerfClicked { get; private set; }
        public int MainFormActivatedvariable { get; private set; }

        private readonly PerformanceCounter _cpuPerformanceCounter = new PerformanceCounter();
        private readonly PerformanceCounter _memoryPerformanceCounter = new PerformanceCounter();
        private readonly PerformanceCounter _diskReadsPerformanceCounter = new PerformanceCounter();
        private readonly PerformanceCounter _diskWritesPerformanceCounter = new PerformanceCounter();
        private readonly PerformanceCounter _diskTransfersPerformanceCounter = new PerformanceCounter();

        public MainForm()
        {
            InitializeComponent();
            PerformanceWindowOpen = 0;

        }


        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                .IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void LoadForm(object sender, EventArgs e)
        {


            if (IsAdministrator() == false)
            {
                MessageBox.Show(
                    "This Application Requires Administrator Privileges in order to function properly.\n\nPlease Restart this Program as Administrator.",
                    "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                System.Diagnostics.Debugger.Break();

            }

            PerformanceInformationTimer.Enabled = true;

            //           Thread sampleThread = new Thread(delegate ()
            //          {

            //


            InitPerformanceCounters();


            //        });
            //      sampleThread.Start();

            cpuProgressBar.Visible = true;
            ramProgressBar.Visible = true;
            diskusageProgressBar.Visible = true;
            powerProgressBar.Visible = true;

            try
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;



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
                var upTime =
                    string.Format(
                        "Current System Uptime: {0:D0} day(s) {1:D0} hour(s) {2:D0} minute(s) {3:D0} second(s)",
                        time.Days, time.Hours, time.Minutes, time.Seconds);

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
                    ShowHidePerfClicked = 0;
                    //Change Text on Show / Hide Performance Button in Main Form to "Show Performance Information"
                    showhideperf_button.Text = "Show Performance Information";
                    showhidesplit.BackgroundImage = Resources.menu_collapse_left_button_icon;
                    showHideGamePanelToolStripMenuItem.Image = Resources.management_view_icon;

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
                    showhidesplit.BackgroundImage = Resources.menu_collapse_right_button_icon;
                    showHideGamePanelToolStripMenuItem.Image = Resources.minimalist_view_icon;

                    //                   splitContainer2.Location = new System.Drawing.Point(-1, 208);
                    splitContainer2.Width = 689;
                    splitContainer2.Panel1.Visible = true;

                    SplitContainerClicked = 0;
                    splitContainer1.Location = new System.Drawing.Point(2, 67);
                    splitContainer1.Width = 802;
                    splitContainer1.Panel1.Visible = true;
                    splitContainer1.SplitterDistance = 110;
                    //                   this.BackgroundImage = Resources._27___uMwtJTu;
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 
        /// 
        private void OpenClosesplitcontainer(object sender, EventArgs e)
        {

            if (SplitContainerClicked == 0)
            {
                //                this.BackgroundImage = null;
                showhidesplit.BackgroundImage = Resources.menu_collapse_left_button_icon;
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
                showhidesplit.BackgroundImage = Resources.menu_collapse_right_button_icon;
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
                publicipaddressbox.ForeColor = Color.White;
                localipaddressbox.ForeColor = Color.White;
                computernamebox.Text = localComputerName;
                publicipaddressbox.Text = pubIp;
                localipaddressbox.Text = LocalIp;
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



        private void SelectAll_ComputerName(object sender, MouseEventArgs e)
        {
            if (computernamebox.SelectionLength == 0)
                computernamebox.SelectAll();
            computernamebox.Focus(); //you need to call this to show selection if it doesn't have focus
        }

        private void SelectAll_PublicIP(object sender, MouseEventArgs e)
        {
            if (publicipaddressbox.SelectionLength == 0)
                publicipaddressbox.SelectAll();
            publicipaddressbox.Focus(); //you need to call this to show selection if it doesn't have focus
        }

        private void SelectAll_LocalipAddressBox(object sender, MouseEventArgs e)
        {
            if (localipaddressbox.SelectionLength == 0)
                localipaddressbox.SelectAll();
            localipaddressbox.Focus(); //you need to call this to show selection if it doesn't have focus
        }

        private void SelectAll_NetworkUsageBox(object sender, EventArgs e)
        {
            networkusagesent.SelectAll();
            networkusagesent.Focus(); //you need to call this to show selection if it doesn't have focus

        }


        // I need to add a line here to check if the user has defined a default application to run when clicking on the default "Server Settings" Menu Item that takes you to the Sub menu for the Two Selections "Application Settings" and "Game Server Settings".
        private void GameServerSettings_Clicked(object sender, EventArgs e)
        {


            GameServerSettingsForm form = new GameServerSettingsForm();
            form.ShowDialog(this);
            //form.Show(); 
            // or form.ShowDialog(this);

        }

        private void gameServerSettingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GameServerSettingsForm form = new GameServerSettingsForm();
            form.ShowDialog(this);
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Process.Start(Application.ExecutablePath); // to start new instance of application
            //this.Close(); //to turn off current app
            Dispose();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //           CounterFactory.Dispose();
            //this.Close();
            Dispose();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {




            if (ramUsageBox.SelectionLength > 0)
            {
                ramUsageBox.Copy();
            }
            if (powerUsageBox.SelectionLength > 0)
            {
                powerUsageBox.Copy();
            }
            if (diskusageBox.SelectionLength > 0)
            {
                diskusageBox.Copy();
            }
            if (localipaddressbox.SelectionLength > 0)
            {
                localipaddressbox.Copy();
            }
            if (publicipaddressbox.SelectionLength > 0)
            {
                publicipaddressbox.Copy();
            }
            if (computernamebox.SelectionLength > 0)
            // Copy the selected text to the Clipboard.
            {
                computernamebox.Copy();
            }
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


        }



        private void PerformanceWork(object sender, DoWorkEventArgs e)
        {

        }

        private void PerformanceWorkComplete(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void uptime_tick(object sender, EventArgs e)
        {
            currentUptimeLabel.Text = GetSystemUpTimeInfo();


            //START SERVICE MONITORING
            switch (serviceController1.Status)
            {
                case ServiceControllerStatus.Running:
                {
                    serviceStatus.Text = "Running";
                    return;
                }
                case ServiceControllerStatus.Stopped:
                {
                    serviceStatus.Text = "Stopped";
                    return;
                }
                case ServiceControllerStatus.Paused:
                {
                    serviceStatus.Text = "Paused";
                    return;
                }
                case ServiceControllerStatus.StopPending:
                {
                    serviceStatus.Text = "Stopping";
                    return;
                }
                case ServiceControllerStatus.StartPending:
                {
                    serviceStatus.Text = "Starting";
                    return;
                }
                default:
                {
                    serviceStatus.Text = "Status Changing";
                    return;
                }
                //STOP SERVICE MONITORING
            }
        }

        private void servicestart_clicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void servicerestart_click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            switch (serviceController1.Status)
            {
                case ServiceControllerStatus.Running:

                {
                    try
                    {
                            serviceController1.Refresh();

                        serviceController1.Stop();
                        serviceController1.WaitForStatus(ServiceControllerStatus.Stopped);

                        serviceController1.Refresh();

                        serviceController1.Start();
                        serviceController1.WaitForStatus(ServiceControllerStatus.Running);

                            serviceController1.Refresh();
                            return;
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }

                case ServiceControllerStatus.Stopped:

                {
                    try
                    {

                        serviceController1.Start();
                        serviceController1.WaitForStatus(desiredStatus: ServiceControllerStatus.Running);

                            serviceController1.Refresh();

                            return;
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
            }
        }
    

    private
            void ExtendPerformance_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ExtendedPeformanceWindow"] is ExtendedPeformanceWindow)
            {


            }
            else
            {
                ExtendedPeformanceWindow form = new ExtendedPeformanceWindow();
                form.Show(this);
            }


        }

        private void MainFormActivated(object sender, EventArgs e)
        {
            MainFormActivatedvariable = 1;
        }

        private void MainFormDeactivated(object sender, EventArgs e)
        {
            MainFormActivatedvariable = 0;

            fileToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
            editToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
            settingsToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
            viewToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
            helpToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void MainFormShown(object sender, EventArgs e)
        {
            MainFormActivatedvariable = 1;
        }

        private void InitPerformanceCounters()
        {

            this._cpuPerformanceCounter.CategoryName = "Processor";
            this._cpuPerformanceCounter.CounterName = "% Processor Time";
            this._cpuPerformanceCounter.InstanceName = "_Total";

            this._memoryPerformanceCounter.CategoryName = "Memory";
            this._memoryPerformanceCounter.CounterName = "Available MBytes";


            this._diskReadsPerformanceCounter.CategoryName = "PhysicalDisk";
            this._diskReadsPerformanceCounter.CounterName = "Disk Reads/sec";
            this._diskReadsPerformanceCounter.InstanceName = "_Total";

            this._diskWritesPerformanceCounter.CategoryName = "PhysicalDisk";
            this._diskWritesPerformanceCounter.CounterName = "Disk Writes/sec";
            this._diskWritesPerformanceCounter.InstanceName = "_Total";

            this._diskTransfersPerformanceCounter.CategoryName = "PhysicalDisk";
            this._diskTransfersPerformanceCounter.CounterName = "Disk Transfers/sec";
            this._diskTransfersPerformanceCounter.InstanceName = "_Total";


        }

        //         Note for Performance Counters (PerformanceTick)
        //         ________________________________________________________________________________
        //        | You can only read the performance counters every 100 ms
        //        | or the time difference will be too small for it to get a accurate reading,
        //        | if you read more than once every 100ms it will always report 0 or 100% usage.
        //        | Because you call NextValue() twice(once for the file, once for your stream)
        //        | the second reading will be the usage since the previous reading the line before.
        //         ________________________________________________________________________________


        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PerformanceTick(object sender, EventArgs e)
        {
            //// TryParse returns true if the conversion succeeded
            // and stores the result in j.
            // 'int' declares the integer(#) so it can use it in the command below
            // in the 'out' parameter
            //
            //             int cpuPerformanceResultInteger;
            //             if (Int32.TryParse(cpuPerformanceResult, out cpuPerformanceResultInteger))
            //             {
            //             }
            //             else
            //             {
            // 
            //             }


            //How to start a new Thread 
            //http://stackoverflow.com/questions/11811048/how-can-i-use-a-backgroundworker-with-a-timer-tick
            // less then .NET 4.0
            ////           Thread newThread = new Thread(CallTheBackgroundFunctions);
            ////           newThread.Start();

            // .NET 4.0 or higher
            // Task.Factory.StartNew(CallTheBackgroundFunctions);

            try
            {
                //cpuPerformanceCounter / Environment.ProcessorCount
 //               var unused_cpuvariable = _cpuPerformanceCounter.NextValue();

                var currentCpuUsage = this._cpuPerformanceCounter.NextValue().ToString("#");
                int currentCpuUsageInt = Int32.Parse(currentCpuUsage);

                var currentMemoryUsage = this._memoryPerformanceCounter.NextValue().ToString("#");
                int currentMemoryUsageInt = Int32.Parse(currentMemoryUsage);

                var currentDiskTransfers = _diskTransfersPerformanceCounter.NextValue().ToString("#");
                int currentDiskTransfersInt = Int32.Parse(currentDiskTransfers);


                //                var unused_var = _cpuPerformanceCounter.NextValue();


                cpuUsageBox.Text = currentCpuUsage + "%";
                cpuProgressBar.Value = currentCpuUsageInt;


                ramUsageBox.Text = currentMemoryUsage;
                ramProgressBar.Value = currentMemoryUsageInt;


                diskusageBox.Text = currentDiskTransfers + "%";
                diskusageProgressBar.Value = currentDiskTransfersInt;




            }
            catch (Exception)
            {
//                 cpuUsageBox.Text = "Cannot Access";
//                 ramUsageBox.Text = "Cannot Access";
//                 diskusageBox.Text = "Cannot Access";
            }

            new Thread(delegate()
            {
                while (Enabled)
                {
                    DoSomeAction();
                }
            }).Start();
            
    }

        private void DoSomeAction()
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(100));

            Thread.CurrentThread.Abort();
        }

        //Start Changing Colors of Menu Items
        //Change Color

        private void file_ChangeColor(object sender, EventArgs e)

        {
            if (MainFormActivatedvariable == 1)
            {
                fileToolStripMenuItem.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void edit_ChangeColor(object sender, EventArgs e)
        {
            if (MainFormActivatedvariable == 1)
            {
                editToolStripMenuItem.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void settings_ChangeColor(object sender, EventArgs e)
        {
            if (MainFormActivatedvariable == 1)
            {
                settingsToolStripMenuItem.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void view_ChangeColor(object sender, EventArgs e)
        {
            if (MainFormActivatedvariable == 1)
            {
                viewToolStripMenuItem.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void help_ChangeColor(object sender, EventArgs e)
        {
            if (MainFormActivatedvariable == 1)
            {
                helpToolStripMenuItem.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void file_DropDownClosed(object sender, EventArgs e)
        {
            if (MainFormActivatedvariable == 1)
            {
                fileToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
            }
        }

        private void edit_DropDownClosed(object sender, EventArgs e)
        {
            if (MainFormActivatedvariable == 1)
            {
                editToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
            }
        }

        private void settings_DropDownClosed(object sender, EventArgs e)
        {
            if (MainFormActivatedvariable == 1)
            {
                settingsToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
            }
        }

        private void view_DropDownClosed(object sender, EventArgs e)
        {
            if (MainFormActivatedvariable == 1)
            {
                viewToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
            }
        }

        private void help_DropDownClosed(object sender, EventArgs e)
        {
            if (MainFormActivatedvariable == 1)
            {
                helpToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
            }
        }

        private void UpdateUI_tick(object sender, EventArgs e)
        {
           // cpuProgressBar.Value = currentCpuUsage;
//             cpuUsageBox.Text = currentCpuUsage;
//             ramUsageBox.Text = currentMemoryUsage;
//             diskusageBox.Text = currentDiskTransfers;

            if (SplitContainerClicked == 0)
            {
                showHideGamePanelToolStripMenuItem.Image = Resources.minimalist_view_icon;
                showhidesplit.BackgroundImage = Resources.menu_collapse_left_button_icon;
                showHideGamePanelToolStripMenuItem.Text = "Switch to Minimalist View";
            }
            else
            {
                showHideGamePanelToolStripMenuItem.Image = Resources.management_view_icon;
                showhidesplit.BackgroundImage = Resources.menu_collapse_right_button_icon;
                showHideGamePanelToolStripMenuItem.Text = "Switch to Management View";
            }
        }

        private void applicationServerSettings_Clicked(object sender, EventArgs e)
        {
            ApplicationSettingsWindow form = new ApplicationSettingsWindow();
            form.ShowDialog(this);
            //form.Show(); 
            // or form.ShowDialog(this);
        }
    }
}
