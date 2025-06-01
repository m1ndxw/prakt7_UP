using System;
using System.Windows.Forms;
using Npgsql;

namespace prakt7_UP
{
    public partial class LoginForm : Form
    {
        private readonly string connectionString = "Host=localhost;Port=5432;Database=up_pr7;Username=postgres;Password=virtual;";

        public LoginForm()
        {
            InitializeComponent();
        }

        // Обработчик кнопки "Войти"
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE username = @username AND password = @password";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("username", username);
                        cmd.Parameters.AddWithValue("password", password);
                        long userCount = (long)cmd.ExecuteScalar();

                        if (userCount > 0)
                        {
                            // Успешная авторизация
                            MessageBox.Show("Авторизация успешна!", "Информация",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Открытие формы DeliveryListForm
                            DeliveryListForm deliveryForm = new DeliveryListForm();
                            deliveryForm.Show();
                            this.Hide(); // Скрываем форму авторизации
                        }
                        else
                        {
                            MessageBox.Show("Неверное имя пользователя или пароль.", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при авторизации: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик кнопки "Выход"
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}