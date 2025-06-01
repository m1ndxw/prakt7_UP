namespace prakt7_UP
{
    partial class CustomerDeliveryForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerDeliveryForm));
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.mtbPhone = new System.Windows.Forms.MaskedTextBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblCustomer.Location = new System.Drawing.Point(16, 15);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(79, 22);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Клиент:";
            // 
            // cbCustomer
            // 
            this.cbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomer.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cbCustomer.Location = new System.Drawing.Point(160, 15);
            this.cbCustomer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(399, 30);
            this.cbCustomer.TabIndex = 1;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblAddress.Location = new System.Drawing.Point(16, 62);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(68, 22);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "Адрес:";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtAddress.Location = new System.Drawing.Point(160, 62);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(399, 30);
            this.txtAddress.TabIndex = 3;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblPhone.Location = new System.Drawing.Point(16, 108);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(89, 22);
            this.lblPhone.TabIndex = 4;
            this.lblPhone.Text = "Телефон:";
            // 
            // mtbPhone
            // 
            this.mtbPhone.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.mtbPhone.Location = new System.Drawing.Point(160, 108);
            this.mtbPhone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mtbPhone.Mask = "+7(000)-000-00-00";
            this.mtbPhone.Name = "mtbPhone";
            this.mtbPhone.Size = new System.Drawing.Size(199, 30);
            this.mtbPhone.TabIndex = 5;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblProduct.Location = new System.Drawing.Point(16, 155);
            this.lblProduct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(64, 22);
            this.lblProduct.TabIndex = 6;
            this.lblProduct.Text = "Товар:";
            // 
            // cbProduct
            // 
            this.cbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProduct.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cbProduct.Location = new System.Drawing.Point(160, 155);
            this.cbProduct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(399, 30);
            this.cbProduct.TabIndex = 7;
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.AutoSize = true;
            this.lblDeliveryDate.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblDeliveryDate.Location = new System.Drawing.Point(16, 202);
            this.lblDeliveryDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(138, 22);
            this.lblDeliveryDate.TabIndex = 8;
            this.lblDeliveryDate.Text = "Дата доставки:";
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.dtpDeliveryDate.Location = new System.Drawing.Point(160, 202);
            this.dtpDeliveryDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(265, 30);
            this.dtpDeliveryDate.TabIndex = 9;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblStatus.Location = new System.Drawing.Point(16, 249);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(73, 22);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Статус:";
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cbStatus.Location = new System.Drawing.Point(160, 249);
            this.cbStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(265, 30);
            this.cbStatus.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(149)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(16, 295);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 49);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(149)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(360, 295);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(200, 49);
            this.btnBack.TabIndex = 13;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // CustomerDeliveryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(576, 359);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dtpDeliveryDate);
            this.Controls.Add(this.lblDeliveryDate);
            this.Controls.Add(this.cbProduct);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.mtbPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.cbCustomer);
            this.Controls.Add(this.lblCustomer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "CustomerDeliveryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление/редактирование доставки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cbCustomer;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.MaskedTextBox mtbPhone;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.Label lblDeliveryDate;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBack;
    }
}