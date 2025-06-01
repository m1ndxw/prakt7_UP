using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Npgsql;

namespace prakt7_UP
{
    public partial class SaleForm : Form
    {
        private readonly string connectionString = "Host=localhost;Port=5432;Database=up_pr7;Username=postgres;Password=virtual;";
        private readonly DeliveryListForm parentForm;
        private List<int> categoryIds;
        private List<string> categoryNames;
        private List<int> productIds;
        private Dictionary<int, Product> products;
        private List<int> customerIds;
        private List<string> customerNames;
        private Dictionary<int, Customer> customers;
        private DataTable cartTable;
        private decimal deliveryCost = 500m;

        public SaleForm(DeliveryListForm parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();
            InitializeCartTable();
            LoadCategories();
            LoadCustomers();
        }

        // Инициализация таблицы корзины
        private void InitializeCartTable()
        {
            cartTable = new DataTable();
            cartTable.Columns.Add("Наименование", typeof(string));
            cartTable.Columns.Add("Количество", typeof(int));
            cartTable.Columns.Add("Цена", typeof(decimal));
            cartTable.Columns.Add("Итого", typeof(decimal));
            cartTable.Columns.Add("ProductId", typeof(int));
            dgvCart.DataSource = cartTable;
            dgvCart.Columns["ProductId"].Visible = false;
        }

