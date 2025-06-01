using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace prakt7_UP
{
    public partial class CustomerForm : Form
    {
        private readonly string connectionString = "Host=localhost;Port=5432;Database=up_pr7;Username=postgres;Password=virtual;";
        private readonly int? customerId;
        private readonly CustomerListForm parentForm;

        public CustomerForm(int? customerId, CustomerListForm parentForm)
        {
            this.customerId = customerId;
            this.parentForm = parentForm;
            InitializeComponent();
            if (customerId.HasValue)
            {
                LoadCustomerData();
            }
        }

        // Загрузка данных клиента для редактирования
        private void LoadCustomerData()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT full_name, address, phone FROM Customers WHERE customer_id = @customerId";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("customerId", customerId.Value);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtFullName.Text = reader.GetString(0);
                                txtAddress.Text = reader["address"] != DBNull.Value ? reader.GetString(1) : "";
                                mtbPhone.Text = reader["phone"] != DBNull.Value ? reader.GetString(2) : "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных клиента: " + ex.Message, 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик кнопки сохранения
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || !mtbPhone.MaskCompleted)
            {
                MessageBox.Show("Заполните все обязательные поля:\n- ФИО\n- Корректный номер телефона", 
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    if (customerId.HasValue)
                    {
                        // Обновление существующего клиента
                        string query = @"
                            UPDATE Customers
                            SET full_name = @fullName, address = @address, phone = @phone
                            WHERE customer_id = @customerId";
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("fullName", txtFullName.Text);
                            cmd.Parameters.AddWithValue("address", (object)txtAddress.Text ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("phone", mtbPhone.Text);
                            cmd.Parameters.AddWithValue("customerId", customerId.Value);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Получение нового customer_id
                        string idQuery = "SELECT COALESCE(MAX(customer_id), 0) + 1 FROM Customers";
                        int newCustomerId;
                        using (var cmd = new NpgsqlCommand(idQuery, conn))
                        {
                            newCustomerId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // Добавление нового клиента
                        string insertQuery = @"
                            INSERT INTO Customers (customer_id, full_name, address, phone)
                            VALUES (@customerId, @fullName, @address, @phone)";
                        using (var cmd = new NpgsqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("customerId", newCustomerId);
                            cmd.Parameters.AddWithValue("fullName", txtFullName.Text);
                            cmd.Parameters.AddWithValue("address", (object)txtAddress.Text ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("phone", mtbPhone.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    parentForm.RefreshCustomers();
                    MessageBox.Show("Данные клиента успешно сохранены.", 
                        "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения данных клиента: " + ex.Message, 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик кнопки "Назад"
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}