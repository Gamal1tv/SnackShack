using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Linq.Expressions;

namespace SnackShack
{
    public partial class VendingMachine : Form
    {
        public VendingMachine()
        {
            InitializeComponent();

            pbMoneySlot.AllowDrop = true; //set allow drop property to true
            toolStripStatusLabel1.Text = ""; //set the text on status strip to empty

            //create pb list and add each pb
            List<PictureBox> p = new List<PictureBox>();
            p.Add(pbSnack1);
            p.Add(pbSnack2);
            p.Add(pbSnack3);
            p.Add(pbSnack4);
            p.Add(pbSnack5);
            p.Add(pbSnack6);
            p.Add(pbSnack7);
            p.Add(pbSnack8);
            p.Add(pbSnack9);
            p.Add(pbSnack10);
            p.Add(pbSnack11);
            p.Add(pbSnack12);

            //add pictures to corresponding pb
            foreach (Program.Snacks s in Program.snackList)
            {
                if (s.Slot > 0 && s.Slot < 13)
                {
                    p[s.Slot - 1].ImageLocation = s.ImagePath;
                }
            }
            //Focuse cancel button
            btnCancel.Focus();
        }

        //BUTTON CLICK EVENT
        int item = 0;
        bool outofOrder = false;
        private void btn1_Click(object sender, EventArgs e)
        {
            Button number = sender as Button; //creates variable for all number buttons

            //Fill in btnIn with the user input
            if (btnIn1.Text == "")
                btnIn1.Text = number.Text;
            else if (btnIn2.Text == "")
                btnIn2.Text = number.Text;
            else if (btnIn3.Text == "")
                btnIn3.Text = number.Text;
            //If last input
            else if (btnIn4.Text == "")
            {
                //fill in input button
                btnIn4.Text = number.Text;


                //Get sale price of the slot item user chose and fill in input buttons with price
                string inputStr = btnIn1.Text + btnIn2.Text + btnIn3.Text + btnIn4.Text;
                int inputNum = Convert.ToInt32(inputStr);
                item = inputNum;

                //If user choses a valid slot
                if (inputNum > 0 && inputNum <= 12)
                {

                    //get the same snack number in snackList that the user chose
                    for (int l = 0; l < Program.snackList.Count; l++)
                    {

                        if (item == Program.snackList[l].Slot)
                        {
                            //if snack is available
                            if (Program.snackList[l].QFS > 0)
                            {
                                outofOrder = false;

                                this.Refresh();
                                Thread.Sleep(1000);
                                float price = 0;
                                btnIn1.Text = "";
                                btnIn2.Text = "";
                                btnIn3.Text = "";
                                btnIn4.Text = "";
                                price = Program.snackList[l].SalePrice;
                                string priceStg = price.ToString("C2");
                                for (int j = 1; j < priceStg.Length + 1; j++)
                                {
                                    if (btnIn1.Text == "")
                                        btnIn1.Text = Convert.ToString(priceStg[j]);
                                    else if (btnIn2.Text == "")
                                        btnIn2.Text = Convert.ToString(priceStg[j]);
                                    else if (btnIn3.Text == "")
                                        btnIn3.Text = Convert.ToString(priceStg[j]);
                                    else if (btnIn4.Text == "")
                                        btnIn4.Text = Convert.ToString(priceStg[j]);
                                }
                                //set status strip text to blank
                                toolStripStatusLabel1.Text = "";
                                toolStripStatusLabel1.ForeColor = Color.Black;
                                break;
                            }
                            else //if product is out
                            {
                                toolStripStatusLabel1.Text = "Product Out Of Order";
                                outofOrder = true;
                                break;
                            }
                        }
                    }

                }
                //if user does not chose a valid slot
                else
                {
                    this.Refresh();
                    Thread.Sleep(100);
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text = "Please enter a valid item number (1 - 12)";
                    btnIn1.Text = "";
                    btnIn2.Text = "";
                    btnIn3.Text = "";
                    btnIn4.Text = "";
                }
            }
            //focus cancel button
            btnCancel.Focus();
        }


        //MONEY CLICK EVENT
        private void pbPenny_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pb = sender as PictureBox;

            //if picture box name does not contain "Snack"
            if (!pb.Name.Contains("Snack"))
            {
                pb.DoDragDrop(pb.Tag.ToString(), DragDropEffects.Copy); //allows drag drop and copies pb.Tag as the data
            }
            
        }


        //ALLOW DRAG-ENTER FOR MONEYSLOT
        private void pbMoneySlot_DragEnter(object sender, DragEventArgs e)
        {
            //if you enter pbMoneySlot while dragging and the dragged data is a string
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
                e.Effect = DragDropEffects.Copy; //drop effect is set to a copy of the of the data
            else
                e.Effect = DragDropEffects.None; //if not copy nothing
        }


