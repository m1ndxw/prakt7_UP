using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace prakt7_UP
{
    public partial class CustomerDeliveryForm : Form
    {
        private readonly string connectionString = "Host=localhost;Port=5432;Database=up_pr7;Username=postgres;Password=virtual;";
        private readonly int? saleId;
        private readonly DeliveryListForm parentForm;
        private List<int> customerIds;
        private List<int> productIds;
        private List<int> statusIds;

        public CustomerDeliveryForm(int? saleId, DeliveryListForm parentForm)
        {
            this.saleId = saleId;
            this.parentForm = parentForm;
            InitializeComponent();
            LoadComboBoxes();
            if (saleId.HasValue)
            {
                LoadDeliveryData();
            }
        }

        // Загрузка данных для выпадающих списков
        private void LoadComboBoxes()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    // Загрузка клиентов
                    customerIds = new List<int>();
                    cbCustomer.Items.Clear();
                    string customerQuery = "SELECT customer_id, full_name FROM Customers";
                    using (var cmd = new NpgsqlCommand(customerQuery, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customerIds.Add(reader.GetInt32(0));
                            cbCustomer.Items.Add(reader.GetString(1));
                        }
                    }

                    // Загрузка товаров
                    productIds = new List<int>();
                    cbProduct.Items.Clear();
                    string productQuery = "SELECT product_id, name FROM Products";
                    using (var cmd = new NpgsqlCommand(productQuery, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productIds.Add(reader.GetInt32(0));
                            cbProduct.Items.Add(reader.GetString(1));
                        }
                    }

                    // Загрузка статусов
                    statusIds = new List<int>();
                    cbStatus.Items.Clear();
                    string statusQuery = "SELECT status_id, name FROM Statuses";
                    using (var cmd = new NpgsqlCommand(statusQuery, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            statusIds.Add(reader.GetInt32(0));
                            cbStatus.Items.Add(reader.GetString(1));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных для выпадающих списков: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Загрузка данных доставки для редактирования
        private void LoadDeliveryData()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT s.customer_id, c.full_name, c.address, c.phone, 
                               si.product_id, p.name AS product_name, 
                               s.delivery_date, s.status_id
                        FROM Sales s
                        LEFT JOIN Customers c ON s.customer_id = c.customer_id
                        JOIN SaleItems si ON s.sale_id = si.sale_id
                        JOIN Products p ON si.product_id = p.product_id
                        WHERE s.sale_id = @saleId";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("saleId", saleId.Value);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int customerId = reader["customer_id"] != DBNull.Value ? reader.GetInt32(0) : -1;
                                if (customerId != -1)
                                {
                                    cbCustomer.SelectedIndex = customerIds.IndexOf(customerId);
                                    txtAddress.Text = reader["address"] != DBNull.Value ? reader.GetString(2) : "";
                                    mtbPhone.Text = reader["phone"] != DBNull.Value ? reader.GetString(3) : "";
                                }
                                int productId = reader.GetInt32(4);
                                cbProduct.SelectedIndex = productIds.IndexOf(productId);
                                dtpDeliveryDate.Value = reader.GetDateTime(6);
                                int statusId = reader.GetInt32(7);
                                cbStatus.SelectedIndex = statusIds.IndexOf(statusId);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных доставки: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик кнопки сохранения
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbCustomer.SelectedIndex < 0 || string.IsNullOrWhiteSpace(txtAddress.Text) ||
                !mtbPhone.MaskCompleted || cbProduct.SelectedIndex < 0 || cbStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Заполните все обязательные поля:\n- Выберите клиента\n- Укажите адрес\n- Введите корректный номер телефона\n- Выберите товар\n- Выберите статус",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    if (saleId.HasValue)
                    {
                        // Обновление существующей записи
                        string updateSaleQuery = @"
                            UPDATE Sales
                            SET customer_id = @customerId, delivery_date = @deliveryDate, status_id = @statusId
                            WHERE sale_id = @saleId";
                        using (var cmd = new NpgsqlCommand(updateSaleQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("customerId", customerIds[cbCustomer.SelectedIndex]);
                            cmd.Parameters.AddWithValue("deliveryDate", dtpDeliveryDate.Value);
                            cmd.Parameters.AddWithValue("statusId", statusIds[cbStatus.SelectedIndex]);
                            cmd.Parameters.AddWithValue("saleId", saleId.Value);
                            cmd.ExecuteNonQuery();
                        }

                        // Обновление клиента
                        string updateCustomerQuery = @"
                            UPDATE Customers
                            SET full_name = @fullName, address = @address, phone = @phone
                            WHERE customer_id = @customerId";
                        using (var cmd = new NpgsqlCommand(updateCustomerQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("fullName", cbCustomer.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("address", txtAddress.Text);
                            cmd.Parameters.AddWithValue("phone", mtbPhone.Text);
                            cmd.Parameters.AddWithValue("customerId", customerIds[cbCustomer.SelectedIndex]);
                            cmd.ExecuteNonQuery();
                        }

                        // Обновление товара в SaleItems
                        string updateSaleItemQuery = @"
                            UPDATE SaleItems
                            SET product_id = @productId
                            WHERE sale_id = @saleId";
                        using (var cmd = new NpgsqlCommand(updateSaleItemQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("productId", productIds[cbProduct.SelectedIndex]);
                            cmd.Parameters.AddWithValue("saleId", saleId.Value);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Получение нового sale_id
                        int newSaleId = GetNextId(conn, "Sales", "sale_id");

                        // Создание новой продажи
                        string insertSaleQuery = @"
                            INSERT INTO Sales (sale_id, customer_id, sale_date, delivery_date, status_id, priority_id, total_amount)
                            VALUES (@saleId, @customerId, @saleDate, @deliveryDate, @statusId, 1, 0)";
                        using (var cmd = new NpgsqlCommand(insertSaleQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("saleId", newSaleId);
                            cmd.Parameters.AddWithValue("customerId", customerIds[cbCustomer.SelectedIndex]);
                            cmd.Parameters.AddWithValue("saleDate", DateTime.Now);
                            cmd.Parameters.AddWithValue("deliveryDate", dtpDeliveryDate.Value);
                            cmd.Parameters.AddWithValue("statusId", statusIds[cbStatus.SelectedIndex]);
                            cmd.ExecuteNonQuery();
                        }

                        // Получение нового sale_item_id
                        int newSaleItemId = GetNextId(conn, "SaleItems", "sale_item_id");

                        // Добавление товара
                        string insertSaleItemQuery = @"
                            INSERT INTO SaleItems (sale_item_id, sale_id, product_id, quantity, subtotal)
                            VALUES (@saleItemId, @saleId, @productId, 1, 0)";
                        using (var cmd = new NpgsqlCommand(insertSaleItemQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("saleItemId", newSaleItemId);
                            cmd.Parameters.AddWithValue("saleId", newSaleId);
                            cmd.Parameters.AddWithValue("productId", productIds[cbProduct.SelectedIndex]);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Обновление списка доставок на главной форме
                    parentForm.RefreshDeliveries();
                    MessageBox.Show("Данные успешно сохранены.", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения данных: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Получение следующего ID для таблицы
        private int GetNextId(NpgsqlConnection conn, string tableName, string idColumn)
        {
            string query = $"SELECT COALESCE(MAX({idColumn}), 0) + 1 FROM {tableName}";
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Обработчик кнопки "Назад"
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}