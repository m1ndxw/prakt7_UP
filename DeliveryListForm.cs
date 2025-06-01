using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace prakt7_UP
{
    public partial class DeliveryListForm : Form
    {
        private readonly string connectionString = "Host=localhost;Port=5432;Database=up_pr7;Username=postgres;Password=virtual;";

        public DeliveryListForm()
        {
            InitializeComponent();
            LoadDeliveries();
        }

        // Загрузка списка доставок из базы данных
        private void LoadDeliveries()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT s.sale_id, c.customer_id, c.full_name, c.address, c.phone, 
                               p.name AS product_name, cat.name AS category_name, 
                               s.delivery_date, st.name AS status_name
                        FROM Sales s
                        LEFT JOIN Customers c ON s.customer_id = c.customer_id
                        JOIN SaleItems si ON s.sale_id = si.sale_id
                        JOIN Products p ON si.product_id = p.product_id
                        JOIN Categories cat ON p.category_id = cat.category_id
                        JOIN Statuses st ON s.status_id = st.status_id
                        WHERE s.delivery_date IS NOT NULL";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        flowLayoutPanel.Controls.Clear();
                        while (reader.Read())
                        {
                            Panel deliveryPanel = CreateDeliveryPanel(reader);
                            flowLayoutPanel.Controls.Add(deliveryPanel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки списка доставок: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Создание панели для отображения информации о доставке
        private Panel CreateDeliveryPanel(NpgsqlDataReader reader)
        {
            Panel panel = new Panel
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(600, 150),
                Margin = new Padding(10)
            };

            Label customerLabel = new Label
            {
                AutoSize = true,
                Location = new Point(10, 10),
                Text = "Клиент: " + (reader["full_name"] != DBNull.Value ? reader["full_name"].ToString() : "Не указан"),
                Font = new Font("Times New Roman", 12, FontStyle.Bold)
            };

            Label addressLabel = new Label
            {
                AutoSize = true,
                Location = new Point(10, 30),
                Text = "Адрес: " + (reader["address"] != DBNull.Value ? reader["address"].ToString() : "Не указан"),
                Font = new Font("Times New Roman", 10)
            };

            Label phoneLabel = new Label
            {
                AutoSize = true,
                Location = new Point(10, 50),
                Text = "Телефон: " + (reader["phone"] != DBNull.Value ? reader["phone"].ToString() : "Не указан"),
                Font = new Font("Times New Roman", 10)
            };

            Label productLabel = new Label
            {
                AutoSize = true,
                Location = new Point(10, 70),
                Text = "Товар: " + reader["product_name"].ToString(),
                Font = new Font("Times New Roman", 10)
            };

            Label categoryLabel = new Label
            {
                AutoSize = true,
                Location = new Point(10, 90),
                Text = "Категория: " + reader["category_name"].ToString(),
                Font = new Font("Times New Roman", 10)
            };

            Label deliveryDateLabel = new Label
            {
                AutoSize = true,
                Location = new Point(10, 110),
                Text = "Дата доставки: " + ((DateTime)reader["delivery_date"]).ToString("dd.MM.yyyy"),
                Font = new Font("Times New Roman", 10)
            };

            Label statusLabel = new Label
            {
                AutoSize = true,
                Location = new Point(300, 110),
                Text = "Статус: " + reader["status_name"].ToString(),
                Font = new Font("Times New Roman", 10, FontStyle.Bold)
            };

            // Добавление обработчика клика для редактирования доставки
            panel.Tag = reader["sale_id"];
            panel.Click += (sender, e) =>
            {
                int saleId = (int)((Panel)sender).Tag;
                CustomerDeliveryForm editForm = new CustomerDeliveryForm(saleId, this);
                editForm.ShowDialog();
            };

            panel.Controls.Add(customerLabel);
            panel.Controls.Add(addressLabel);
            panel.Controls.Add(phoneLabel);
            panel.Controls.Add(productLabel);
            panel.Controls.Add(categoryLabel);
            panel.Controls.Add(deliveryDateLabel);
            panel.Controls.Add(statusLabel);

            return panel;
        }

        // Обработчик кнопки добавления новой доставки
        private void btnAddDelivery_Click(object sender, EventArgs e)
        {
            CustomerDeliveryForm addForm = new CustomerDeliveryForm(null, this);
            addForm.ShowDialog();
        }

        // Обновление списка доставок после редактирования
        public void RefreshDeliveries()
        {
            LoadDeliveries();
        }

        // Обработчик кнопки перехода к списку клиентов
        private void btnCustomers_Click(object sender, EventArgs e)
        {
            CustomerListForm customerListForm = new CustomerListForm(this);
            customerListForm.Show();
            this.Hide();
        }

        // Обработчик кнопки оформления продажи
        private void btnCreateSale_Click(object sender, EventArgs e)
        {
            SaleForm saleForm = new SaleForm(this);
            saleForm.Show();
            this.Hide();
        }
    }
}