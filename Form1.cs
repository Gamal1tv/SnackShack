using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SnackShack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //using (StreamReader sr = new StreamReader("H:\\Students_Folder\\Grant Malone\\Coding Assets\\Visual Studio Assets\\SnackShack\\SaveFile.txt")) //read from path
            //{
            //    while(!sr.EndOfStream) //while StreamReader is not at end of Document
            //    {
            //        string line = sr.ReadLine(); //whole line is stored in "line"
            //        string[] lineS = line.Split(','); //split line by commas
            //        dgvSnacks.Rows.Add(); //add empty row

            //        for (int i = 0; i < dgvSnacks.Columns.Count; i++) //execute code for how many columns there are
            //        {
            //            if (i == lineS.Length) //if loop instance is last loop execute:
            //            {
            //                string path = lineS[2]; //grab file path
            //                Image image = Image.FromFile(path); //save image at at path
            //                dgvSnacks.Rows[dgvSnacks.Rows.Count - 1].Cells[i].Value = image; //add to datagrid view
            //            }
            //            else //if not execute:
            //            {
            //                dgvSnacks.Rows[dgvSnacks.Rows.Count - 1].Cells[i].Value = lineS[i]; //add text to cell
            //            }
            //        }
            //    }
            //}

            Program.GetSnacks();

            //loop through snack list
            for (int i = 0; i < Program.snackList.Count; i++)
            {
                Program.Snacks s = Program.snackList[i];
                if (File.Exists(s.ImagePath))
                    dgvSnacks.Rows.Add(s.ProductID, s.SnackName, s.PurchasePrice, s.SalePrice, s.QOH, s.Slot, s.QFS, s.ImagePath, Image.FromFile(s.ImagePath));
                else
                    dgvSnacks.Rows.Add(s.ProductID, s.SnackName, s.PurchasePrice, s.SalePrice, s.QOH, s.Slot, s.QFS, s.ImagePath);
            }
        }


        //IMAGE SELECT EVENT
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) //if user clicks ok on open file dialog 
            {
                string path = openFileDialog1.FileName; //path equals selected file path
                txtPath.Text = path; //path text box equals path
                pbImage.Image = Image.FromFile(path); //picture both image is set to image at path
            }
        }
        

        //DATA SAVE EVENT
        public int itemCount = 0; //public int variable
        private void btnSave_Click(object sender, EventArgs e)
        {
            //check to see if snack is already in dgv
            for (int i = 0; i < dgvSnacks.Rows.Count; i++)
            {
                //if it is execute:
                if (dgvSnacks.Rows[i].Cells[1].Value.ToString() == txtSnack.Text) //edit data if snack name is already in database
                {
                    //Save image
                    MemoryStream mst = new MemoryStream(); //create new memory stream instance
                    pbImage.Image.Save(mst, pbImage.Image.RawFormat); //saves image
                    byte[] img = mst.ToArray(); //convert pic to array for individual pixel

                    //Get each item from selected row
                    int id = Convert.ToInt32(dgvSnacks.Rows[i].Cells[0].Value);
                    string snackName = txtSnack.Text;
                    float purchasePrice = float.Parse(txtPurchase.Text);
                    float salePrice = float.Parse(txtSale.Text);
                    byte qoh = Convert.ToByte(txtQoh.Text);
                    byte slot = Convert.ToByte(txtSlot.Text);
                    byte qfs = Convert.ToByte(txtQfs.Text);
                    string imagePath = txtPath.Text;

                    //Run EditSnacks Method
                    Program.EditSnacks(id, snackName, purchasePrice, salePrice, qoh, slot, qfs, imagePath);

                    //Update Cells with new values
                    dgvSnacks.Rows[i].Cells[1].Value = snackName;
                    dgvSnacks.Rows[i].Cells[2].Value = purchasePrice;
                    dgvSnacks.Rows[i].Cells[3].Value = salePrice;
                    dgvSnacks.Rows[i].Cells[4].Value = qoh;
                    dgvSnacks.Rows[i].Cells[5].Value = slot;
                    dgvSnacks.Rows[i].Cells[6].Value = qfs;
                    dgvSnacks.Rows[i].Cells[7].Value = imagePath;
                    dgvSnacks.Rows[i].Cells[8].Value = img;
                    break;
                }
                //if not exeucte:
                else
                {
                    if (txtSnack.Text.Length > 0 && txtPurchase.Text.Length > 0 && txtPath.Text.Length > 0)
                    {
                        //Save image
                        MemoryStream mst = new MemoryStream(); //create new memory stream instance
                        pbImage.Image.Save(mst, pbImage.Image.RawFormat); //saves image
                        byte[] img = mst.ToArray(); //convert pic to array for individual pixel

                        itemCount++; //increment itemCount 
                        if (itemCount == 1) //if itemCount is 1 execute:
                        {
                            ssStatus.Text = itemCount.ToString() + " total item added";
                        }
                        else //if not execute:
                        {
                            ssStatus.Text = itemCount.ToString() + " total items added";
                        }

                        //make field null if text box is empty
                        if (txtSnack.Text.Length == 0)
                            txtSnack.Text = null;
                        if (txtPurchase.Text.Length == 0)
                            txtSnack.Text = null;
                        if (txtSale.Text.Length == 0)
                            txtSnack.Text = null;
                        if (txtQoh.Text.Length == 0)
                            txtSnack.Text = null;
                        if (txtSlot.Text.Length == 0)
                            txtSnack.Text = null;
                        if (txtQfs.Text.Length == 0)
                            txtSnack.Text = null;
                        if (txtPath.Text.Length == 0)
                            txtSnack.Text = null;

                        //Create new instance of snack class
                        Program.Snacks snack = new Program.Snacks();

                        //Add each item to class
                        //AddSnacks function is used to get product id because it returns an int
                        snack.ProductID = Program.AddSnacks(txtSnack.Text, float.Parse(txtPurchase.Text), float.Parse(txtSale.Text), Convert.ToByte(txtQoh.Text), Convert.ToByte(txtSlot.Text), Convert.ToByte(txtQfs.Text), txtPath.Text);
                        snack.SnackName = txtSnack.Text;
                        snack.PurchasePrice = float.Parse(txtPurchase.Text);
                        snack.SalePrice = float.Parse(txtSale.Text);
                        snack.QOH = Convert.ToByte(txtQoh.Text);
                        snack.Slot = Convert.ToByte(txtSlot.Text);
                        snack.QFS = Convert.ToByte(txtQfs.Text);
                        snack.ImagePath = txtPath.Text;

                        //Add snack to list
                        Program.snackList.Add(snack);

                        //add snack name, purchase price, sale price, qoh, slots, qfs, file path, and image
                        dgvSnacks.Rows.Add(snack.ProductID, txtSnack.Text, float.Parse(txtPurchase.Text), float.Parse(txtSale.Text), Convert.ToByte(txtQoh.Text), Convert.ToByte(txtSlot.Text), Convert.ToByte(txtQfs.Text), txtPath.Text, img);
                        break;
                    }
                }
            }
        }


        //SAVE DATA ON CLOSING
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("H:\\Students_Folder\\Grant Malone\\Coding Assets\\Visual Studio Assets\\SnackShack\\SaveFile.txt")) //write data to file path provided
            {
                foreach(DataGridViewRow row in dgvSnacks.Rows) //for each row in data grid 
                {
                    sw.WriteLine(row.Cells[0].Value.ToString() + "," + row.Cells[1].Value.ToString() + "," + row.Cells[2].Value.ToString()); //write each cell to file
                }
            }
        }


        //VALID COST EVENT
        string costText = "";
        private void txtCost_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(txtPurchase.Text, out _) || txtPurchase.Text == "") //if text in cost text box is a number or is blank execute:
            {
                costText = txtPurchase.Text; //costText equals what is in the text box
            }
            else //if not execute:
            {
                ssStatus.Text = "Enter a valid number."; //update status lable
                ssStatus.ForeColor = Color.Red; //update text color to red
                txtPurchase.Text = costText; //update textbox to last valid number
                txtPurchase.SelectAll(); //select all in text box for easier editing
            }
        }


        //SNACK SELECT
        private void dgvSnacks_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if cells aren't null fill the corresponding text box
            if (dgvSnacks.CurrentRow.Cells[1].Value != null)
            {
                txtSnack.Text = dgvSnacks.CurrentRow.Cells[1].Value.ToString();
            }
            if (dgvSnacks.CurrentRow.Cells[2].Value != null)
            {
                txtPurchase.Text = dgvSnacks.CurrentRow.Cells[2].Value.ToString();
            }
            if (dgvSnacks.CurrentRow.Cells[3].Value != null)
            {
                txtSale.Text = dgvSnacks.CurrentRow.Cells[3].Value.ToString();
            }
            if (dgvSnacks.CurrentRow.Cells[4].Value != null)
            {
                txtQoh.Text = dgvSnacks.CurrentRow.Cells[4].Value.ToString();
            }
            if (dgvSnacks.CurrentRow.Cells[5].Value != null)
            {
                txtSlot.Text = dgvSnacks.CurrentRow.Cells[5].Value.ToString();
            }
            if (dgvSnacks.CurrentRow.Cells[6].Value != null)
            {
                txtQfs.Text = dgvSnacks.CurrentRow.Cells[6].Value.ToString();
            }
            if (dgvSnacks.CurrentRow.Cells[7].Value != null)
            {
                txtPath.Text = dgvSnacks.CurrentRow.Cells[7].Value.ToString();
            }
            pbImage.Image = Image.FromFile(txtPath.Text); //fill picture box with the image from file path
        }


        //DELETE EVENT
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Remove selected row in database, datagridview, and list
            ssStatus.Text = "Deleted " + dgvSnacks.CurrentRow.Cells[1].Value.ToString();
            Program.DeleteSnacks(Convert.ToInt32(dgvSnacks.CurrentRow.Cells[0].Value));
            int x = Convert.ToInt32(dgvSnacks.CurrentRow.Index);
            dgvSnacks.Rows.Remove(dgvSnacks.CurrentRow);
            Program.snackList.RemoveAt(x);

            //make each text box blank
            foreach (var textBox in Controls.OfType<TextBox>())
            {
                textBox.Text = "";
            }
        }

        //VENDING BUTTON CLICK EVENT
        private void btnVending_Click(object sender, EventArgs e)
        {
            //Make new instance of Vending Form and open it
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Show();
        }
    }
}
