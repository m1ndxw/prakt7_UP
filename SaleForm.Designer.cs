namespace prakt7_UP
{
    partial class SaleForm
    {
        private System.ComponentModel.IContainer components = null;
        private decimal totalAmount = 0m;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaleForm));
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.chkDelivery = new System.Windows.Forms.CheckBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.btnCompleteSale = new System.Windows.Forms.Button();
            this.btnClearCart = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCategory
            // 
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cbCategory.Location = new System.Drawing.Point(16, 15);
            this.cbCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(332, 30);
            this.cbCategory.TabIndex = 0;
            // 
            // cbProduct
            // 
            this.cbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProduct.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cbProduct.Location = new System.Drawing.Point(16, 62);
            this.cbProduct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(332, 30);
            this.cbProduct.TabIndex = 1;
            // 
            // cbCustomer
            // 
            this.cbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomer.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cbCustomer.Location = new System.Drawing.Point(16, 108);
            this.cbCustomer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(332, 30);
            this.cbCustomer.TabIndex = 2;
            this.cbCustomer.SelectedIndexChanged += new System.EventHandler(this.cbCustomer_SelectedIndexChanged);
            // 
            // nudQuantity
            // 
            this.nudQuantity.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.nudQuantity.Location = new System.Drawing.Point(357, 62);
            this.nudQuantity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(107, 30);
            this.nudQuantity.TabIndex = 3;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(149)))));
            this.btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCart.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnAddToCart.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.Location = new System.Drawing.Point(472, 62);
            this.btnAddToCart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(200, 32);
            this.btnAddToCart.TabIndex = 4;
            this.btnAddToCart.Text = "Добавить в корзину";
            this.btnAddToCart.UseVisualStyleBackColor = false;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new System.Drawing.Point(16, 155);
            this.dgvCart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.RowHeadersWidth = 51;
            this.dgvCart.Size = new System.Drawing.Size(656, 185);
            this.dgvCart.TabIndex = 5;
            // 
            // chkDelivery
            // 
            this.chkDelivery.AutoSize = true;
            this.chkDelivery.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.chkDelivery.Location = new System.Drawing.Point(16, 359);
            this.chkDelivery.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkDelivery.Name = "chkDelivery";
            this.chkDelivery.Size = new System.Drawing.Size(169, 26);
            this.chkDelivery.TabIndex = 6;
            this.chkDelivery.Text = "Нужна доставка";
            this.chkDelivery.CheckedChanged += new System.EventHandler(this.chkDelivery_CheckedChanged);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblTotalAmount.Location = new System.Drawing.Point(16, 400);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(206, 22);
            this.lblTotalAmount.TabIndex = 7;
            this.lblTotalAmount.Text = "Итоговая сумма: 0 руб.";
            // 
            // btnCompleteSale
            // 
            this.btnCompleteSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(149)))));
            this.btnCompleteSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompleteSale.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnCompleteSale.ForeColor = System.Drawing.Color.White;
            this.btnCompleteSale.Location = new System.Drawing.Point(16, 443);
            this.btnCompleteSale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCompleteSale.Name = "btnCompleteSale";
            this.btnCompleteSale.Size = new System.Drawing.Size(200, 49);
            this.btnCompleteSale.TabIndex = 8;
            this.btnCompleteSale.Text = "Оформить продажу";
            this.btnCompleteSale.UseVisualStyleBackColor = false;
            this.btnCompleteSale.Click += new System.EventHandler(this.btnCompleteSale_Click);
            // 
            // btnClearCart
            // 
            this.btnClearCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(149)))));
            this.btnClearCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCart.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnClearCart.ForeColor = System.Drawing.Color.White;
            this.btnClearCart.Location = new System.Drawing.Point(224, 443);
            this.btnClearCart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(200, 49);
            this.btnClearCart.TabIndex = 9;
            this.btnClearCart.Text = "Очистить корзину";
            this.btnClearCart.UseVisualStyleBackColor = false;
            this.btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(149)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(472, 443);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(200, 49);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(167)))));
            this.flowLayoutPanel.Location = new System.Drawing.Point(16, 505);
            this.flowLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(656, 185);
            this.flowLayoutPanel.TabIndex = 11;
            // 
            // SaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(688, 704);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnClearCart);
            this.Controls.Add(this.btnCompleteSale);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.chkDelivery);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.cbCustomer);
            this.Controls.Add(this.cbProduct);
            this.Controls.Add(this.cbCategory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "SaleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Оформление продажи";
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.ComboBox cbCustomer;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.CheckBox chkDelivery;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Button btnCompleteSale;
        private System.Windows.Forms.Button btnClearCart;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
    }
}