        // Загрузка категорий товаров
        private void LoadCategories()
        {
            try
            {
                categoryIds = new List<int>();
                categoryNames = new List<string>();
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT category_id, name FROM Categories";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categoryIds.Add(reader.GetInt32(0));
                            categoryNames.Add(reader.GetString(1));
                        }
                    }
                }
                cbCategory.DataSource = categoryNames;
                cbCategory.SelectedIndexChanged += cbCategory_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки категорий: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Загрузка клиентов
        private void LoadCustomers()
        {
            try
            {
                customerIds = new List<int>();
                customerNames = new List<string>();
                customers = new Dictionary<int, Customer>();
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT customer_id, full_name, address FROM Customers";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int customerId = reader.GetInt32(0);
                            customerIds.Add(customerId);
                            customerNames.Add(reader.GetString(1));
                            customers[customerId] = new Customer
                            {
                                CustomerId = customerId,
                                FullName = reader.GetString(1),
                                Address = reader["address"] != DBNull.Value ? reader.GetString(2) : ""
                            };
                        }
                    }
                }
                cbCustomer.DataSource = customerNames;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки клиентов: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик изменения категории для загрузки товаров
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategory.SelectedIndex < 0) return;
            int categoryId = categoryIds[cbCategory.SelectedIndex];
            LoadProducts(categoryId);
        }

        // Загрузка товаров по выбранной категории
        private void LoadProducts(int categoryId)
        {
            try
            {
                productIds = new List<int>();
                products = new Dictionary<int, Product>();
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT product_id, name, price, stock_quantity FROM Products WHERE category_id = @categoryId";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("categoryId", categoryId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int productId = reader.GetInt32(0);
                                productIds.Add(productId);
                                products[productId] = new Product
                                {
                                    ProductId = productId,
                                    Name = reader.GetString(1),
                                    Price = reader.GetDecimal(2),
                                    StockQuantity = reader.GetInt32(3)
                                };
                            }
                        }
                    }
                    cbProduct.DataSource = products.Values.ToList();
                    cbProduct.DisplayMember = "Name";
                    cbProduct.ValueMember = "ProductId";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки товаров: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик кнопки добавления товара в корзину
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (cbProduct.SelectedIndex < 0 || nudQuantity.Value <= 0)
            {
                MessageBox.Show("Выберите товар и укажите количество.",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = (cbProduct.SelectedItem as Product)?.ProductId ?? -1;
            if (!products.TryGetValue(productId, out Product product))
            {
                MessageBox.Show("Ошибка получения данных о товаре.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int quantity = (int)nudQuantity.Value;

            if (quantity > product.StockQuantity)
            {
                MessageBox.Show($"На складе недостаточно товара. Доступно: {product.StockQuantity} шт.",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRow existingRow = cartTable.AsEnumerable().FirstOrDefault(row => (int)row["ProductId"] == productId);
            if (existingRow != null)
            {
                int currentQuantity = (int)existingRow["Количество"];
                int newQuantity = currentQuantity + quantity;
                if (newQuantity > product.StockQuantity)
                {
                    MessageBox.Show($"На складе недостаточно товара. Доступно: {product.StockQuantity} шт.",
                        "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                existingRow["Количество"] = newQuantity;
                existingRow["Итого"] = newQuantity * product.Price;
            }
            else
            {
                DataRow row = cartTable.NewRow();
                row["Наименование"] = product.Name;
                row["Количество"] = quantity;
                row["Цена"] = product.Price;
                row["Итого"] = quantity * product.Price;
                row["ProductId"] = productId;
                cartTable.Rows.Add(row);
            }

            UpdateTotalAmount();
        }

        // Обновление итоговой суммы
        private void UpdateTotalAmount()
        {
            decimal total = cartTable.AsEnumerable().Sum(row => (decimal)row["Итого"]);

            if (chkDelivery.Checked && cbCustomer.SelectedIndex >= 0)
            {
                int customerId = customerIds[cbCustomer.SelectedIndex];
                var customer = customers[customerId];
                decimal deliveryFee = customer.Address.StartsWith("652050") ? 0m : deliveryCost;
                total += deliveryFee;
            }

            lblTotalAmount.Text = $"Итоговая сумма: {total} руб.";
            totalAmount = total; // Синхронизация с полем класса
        }

        // Обработчик изменения чекбокса доставки
        private void chkDelivery_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTotalAmount();
        }

        // Обработчик выбора клиента
        private void cbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotalAmount();
        }

        // Получение следующего ID для таблицы
        private int GetNextId(string tableName, string idColumn)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = $"SELECT COALESCE(MAX({idColumn}), 0) + 1 FROM {tableName}";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // Обработчик кнопки очистки корзины
        private void btnClearCart_Click(object sender, EventArgs e)
        {
            cartTable.Clear();
            UpdateTotalAmount();
        }

        // Обработчик кнопки оформления продажи
        private void btnCompleteSale_Click(object sender, EventArgs e)
        {
            try
            {
                if (cartTable.Rows.Count == 0)
                {
                    MessageBox.Show("Корзина пуста. Добавьте товары.",
                        "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbCustomer.SelectedIndex < 0)
                {
                    MessageBox.Show("Выберите клиента.",
                        "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int customerId = customerIds[cbCustomer.SelectedIndex];
                var customer = customers[customerId];

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    // Получение нового sale_id
                    int newSaleId = GetNextId("Sales", "sale_id");

                    // Создание новой продажи
                    decimal totalAmount = cartTable.AsEnumerable().Sum(row => (decimal)row["Итого"]);
                    if (chkDelivery.Checked)
                    {
                        decimal deliveryFee = customer.Address.StartsWith("652050") ? 0m : deliveryCost;
                        totalAmount += deliveryFee;
                    }

                    string saleQuery = @"
                        INSERT INTO Sales (sale_id, customer_id, sale_date, delivery_date, status_id, priority_id, total_amount)
                        VALUES (@saleId, @customerId, @saleDate, @deliveryDate, 1, 1, @totalAmount)
                        RETURNING sale_id";
                    using (var cmd = new NpgsqlCommand(saleQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("saleId", newSaleId);
                        cmd.Parameters.AddWithValue("customerId", customerId);
                        cmd.Parameters.AddWithValue("saleDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("deliveryDate", chkDelivery.Checked ? (object)DateTime.Now.AddDays(3) : DBNull.Value);
                        cmd.Parameters.AddWithValue("totalAmount", totalAmount);
                        cmd.ExecuteNonQuery();
                    }

                    // Получение нового sale_item_id
                    int saleItemId = GetNextId("SaleItems", "sale_item_id");

                    // Добавление товаров в продажу
                    foreach (DataRow row in cartTable.AsEnumerable())
                    {
                        int productId = (int)row["ProductId"];
                        int quantity = (int)row["Количество"];
                        decimal subtotal = (decimal)row["Итого"];

                        string saleItemQuery = @"
                            INSERT INTO SaleItems (sale_item_id, sale_id, product_id, quantity, subtotal)
                            VALUES (@saleItemId, @saleId, @productId, @quantity, @subtotal)";
                        using (var cmd = new NpgsqlCommand(saleItemQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("saleItemId", saleItemId);
                            cmd.Parameters.AddWithValue("saleId", newSaleId);
                            cmd.Parameters.AddWithValue("productId", productId);
                            cmd.Parameters.AddWithValue("quantity", quantity);
                            cmd.Parameters.AddWithValue("subtotal", subtotal);
                            cmd.ExecuteNonQuery();
                            saleItemId++;
                        }

                        // Обновление количества товара на складе
                        string updateStockQuery = @"
                            UPDATE Products SET stock_quantity = stock_quantity - @quantity
                            WHERE product_id = @productId";
                        using (var cmd = new NpgsqlCommand(updateStockQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("quantity", quantity);
                            cmd.Parameters.AddWithValue("productId", productId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                // Обновление поля totalAmount
                UpdateTotalAmount();
                // Создание панели с информацией о продаже
                Panel salePanel = CreateSalePanel(customer, cartTable);
                flowLayoutPanel.Controls.Add(salePanel);

                // Очистка корзины
                cartTable.Clear();
                UpdateTotalAmount();

                MessageBox.Show("Продажа успешно оформлена.",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка оформления продажи: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Создание панели с информацией о продаже
        private Panel CreateSalePanel(Customer customer, DataTable cart)
        {
            Panel panel = new Panel
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(492, 150),
                Margin = new Padding(10)
            };

            Label customerLabel = new Label
            {
                AutoSize = true,
                Location = new Point(10, 10),
                Text = "Клиент: " + customer.FullName,
                Font = new Font("Times New Roman", 12, FontStyle.Bold)
            };

            Label addressLabel = new Label
            {
                AutoSize = true,
                Location = new Point(10, 30),
                Text = "Адрес: " + (string.IsNullOrEmpty(customer.Address) ? "Не указан" : customer.Address),
                Font = new Font("Times New Roman", 10)
            };

            Label productsLabel = new Label
            {
                AutoSize = true,
                Location = new Point(10, 50),
                Text = "Товары: " + string.Join(", ", cart.AsEnumerable().Select(row => row["Наименование"].ToString())),
                Font = new Font("Times New Roman", 10)
            };

            Label totalLabel = new Label
            {
                AutoSize = true,
                Location = new Point(10, 90),
                Text = "Итоговая сумма: " + totalAmount.ToString("0.00") + " руб.",
                Font = new Font("Times New Roman", 10, FontStyle.Bold)
            };

            Label deliveryDateLabel = new Label
            {
                AutoSize = true,
                Location = new Point(10, 110),
                Text = "Дата доставки: " + (chkDelivery.Checked ? DateTime.Now.AddDays(3).ToString("dd.MM.yyyy") : "Не требуется"),
                Font = new Font("Times New Roman", 10)
            };

            panel.Controls.Add(customerLabel);
            panel.Controls.Add(addressLabel);
            panel.Controls.Add(productsLabel);
            panel.Controls.Add(totalLabel);
            panel.Controls.Add(deliveryDateLabel);

            return panel;
        }

        // Обработчик кнопки "Назад"
        private void btnBack_Click(object sender, EventArgs e)
        {
            parentForm.RefreshDeliveries();
            parentForm.Show();
            this.Close();
        }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }

    public class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
    }
}