        //MONEY DROP ENENT
        private void pbMoneySlot_DragDrop(object sender, DragEventArgs e)
        {
            //if product is available
            if (outofOrder == false)
            {
                //get snack amount
                string priceT = btnIn1.Text + btnIn2.Text + btnIn3.Text + btnIn4.Text;
                float price = float.Parse(priceT);

                //subtract money used from snack amount
                price -= float.Parse((string)e.Data.GetData(DataFormats.StringFormat));

                //if price is more than 0
                if (price < 0)
                {
                    btnIn1.Text = "0";
                    btnIn2.Text = ".";
                    btnIn3.Text = "0";
                    btnIn4.Text = "0";
                    toolStripStatusLabel1.Text = (price * -1).ToString("C2") + " is your change. Thank you for your purchase.";
                    this.Refresh();

                    Thread.Sleep(1000);
                    btnIn1.Text = "";
                    btnIn2.Text = "";
                    btnIn3.Text = "";
                    btnIn4.Text = "";

                    GetDataAndUpdate();
                }
                //if price is 0
                else if (price == 0)
                {
                    btnIn1.Text = "0";
                    btnIn2.Text = ".";
                    btnIn3.Text = "0";
                    btnIn4.Text = "0";
                    toolStripStatusLabel1.Text = "Thank you for your purchase.";
                    this.Refresh();

                    Thread.Sleep(1000);
                    btnIn1.Text = "";
                    btnIn2.Text = "";
                    btnIn3.Text = "";
                    btnIn4.Text = "";

                    GetDataAndUpdate();
                }
                else
                {
                    //put new total in boxes
                    string priceStg = price.ToString("C2");
                    btnIn1.Text = Convert.ToString(priceStg[1]);
                    btnIn2.Text = Convert.ToString(priceStg[2]);
                    btnIn3.Text = Convert.ToString(priceStg[3]);
                    btnIn4.Text = Convert.ToString(priceStg[4]);
                }
            }
        }


        //GET ALL CURRENT INFO FOR SNACK AND UPDATE TABLES AND DATA GRID VIEW 
        private void GetDataAndUpdate()
        {
            //If the item chosen equals the the slot number on snack in snacklist: run addSale() method
            for (int i = 0; i < Program.snackList.Count; i++)
            {
                if (item == Program.snackList[i].Slot)
                {
                    int machineid = 1;
                    int productid = Program.snackList[i].ProductID;
                    float salesprice = Program.snackList[i].SalePrice;
                    byte qoh = Program.snackList[i].QOH;
                    byte qfs = Convert.ToByte(Program.snackList[i].QFS - 1);
                    Program.snackList[i].QFS = qfs;
                    byte slot = Program.snackList[i].Slot;
                    Program.AddSale(machineid, productid, salesprice, qoh, slot, qfs);


                    string snackname = Program.snackList[i].SnackName;
                    float purchaseprice = Program.snackList[i].PurchasePrice;
                    string imagepath = Program.snackList[i].ImagePath;

                    //Edit snacks table to the new quantity for sale
                    Program.EditSnacks(productid, snackname, purchaseprice, salesprice, qoh, slot, qfs, imagepath);


                    Program.EditVending(productid, salesprice, qfs, machineid, slot, qoh);

                    btnIn1.Text = "";
                    btnIn2.Text = "";
                    btnIn3.Text = "";
                    btnIn4.Text = "";

                    //Update qfs in form1's Data Grid View
                    Form1 fm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                    foreach (DataGridViewRow r in fm.dgvSnacks.Rows)
                    {
                        if (r.Cells[1].Value.ToString() == snackname)
                        {
                            r.Cells[6].Value = qfs;
                            break;
                        }
                    }

                    btnCancel.Focus();
                    break;
                }
            }
        }
        

        //CANCEL BUTTON EVENT
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Make each text box and status strip blank
            btnIn1.Text = "";
            btnIn2.Text = "";
            btnIn3.Text = "";
            btnIn4.Text = "";
            toolStripStatusLabel1.Text = "";
        }

        
        //KEYBAORD INPUTS TO BUTTON CLICK
        private void VendingMachine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
            {
                btn1.PerformClick();
            }
            else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
            {
                btn2.PerformClick();
            }
            else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
            {
                btn3.PerformClick();
            }
            else if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
            {
                btn4.PerformClick();
            }
            else if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
            {
                btn5.PerformClick();
            }
            else if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
            {
                btn6.PerformClick();
            }
            else if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
            {
                btn7.PerformClick();
            }
            else if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
            {
                btn8.PerformClick();
            }
            else if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
            {
                btn9.PerformClick();
            }
            else if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
            {
                btn0.PerformClick();
            }
            else if (e.KeyCode == Keys.Back)
            {
                btnCancel.PerformClick();
            }
        }
    }
}
