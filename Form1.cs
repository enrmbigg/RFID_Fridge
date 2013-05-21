using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Phidgets; //Needed for the RFID class and the PhidgetException class
using Phidgets.Events; //Needed for the phidget event handling classes

namespace RFID_Fridge
{
    public partial class Form1 : Form
    {
        private RFID rfid; //Declare an RFID object
        private ErrorEventBox errorBox;

        //Variables
        public int NumItems = 0; //Number of items in fridge.

        //Classes        
        Food food;
        FridgeItem fridgeitem;

        public struct Food
        {
            public string Name;
            public string Tag;
        }

        public struct FridgeItem
        {
            public string Name;
            public string Tag;
            public DateTime DateAdded;
            public int Quantity;
        }

        Food[] foodDBArr = new Food[10];
        FridgeItem[] fridgeDBArr = new FridgeItem[10];

        public Form1()
        {
            InitializeComponent();
            errorBox = new ErrorEventBox();            
        }

        //initialize our Phidgets RFID reader and hook the event handlers
        private void Form1_Load(object sender, EventArgs e)
        {
            rfid = new RFID();
            rfid.Attach += new AttachEventHandler(rfid_Attach);
            rfid.Detach += new DetachEventHandler(rfid_Detach);
            rfid.Error += new ErrorEventHandler(rfid_Error);
            rfid.Tag += new TagEventHandler(rfid_Tag);
            rfid.TagLost += new TagEventHandler(rfid_TagLost);
            //Disabled controls until Phidget is attached
            antennaChk.Enabled = false;
            ledChk.Enabled = false;
            output0Chk.Enabled = false;
            output1chk.Enabled = false;
            openCmdLine(rfid);

            //Generate Food!
            food.Name = "Apple";
            food.Tag = "1000e328f3";
            foodDBArr[0] = food;

            food.Name = "Bannana";
            food.Tag = "1000fa9b29";
            foodDBArr[1] = food;

            food.Name = "Cauliflower";
            food.Tag = "110057e4b5";
            foodDBArr[2] = food;

            food.Name = "Dates";
            food.Tag = "1000fa9b18";
            foodDBArr[3] = food;

            food.Name = "Eggs";
            food.Tag = "1000e31d55";
            foodDBArr[4] = food;
        }

        public void FindNumItems()
        {
            //Find number of items in fridge
            NumItems = 0;
            int i = 0;
            while (fridgeDBArr[i].Name != null)
            {
                NumItems++;
                i++;
            }
            i = 0;
        }

        public void DisplayContents()
        {
            tbxContents.Clear();
            for (int i = 0; i <= NumItems; i++)
            {
                if (fridgeDBArr[i].Quantity > 0) //Means that items with quantity of 0 are still left in the system and not deleted.
                    tbxContents.AppendText(fridgeDBArr[i].Name + "      x" + fridgeDBArr[i].Quantity.ToString() + "     (" + fridgeDBArr[i].DateAdded.ToString("d") + ") " + "\r\n");
            }
        }    

        //attach event handler..populate the details fields as well as display the attached status.  enable the checkboxes to change
        //the values of the attributes of the RFID reader such as enable or disable the antenna and onboard led.
        void rfid_Attach(object sender, AttachEventArgs e)
        {
            RFID attached = (RFID)sender;
            attachedTxt.Text = attached.Attached.ToString();    
            if (rfid.outputs.Count > 0)
            {
                antennaChk.Checked = true;
                rfid.Antenna = true;
                antennaChk.Enabled = true;
                ledChk.Enabled = true;
                output0Chk.Enabled = true;
                output1chk.Enabled = true;
            }
        }

        //detach event handler...clear all the fields, display the attached status, and disable the checkboxes.
        void rfid_Detach(object sender, DetachEventArgs e)
        {
            RFID detached = (RFID)sender;
            attachedTxt.Text = detached.Attached.ToString();    

            if (rfid.outputs.Count > 0)
            {
                antennaChk.Enabled = false;
                ledChk.Enabled = false;
                output0Chk.Enabled = false;
                output1chk.Enabled = false;
            }
        }

