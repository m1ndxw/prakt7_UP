using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace prakt7_UP
{
    public partial class CustomerListForm : Form
    {
        private readonly string connectionString = "Host=localhost;Port=5432;Database=up_pr7;Username=postgres;Password=virtual;";
        private readonly DeliveryListForm parentForm;

        public CustomerListForm(DeliveryListForm parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();
            LoadCustomers();
        }

        // Загрузка списка клиентов
        private void LoadCustomers()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT customer_id, full_name, address, phone FROM Customers";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dgvCustomers.DataSource = dt;

                        // Скрытие столбца с первичным ключом
                        dgvCustomers.Columns["customer_id"].Visible = false;

                        // Перевод заголовков столбцов на русский
                        dgvCustomers.Columns["full_name"].HeaderText = "ФИО";
                        dgvCustomers.Columns["address"].HeaderText = "Адрес";
                        dgvCustomers.Columns["phone"].HeaderText = "Телефон";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки списка клиентов: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик двойного клика на строке для редактирования клиента
        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int customerId = Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells["customer_id"].Value);
                CustomerForm editForm = new CustomerForm(customerId, this);
                editForm.ShowDialog();
            }
        }

        // Обработчик кнопки добавления клиента
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            CustomerForm addForm = new CustomerForm(null, this);
            addForm.ShowDialog();
        }

        // Обновление списка клиентов
        public void RefreshCustomers()
        {
            LoadCustomers();
        }

        // Обработчик кнопки "Назад"
        private void btnBack_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Close();
        }
    }
}