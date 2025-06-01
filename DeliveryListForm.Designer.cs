namespace prakt7_UP
{
    partial class DeliveryListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryListForm));
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddDelivery = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnCreateSale = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(167)))));
            this.flowLayoutPanel.Location = new System.Drawing.Point(16, 15);
            this.flowLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(959, 431);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // btnAddDelivery
            // 
            this.btnAddDelivery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(149)))));
            this.btnAddDelivery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDelivery.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnAddDelivery.ForeColor = System.Drawing.Color.White;
            this.btnAddDelivery.Location = new System.Drawing.Point(16, 453);
            this.btnAddDelivery.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddDelivery.Name = "btnAddDelivery";
            this.btnAddDelivery.Size = new System.Drawing.Size(267, 49);
            this.btnAddDelivery.TabIndex = 1;
            this.btnAddDelivery.Text = "Добавить доставку";
            this.btnAddDelivery.UseVisualStyleBackColor = false;
            this.btnAddDelivery.Click += new System.EventHandler(this.btnAddDelivery_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(149)))));
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnCustomers.ForeColor = System.Drawing.Color.White;
            this.btnCustomers.Location = new System.Drawing.Point(373, 453);
            this.btnCustomers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(267, 49);
            this.btnCustomers.TabIndex = 2;
            this.btnCustomers.Text = "Работа с клиентами";
            this.btnCustomers.UseVisualStyleBackColor = false;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnCreateSale
            // 
            this.btnCreateSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(149)))));
            this.btnCreateSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateSale.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnCreateSale.ForeColor = System.Drawing.Color.White;
            this.btnCreateSale.Location = new System.Drawing.Point(708, 453);
            this.btnCreateSale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateSale.Name = "btnCreateSale";
            this.btnCreateSale.Size = new System.Drawing.Size(267, 49);
            this.btnCreateSale.TabIndex = 3;
            this.btnCreateSale.Text = "Оформить продажу";
            this.btnCreateSale.UseVisualStyleBackColor = false;
            this.btnCreateSale.Click += new System.EventHandler(this.btnCreateSale_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::prakt7_UP.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(1009, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // DeliveryListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1159, 517);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCreateSale);
            this.Controls.Add(this.btnCustomers);
            this.Controls.Add(this.btnAddDelivery);
            this.Controls.Add(this.flowLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "DeliveryListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список доставок";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button btnAddDelivery;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnCreateSale;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}