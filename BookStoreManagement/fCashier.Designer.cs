namespace BookStoreManagement
{
    partial class fCashier
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbPrice = new System.Windows.Forms.TextBox();
            this.txbIdBook = new System.Windows.Forms.TextBox();
            this.txbTitle = new System.Windows.Forms.TextBox();
            this.nudNumber = new System.Windows.Forms.NumericUpDown();
            this.btnAddToInvoice = new System.Windows.Forms.Button();
            this.btnDeleteFromInvoice = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgvInvoiceDetail = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtgvBook = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txbSearchBook = new System.Windows.Forms.TextBox();
            this.btnSearchBook = new System.Windows.Forms.Button();
            this.btnPayCheck = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txbIdInvoice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbEmployeeName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpkInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txbTotalAmount = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvInvoiceDetail)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBook)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txbPrice);
            this.panel1.Controls.Add(this.txbIdBook);
            this.panel1.Controls.Add(this.txbTitle);
            this.panel1.Controls.Add(this.nudNumber);
            this.panel1.Controls.Add(this.btnAddToInvoice);
            this.panel1.Controls.Add(this.btnDeleteFromInvoice);
            this.panel1.Location = new System.Drawing.Point(396, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 120);
            this.panel1.TabIndex = 0;
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
            this.txbPrice.ReadOnly = true;
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
            // btnAddToInvoice
            // 
            this.btnAddToInvoice.Location = new System.Drawing.Point(241, 52);
            this.btnAddToInvoice.Name = "btnAddToInvoice";
            this.btnAddToInvoice.Size = new System.Drawing.Size(132, 65);
            this.btnAddToInvoice.TabIndex = 1;
            this.btnAddToInvoice.Text = "Thêm vào hóa đơn";
            this.btnAddToInvoice.UseVisualStyleBackColor = true;
            this.btnAddToInvoice.Click += new System.EventHandler(this.btnAddToInvoice_Click);
            // 
            // btnDeleteFromInvoice
            // 
            this.btnDeleteFromInvoice.Location = new System.Drawing.Point(399, 52);
            this.btnDeleteFromInvoice.Name = "btnDeleteFromInvoice";
            this.btnDeleteFromInvoice.Size = new System.Drawing.Size(123, 65);
            this.btnDeleteFromInvoice.TabIndex = 0;
            this.btnDeleteFromInvoice.Text = "Bỏ khỏi hóa đơn";
            this.btnDeleteFromInvoice.UseVisualStyleBackColor = true;
            this.btnDeleteFromInvoice.Click += new System.EventHandler(this.btnDeleteFromInvoice_Click);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(396, 138);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(540, 384);
            this.panel2.TabIndex = 1;
            // 
            // dtgvInvoiceDetail
            // 
            this.dtgvInvoiceDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvInvoiceDetail.Location = new System.Drawing.Point(396, 138);
            this.dtgvInvoiceDetail.Name = "dtgvInvoiceDetail";
            this.dtgvInvoiceDetail.RowHeadersWidth = 51;
            this.dtgvInvoiceDetail.RowTemplate.Height = 24;
            this.dtgvInvoiceDetail.Size = new System.Drawing.Size(540, 384);
            this.dtgvInvoiceDetail.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dtgvBook);
            this.panel4.Location = new System.Drawing.Point(12, 67);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(378, 455);
            this.panel4.TabIndex = 2;
            // 
            // dtgvBook
            // 
            this.dtgvBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvBook.Location = new System.Drawing.Point(0, 3);
            this.dtgvBook.Name = "dtgvBook";
            this.dtgvBook.RowHeadersWidth = 51;
            this.dtgvBook.RowTemplate.Height = 24;
            this.dtgvBook.Size = new System.Drawing.Size(378, 452);
            this.dtgvBook.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txbSearchBook);
            this.panel6.Controls.Add(this.btnSearchBook);
            this.panel6.Location = new System.Drawing.Point(12, 12);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(378, 44);
            this.panel6.TabIndex = 4;
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
            // btnPayCheck
            // 
            this.btnPayCheck.Location = new System.Drawing.Point(795, 528);
            this.btnPayCheck.Name = "btnPayCheck";
            this.btnPayCheck.Size = new System.Drawing.Size(123, 65);
            this.btnPayCheck.TabIndex = 9;
            this.btnPayCheck.Text = "Thanh toán";
            this.btnPayCheck.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 537);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "ID hóa đơn:";
            // 
            // txbIdInvoice
            // 
            this.txbIdInvoice.Enabled = false;
            this.txbIdInvoice.Location = new System.Drawing.Point(93, 534);
            this.txbIdInvoice.Name = "txbIdInvoice";
            this.txbIdInvoice.ReadOnly = true;
            this.txbIdInvoice.Size = new System.Drawing.Size(57, 22);
            this.txbIdInvoice.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 568);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nhân viên tạo:";
            // 
            // txbEmployeeName
            // 
            this.txbEmployeeName.Enabled = false;
            this.txbEmployeeName.Location = new System.Drawing.Point(110, 565);
            this.txbEmployeeName.Name = "txbEmployeeName";
            this.txbEmployeeName.ReadOnly = true;
            this.txbEmployeeName.Size = new System.Drawing.Size(120, 22);
            this.txbEmployeeName.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(248, 537);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Ngày tạo:";
            // 
            // dtpkInvoiceDate
            // 
            this.dtpkInvoiceDate.Enabled = false;
            this.dtpkInvoiceDate.Location = new System.Drawing.Point(329, 534);
            this.dtpkInvoiceDate.Name = "dtpkInvoiceDate";
            this.dtpkInvoiceDate.Size = new System.Drawing.Size(200, 22);
            this.dtpkInvoiceDate.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(585, 555);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Tổng hóa đơn:";
            // 
            // txbTotalAmount
            // 
            this.txbTotalAmount.Enabled = false;
            this.txbTotalAmount.Location = new System.Drawing.Point(698, 552);
            this.txbTotalAmount.Name = "txbTotalAmount";
            this.txbTotalAmount.ReadOnly = true;
            this.txbTotalAmount.Size = new System.Drawing.Size(71, 22);
            this.txbTotalAmount.TabIndex = 15;
            // 
            // fCashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 602);
            this.Controls.Add(this.txbTotalAmount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpkInvoiceDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txbEmployeeName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txbIdInvoice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPayCheck);
            this.Controls.Add(this.dtgvInvoiceDetail);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "fCashier";
            this.Text = "fCashier";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvInvoiceDetail)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBook)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDeleteFromInvoice;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnAddToInvoice;
        private System.Windows.Forms.DataGridView dtgvBook;
        private System.Windows.Forms.DataGridView dtgvInvoiceDetail;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txbSearchBook;
        private System.Windows.Forms.Button btnSearchBook;
        private System.Windows.Forms.NumericUpDown nudNumber;
        private System.Windows.Forms.TextBox txbPrice;
        private System.Windows.Forms.TextBox txbIdBook;
        private System.Windows.Forms.TextBox txbTitle;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPayCheck;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbIdInvoice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbEmployeeName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpkInvoiceDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbTotalAmount;
    }
}