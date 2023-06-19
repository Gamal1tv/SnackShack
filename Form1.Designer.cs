namespace SnackShack
{
    partial class Form1
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
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.dgvSnacks = new System.Windows.Forms.DataGridView();
            this.productId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qoh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qfs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ssStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.lblPurchase = new System.Windows.Forms.Label();
            this.txtSnack = new System.Windows.Forms.TextBox();
            this.txtPurchase = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblImageText = new System.Windows.Forms.Label();
            this.txtSale = new System.Windows.Forms.TextBox();
            this.lblSale = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQoh = new System.Windows.Forms.TextBox();
            this.lblQoh = new System.Windows.Forms.Label();
            this.txtSlot = new System.Windows.Forms.TextBox();
            this.lblSlot = new System.Windows.Forms.Label();
            this.txtQfs = new System.Windows.Forms.TextBox();
            this.lblQfs = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnVending = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSnacks)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.Color.White;
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Location = new System.Drawing.Point(809, 24);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(225, 201);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // txtPath
            // 
            this.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath.Enabled = false;
            this.txtPath.Location = new System.Drawing.Point(115, 25);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(597, 20);
            this.txtPath.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(20, 25);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(84, 22);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "Select Image";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dgvSnacks
            // 
            this.dgvSnacks.AllowUserToAddRows = false;
            this.dgvSnacks.AllowUserToDeleteRows = false;
            this.dgvSnacks.AllowUserToResizeColumns = false;
            this.dgvSnacks.AllowUserToResizeRows = false;
            this.dgvSnacks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productId,
            this.nameColumn,
            this.purchasePrice,
            this.salePrice,
            this.qoh,
            this.slot,
            this.qfs,
            this.pathColumn,
            this.imageColumn});
            this.dgvSnacks.Location = new System.Drawing.Point(31, 234);
            this.dgvSnacks.Name = "dgvSnacks";
            this.dgvSnacks.RowHeadersVisible = false;
            this.dgvSnacks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSnacks.Size = new System.Drawing.Size(1003, 334);
            this.dgvSnacks.TabIndex = 4;
            this.dgvSnacks.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSnacks_CellMouseDoubleClick);
            // 
            // productId
            // 
            this.productId.HeaderText = "Product ID";
            this.productId.Name = "productId";
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            // 
            // purchasePrice
            // 
            this.purchasePrice.HeaderText = "Purchase Price";
            this.purchasePrice.Name = "purchasePrice";
            // 
            // salePrice
            // 
            this.salePrice.HeaderText = "Sale Price";
            this.salePrice.Name = "salePrice";
            // 
            // qoh
            // 
            this.qoh.HeaderText = "QOH";
            this.qoh.Name = "qoh";
            // 
            // slot
            // 
            this.slot.HeaderText = "Slot";
            this.slot.Name = "slot";
            // 
            // qfs
            // 
            this.qfs.HeaderText = "QFS";
            this.qfs.Name = "qfs";
            // 
            // pathColumn
            // 
            this.pathColumn.HeaderText = "Path";
            this.pathColumn.Name = "pathColumn";
            this.pathColumn.Width = 200;
            // 
            // imageColumn
            // 
            this.imageColumn.HeaderText = "Image";
            this.imageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.imageColumn.Name = "imageColumn";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 581);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1056, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ssStatus
            // 
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(728, 24);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbl
            // 
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(20, 60);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(79, 13);
            this.lbl.TabIndex = 7;
            this.lbl.Text = "Snack";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPurchase
            // 
            this.lblPurchase.AutoSize = true;
            this.lblPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchase.Location = new System.Drawing.Point(20, 90);
            this.lblPurchase.Name = "lblPurchase";
            this.lblPurchase.Size = new System.Drawing.Size(79, 13);
            this.lblPurchase.TabIndex = 8;
            this.lblPurchase.Text = "Purchase Price";
            this.lblPurchase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSnack
            // 
            this.txtSnack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSnack.Location = new System.Drawing.Point(115, 55);
            this.txtSnack.Name = "txtSnack";
            this.txtSnack.Size = new System.Drawing.Size(597, 20);
            this.txtSnack.TabIndex = 9;
            // 
            // txtPurchase
            // 
            this.txtPurchase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPurchase.Location = new System.Drawing.Point(115, 85);
            this.txtPurchase.Name = "txtPurchase";
            this.txtPurchase.Size = new System.Drawing.Size(597, 20);
            this.txtPurchase.TabIndex = 10;
            this.txtPurchase.TextChanged += new System.EventHandler(this.txtCost_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "$";
            // 
            // lblImageText
            // 
            this.lblImageText.AutoSize = true;
            this.lblImageText.Location = new System.Drawing.Point(814, 8);
            this.lblImageText.Name = "lblImageText";
            this.lblImageText.Size = new System.Drawing.Size(36, 13);
            this.lblImageText.TabIndex = 12;
            this.lblImageText.Text = "Image";
            // 
            // txtSale
            // 
            this.txtSale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSale.Location = new System.Drawing.Point(115, 115);
            this.txtSale.Name = "txtSale";
            this.txtSale.Size = new System.Drawing.Size(597, 20);
            this.txtSale.TabIndex = 14;
            // 
            // lblSale
            // 
            this.lblSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSale.Location = new System.Drawing.Point(20, 120);
            this.lblSale.Name = "lblSale";
            this.lblSale.Size = new System.Drawing.Size(79, 13);
            this.lblSale.TabIndex = 13;
            this.lblSale.Text = "Sale Price";
            this.lblSale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "$";
            // 
            // txtQoh
            // 
            this.txtQoh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQoh.Location = new System.Drawing.Point(115, 145);
            this.txtQoh.Name = "txtQoh";
            this.txtQoh.Size = new System.Drawing.Size(597, 20);
            this.txtQoh.TabIndex = 17;
            // 
            // lblQoh
            // 
            this.lblQoh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQoh.Location = new System.Drawing.Point(20, 150);
            this.lblQoh.Name = "lblQoh";
            this.lblQoh.Size = new System.Drawing.Size(79, 13);
            this.lblQoh.TabIndex = 16;
            this.lblQoh.Text = "QOH";
            this.lblQoh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSlot
            // 
            this.txtSlot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSlot.Location = new System.Drawing.Point(115, 175);
            this.txtSlot.Name = "txtSlot";
            this.txtSlot.Size = new System.Drawing.Size(597, 20);
            this.txtSlot.TabIndex = 19;
            // 
            // lblSlot
            // 
            this.lblSlot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlot.Location = new System.Drawing.Point(20, 180);
            this.lblSlot.Name = "lblSlot";
            this.lblSlot.Size = new System.Drawing.Size(79, 13);
            this.lblSlot.TabIndex = 18;
            this.lblSlot.Text = "Slot";
            this.lblSlot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtQfs
            // 
            this.txtQfs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQfs.Location = new System.Drawing.Point(115, 205);
            this.txtQfs.Name = "txtQfs";
            this.txtQfs.Size = new System.Drawing.Size(597, 20);
            this.txtQfs.TabIndex = 21;
            // 
            // lblQfs
            // 
            this.lblQfs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQfs.Location = new System.Drawing.Point(20, 210);
            this.lblQfs.Name = "lblQfs";
            this.lblQfs.Size = new System.Drawing.Size(79, 13);
            this.lblQfs.TabIndex = 20;
            this.lblQfs.Text = "QFS";
            this.lblQfs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(728, 60);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnVending
            // 
            this.btnVending.Location = new System.Drawing.Point(728, 205);
            this.btnVending.Name = "btnVending";
            this.btnVending.Size = new System.Drawing.Size(75, 23);
            this.btnVending.TabIndex = 23;
            this.btnVending.Text = "Vending";
            this.btnVending.UseVisualStyleBackColor = true;
            this.btnVending.Click += new System.EventHandler(this.btnVending_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 603);
            this.Controls.Add(this.btnVending);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtQfs);
            this.Controls.Add(this.lblQfs);
            this.Controls.Add(this.txtSlot);
            this.Controls.Add(this.lblSlot);
            this.Controls.Add(this.txtQoh);
            this.Controls.Add(this.lblQoh);
            this.Controls.Add(this.txtSale);
            this.Controls.Add(this.lblSale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblImageText);
            this.Controls.Add(this.txtPurchase);
            this.Controls.Add(this.txtSnack);
            this.Controls.Add(this.lblPurchase);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvSnacks);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snack Shack";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSnacks)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ssStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lblPurchase;
        private System.Windows.Forms.TextBox txtSnack;
        private System.Windows.Forms.TextBox txtPurchase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblImageText;
        private System.Windows.Forms.DataGridViewTextBoxColumn productId;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn salePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn qoh;
        private System.Windows.Forms.DataGridViewTextBoxColumn slot;
        private System.Windows.Forms.DataGridViewTextBoxColumn qfs;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathColumn;
        private System.Windows.Forms.DataGridViewImageColumn imageColumn;
        private System.Windows.Forms.TextBox txtSale;
        private System.Windows.Forms.Label lblSale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQoh;
        private System.Windows.Forms.Label lblQoh;
        private System.Windows.Forms.TextBox txtSlot;
        private System.Windows.Forms.Label lblSlot;
        private System.Windows.Forms.TextBox txtQfs;
        private System.Windows.Forms.Label lblQfs;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnVending;
        internal System.Windows.Forms.DataGridView dgvSnacks;
    }
}