        void rfid_Error(object sender, ErrorEventArgs e)
        {
            Phidget phid = (Phidget)sender;
            DialogResult result;
            switch (e.Type)
            {
                case PhidgetException.ErrorType.PHIDGET_ERREVENT_BADPASSWORD:
                    phid.close();
                    TextInputBox dialog = new TextInputBox("Error Event",
                        "Authentication error: This server requires a password.", "Please enter the password, or cancel.");
                    result = dialog.ShowDialog();
                    if (result == DialogResult.OK)
                        openCmdLine(phid, dialog.password);
                    else
                        Environment.Exit(0);
                    break;
                default:
                    if (!errorBox.Visible)
                        errorBox.Show();
                    break;
            }
            errorBox.addMessage(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + ": " + e.Description);
        }

        //Tag event handler...we'll display the tag code in the field on the GUI
        void rfid_Tag(object sender, TagEventArgs e)
        {
            rfid.outputs[1] = true; //Turn on LED to show scanning.
            tagTxt.Text = e.Tag;

            bool found = false;
            for (int x = 0; x < fridgeDBArr.Length; x++)
            {
                if (fridgeDBArr[x].Tag == e.Tag)
                {
                    if (RemoveChk.Checked == true)
                    {
                        if (fridgeDBArr[x].Quantity >= 1)
                        {
                            fridgeDBArr[x].Quantity--; //If item already in fridge then increase quantity.
                            if (fridgeDBArr[x].Quantity == 0)
                                MessageBox.Show("You're out of " + fridgeDBArr[x].Name + "s!"); //Must be 0 so buy more!
                            else                            
                                MessageBox.Show("There are now " + fridgeDBArr[x].Quantity.ToString() + " " + fridgeDBArr[x].Name + "s in the fridge!");
                        }                           
                    }
                    else
                    {
                        fridgeDBArr[x].Quantity++; //If item already in fridge then increase quantity.
                        MessageBox.Show("There are now " + fridgeDBArr[x].Quantity.ToString() + " " + fridgeDBArr[x].Name + "s in the fridge!");
                    }
                    found = true;
                }
            }
            
            //If its not found then check DB.
            if (found == false)
            {
                for (int i = 0; i < foodDBArr.Length; i++)
                {
                    if (foodDBArr[i].Tag == e.Tag)
                    {   //Item found in DB so add to fridge.
                        found = true;
                        fridgeitem.Name = foodDBArr[i].Name;
                        fridgeitem.Tag = foodDBArr[i].Tag;
                        fridgeitem.DateAdded = DateTime.Today;
                        fridgeitem.Quantity = 1;
                        FindNumItems(); //Find how many items in fridge.
                        fridgeDBArr[NumItems] = fridgeitem;
                        MessageBox.Show(foodDBArr[i].Name + " entered the fridge!");
                    }             
                }
            }
            if (found == false)
                MessageBox.Show("Item not found in database!");
            found = false; //reset found marker.

            DisplayContents(); // Update the textbox.

            //This sends the RFID tag and an enter to the active application
            if (keyboardCheckBox.Checked == true)
            {
                SendKeys.Send(e.Tag);
                SendKeys.Send("{ENTER}");
            }
        }

        //Tag lost event handler...here we simply want to clear our tag field in the GUI
        void rfid_TagLost(object sender, TagEventArgs e)
        {
            tagTxt.Text = "";
            foodTxt.Text = "";
            //protoTxt.Text = "";
            rfid.outputs[1] = false;
        }

        //Enable or disable the RFID antenna by clicking the checkbox
        private void antennaChk_CheckedChanged(object sender, EventArgs e)
        {
            rfid.Antenna = antennaChk.Checked;
        }

