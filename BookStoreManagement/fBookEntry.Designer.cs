namespace BookStoreManagement
{
    partial class fBookEntry
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.txbSearchBook = new System.Windows.Forms.TextBox();
            this.btnSearchBook = new System.Windows.Forms.Button();
            this.dtgvBook = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txbQuantity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txbBookIdDelete = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbPrice = new System.Windows.Forms.TextBox();
            this.txbIdBook = new System.Windows.Forms.TextBox();
            this.txbTitle = new System.Windows.Forms.TextBox();
            this.nudNumber = new System.Windows.Forms.NumericUpDown();
            this.btnAddToBookEntry = new System.Windows.Forms.Button();
            this.btnDeleteFromBookEntry = new System.Windows.Forms.Button();
            this.dtgvBookEntryDetail = new System.Windows.Forms.DataGridView();
            this.btnPayCheck = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbIdBookEntry = new System.Windows.Forms.TextBox();
            this.txbEmployeeName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpkInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txbTotalAmount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txbSupplier = new System.Windows.Forms.TextBox();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBook)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBookEntryDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txbSearchBook);
            this.panel6.Controls.Add(this.btnSearchBook);
            this.panel6.Location = new System.Drawing.Point(12, 12);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(378, 44);
            this.panel6.TabIndex = 5;
            // 
            // txbSearchBook
            // 
            this.txbSearchBook.Location = new System.Drawing.Point(16, 9);
            this.txbSearchBook.Name = "txbSearchBook";
            this.txbSearchBook.Size = new System.Drawing.Size(264, 22);
            this.txbSearchBook.TabIndex = 4;
            // 
            // btnSearchBook
            // 
            this.btnSearchBook.Location = new System.Drawing.Point(286, 3);
            this.btnSearchBook.Name = "btnSearchBook";
            this.btnSearchBook.Size = new System.Drawing.Size(89, 41);
            this.btnSearchBook.TabIndex = 3;
            this.btnSearchBook.Text = "Tìm sách";
            this.btnSearchBook.UseVisualStyleBackColor = true;
            this.btnSearchBook.Click += new System.EventHandler(this.btnSearchBook_Click);
            // 
            // dtgvBook
            // 
            this.dtgvBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvBook.Location = new System.Drawing.Point(12, 62);
            this.dtgvBook.Name = "dtgvBook";
            this.dtgvBook.RowHeadersWidth = 51;
            this.dtgvBook.RowTemplate.Height = 24;
            this.dtgvBook.Size = new System.Drawing.Size(378, 452);
            this.dtgvBook.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txbQuantity);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txbBookIdDelete);
            this.panel1.Controls.Add(this.label);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txbPrice);
            this.panel1.Controls.Add(this.txbIdBook);
            this.panel1.Controls.Add(this.txbTitle);
            this.panel1.Controls.Add(this.nudNumber);
            this.panel1.Controls.Add(this.btnAddToBookEntry);
            this.panel1.Controls.Add(this.btnDeleteFromBookEntry);
            this.panel1.Location = new System.Drawing.Point(396, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 120);
            this.panel1.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(198, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "SL";
            // 
            // txbQuantity
            // 
            this.txbQuantity.Location = new System.Drawing.Point(236, 95);
            this.txbQuantity.Name = "txbQuantity";
            this.txbQuantity.ReadOnly = true;
            this.txbQuantity.Size = new System.Drawing.Size(60, 22);
            this.txbQuantity.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Bỏ khỏi hóa đơn";
            // 
            // txbBookIdDelete
            // 
            this.txbBookIdDelete.Location = new System.Drawing.Point(128, 95);
            this.txbBookIdDelete.Name = "txbBookIdDelete";
            this.txbBookIdDelete.ReadOnly = true;
            this.txbBookIdDelete.Size = new System.Drawing.Size(45, 22);
            this.txbBookIdDelete.TabIndex = 9;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(352, 15);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(60, 16);
            this.label.TabIndex = 8;
            this.label.Text = "Số lượng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(207, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Giá";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tên";
            // 
            // txbPrice
            // 
            this.txbPrice.Location = new System.Drawing.Point(241, 12);
            this.txbPrice.Name = "txbPrice";
            this.txbPrice.Size = new System.Drawing.Size(105, 22);
            this.txbPrice.TabIndex = 5;
            // 
            // txbIdBook
            // 
            this.txbIdBook.Location = new System.Drawing.Point(70, 52);
            this.txbIdBook.Name = "txbIdBook";
            this.txbIdBook.ReadOnly = true;
            this.txbIdBook.Size = new System.Drawing.Size(131, 22);
            this.txbIdBook.TabIndex = 4;
            // 
            // txbTitle
            // 
            this.txbTitle.Location = new System.Drawing.Point(70, 9);
            this.txbTitle.Name = "txbTitle";
            this.txbTitle.ReadOnly = true;
            this.txbTitle.Size = new System.Drawing.Size(131, 22);
            this.txbTitle.TabIndex = 3;
            // 
            // nudNumber
            // 
            this.nudNumber.Location = new System.Drawing.Point(418, 13);
            this.nudNumber.Name = "nudNumber";
            this.nudNumber.Size = new System.Drawing.Size(104, 22);
            this.nudNumber.TabIndex = 2;
            this.nudNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddToBookEntry
            // 
            this.btnAddToBookEntry.Location = new System.Drawing.Point(302, 52);
            this.btnAddToBookEntry.Name = "btnAddToBookEntry";
            this.btnAddToBookEntry.Size = new System.Drawing.Size(103, 65);
            this.btnAddToBookEntry.TabIndex = 1;
            this.btnAddToBookEntry.Text = "Thêm vào đơn nhập";
            this.btnAddToBookEntry.UseVisualStyleBackColor = true;
            this.btnAddToBookEntry.Click += new System.EventHandler(this.btnAddToBookEntry_Click);
            // 
            // btnDeleteFromBookEntry
            // 
            this.btnDeleteFromBookEntry.Location = new System.Drawing.Point(418, 52);
            this.btnDeleteFromBookEntry.Name = "btnDeleteFromBookEntry";
            this.btnDeleteFromBookEntry.Size = new System.Drawing.Size(104, 65);
            this.btnDeleteFromBookEntry.TabIndex = 0;
            this.btnDeleteFromBookEntry.Text = "Bỏ khỏi đơn nhập";
            this.btnDeleteFromBookEntry.UseVisualStyleBackColor = true;
            this.btnDeleteFromBookEntry.Click += new System.EventHandler(this.btnDeleteFromBookEntry_Click);
            // 
            // dtgvBookEntryDetail
            // 
            this.dtgvBookEntryDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvBookEntryDetail.Location = new System.Drawing.Point(396, 138);
            this.dtgvBookEntryDetail.Name = "dtgvBookEntryDetail";
            this.dtgvBookEntryDetail.RowHeadersWidth = 51;
            this.dtgvBookEntryDetail.RowTemplate.Height = 24;
            this.dtgvBookEntryDetail.Size = new System.Drawing.Size(540, 376);
            this.dtgvBookEntryDetail.TabIndex = 8;
            // 
            // btnPayCheck
            // 
            this.btnPayCheck.Location = new System.Drawing.Point(814, 527);
            this.btnPayCheck.Name = "btnPayCheck";
            this.btnPayCheck.Size = new System.Drawing.Size(123, 65);
            this.btnPayCheck.TabIndex = 10;
            this.btnPayCheck.Text = "Xác nhận nhập";
            this.btnPayCheck.UseVisualStyleBackColor = true;
            this.btnPayCheck.Click += new System.EventHandler(this.btnPayCheck_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 538);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "ID đơn nhập:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 570);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Nhân viên nhập:";
            // 
            // txbIdBookEntry
            // 
            this.txbIdBookEntry.Enabled = false;
            this.txbIdBookEntry.Location = new System.Drawing.Point(125, 535);
            this.txbIdBookEntry.Name = "txbIdBookEntry";
            this.txbIdBookEntry.ReadOnly = true;
            this.txbIdBookEntry.Size = new System.Drawing.Size(57, 22);
            this.txbIdBookEntry.TabIndex = 13;
            // 
            // txbEmployeeName
            // 
            this.txbEmployeeName.Enabled = false;
            this.txbEmployeeName.Location = new System.Drawing.Point(125, 567);
            this.txbEmployeeName.Name = "txbEmployeeName";
            this.txbEmployeeName.ReadOnly = true;
            this.txbEmployeeName.Size = new System.Drawing.Size(120, 22);
            this.txbEmployeeName.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(263, 541);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Ngày tạo:";
            // 
            // dtpkInvoiceDate
            // 
            this.dtpkInvoiceDate.Enabled = false;
            this.dtpkInvoiceDate.Location = new System.Drawing.Point(359, 538);
            this.dtpkInvoiceDate.Name = "dtpkInvoiceDate";
            this.dtpkInvoiceDate.Size = new System.Drawing.Size(200, 22);
            this.dtpkInvoiceDate.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(586, 557);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Tổng đơn nhập:";
            // 
            // txbTotalAmount
            // 
            this.txbTotalAmount.Enabled = false;
            this.txbTotalAmount.Location = new System.Drawing.Point(707, 551);
            this.txbTotalAmount.Name = "txbTotalAmount";
            this.txbTotalAmount.ReadOnly = true;
            this.txbTotalAmount.Size = new System.Drawing.Size(71, 22);
            this.txbTotalAmount.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(263, 576);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "Nhà cung cấp:";
            // 
            // txbSupplier
            // 
            this.txbSupplier.Enabled = false;
            this.txbSupplier.Location = new System.Drawing.Point(377, 570);
            this.txbSupplier.Name = "txbSupplier";
            this.txbSupplier.ReadOnly = true;
            this.txbSupplier.Size = new System.Drawing.Size(120, 22);
            this.txbSupplier.TabIndex = 20;
            // 
            // fBookEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 604);
            this.Controls.Add(this.txbSupplier);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txbTotalAmount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpkInvoiceDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txbEmployeeName);
            this.Controls.Add(this.txbIdBookEntry);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPayCheck);
            this.Controls.Add(this.dtgvBookEntryDetail);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtgvBook);
            this.Controls.Add(this.panel6);
            this.Name = "fBookEntry";
            this.Text = "fBookEntry";
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBook)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBookEntryDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txbSearchBook;
        private System.Windows.Forms.Button btnSearchBook;
        private System.Windows.Forms.DataGridView dtgvBook;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txbQuantity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbBookIdDelete;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbPrice;
        private System.Windows.Forms.TextBox txbIdBook;
        private System.Windows.Forms.TextBox txbTitle;
        private System.Windows.Forms.NumericUpDown nudNumber;
        private System.Windows.Forms.Button btnAddToBookEntry;
        private System.Windows.Forms.Button btnDeleteFromBookEntry;
        private System.Windows.Forms.DataGridView dtgvBookEntryDetail;
        private System.Windows.Forms.Button btnPayCheck;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbIdBookEntry;
        private System.Windows.Forms.TextBox txbEmployeeName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpkInvoiceDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbTotalAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbSupplier;
    }
}