        //turn on and off the onboard LED by clicking the checkox
        private void ledChk_CheckedChanged(object sender, EventArgs e)
        {
            rfid.LED = ledChk.Checked;
        }

        //turn on and off output 0, to light a LED for example
       private void output0Chk_CheckedChanged(object sender, EventArgs e)
        {
            rfid.outputs[0] = output0Chk.Checked;
        }

        //turn on and off output 1, to light a LED for example
        private void output1chk_CheckedChanged(object sender, EventArgs e)
        {
            rfid.outputs[1] = output1chk.Checked;
        }

        //When the application is being terminated, close the Phidget.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            rfid.Attach -= new AttachEventHandler(rfid_Attach);
            rfid.Detach -= new DetachEventHandler(rfid_Detach);
            rfid.Tag -= new TagEventHandler(rfid_Tag);
            rfid.TagLost -= new TagEventHandler(rfid_TagLost);
            //to ensure that the led dont burn out when not active
            rfid.LED = false;
            rfid.outputs[0] = false;
            rfid.outputs[1] = false;            

            //run any events in the message queue - otherwise close will hang if there are any outstanding events
            Application.DoEvents();
            rfid.close();        }

        
        //Parses command line arguments and calls the appropriate open
        #region Command line open functions
        private void openCmdLine(Phidget p)
        {
            openCmdLine(p, null);
        }
        private void openCmdLine(Phidget p, String pass)
        {
            int serial = -1;
            int port = 5001;
            String host = null;
            bool remote = false, remoteIP = false;
            string[] args = Environment.GetCommandLineArgs();
            String appName = args[0];

            try
            { //Parse the flags
                for (int i = 1; i < args.Length; i++)
                {
                    if (args[i].StartsWith("-"))
                        switch (args[i].Remove(0, 1).ToLower())
                        {
                            case "n":
                                serial = int.Parse(args[++i]);
                                break;
                            case "r":
                                remote = true;
                                break;
                            case "s":
                                remote = true;
                                host = args[++i];
                                break;
                            case "p":
                                pass = args[++i];
                                break;
                            case "i":
                                remoteIP = true;
                                host = args[++i];
                                if (host.Contains(":"))
                                {
                                    port = int.Parse(host.Split(':')[1]);
                                    host = host.Split(':')[0];
                                }
                                break;
                            default:
                                goto usage;
                        }
                    else
                        goto usage;
                }

                if (remoteIP)
                    p.open(serial, host, port, pass);
                else if (remote)
                    p.open(serial, host, pass);
                else
                    p.open(serial);
                return; //success
            }
            catch { }
        usage:
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Invalid Command line arguments." + Environment.NewLine);
            sb.AppendLine("Usage: " + appName + " [Flags...]");
            sb.AppendLine("Flags:\t-n   serialNumber\tSerial Number, omit for any serial");
            sb.AppendLine("\t-r\t\tOpen remotely");
            sb.AppendLine("\t-s   serverID\tServer ID, omit for any server");
            sb.AppendLine("\t-i   ipAddress:port\tIp Address and Port. Port is optional, defaults to 5001");
            sb.AppendLine("\t-p   password\tPassword, omit for no password" + Environment.NewLine);
            sb.AppendLine("Examples: ");
            sb.AppendLine(appName + " -n 50098");
            sb.AppendLine(appName + " -r");
            sb.AppendLine(appName + " -s myphidgetserver");
            sb.AppendLine(appName + " -n 45670 -i 127.0.0.1:5001 -p paswrd");
            MessageBox.Show(sb.ToString(), "Argument Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Application.Exit();
        }
        #endregion*/

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            rfid.LED = false;
            rfid.outputs[0] = false;
            rfid.outputs[1] = false;

            //Clear array
            Array.Clear(fridgeDBArr, 0, fridgeDBArr.Length);
            //Clear textfield.
            tbxContents.Clear();
            MessageBox.Show("Fridge has been reset!");
            
        }

    }
}