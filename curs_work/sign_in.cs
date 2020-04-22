using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace curs_work
{
    public partial class sign_in : Form
    {
        MainForm mainForm;
        string last_name;
        string first_name;
        string middle_name;

        private void button1_Click(object sender, EventArgs e)
        {
            sign_up signUpForm = new sign_up();
            signUpForm.Show();
            this.Hide();
        }

        bool is_user_found = false;
        public sign_in()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (emailField.Text != "" && passField.Text != "")
            {

                string sql_query = "select * from Users";
                is_user_found = false;

                List<object[]> data = DatabaseConnection.ExecuteReader(sql_query);

                string passwordHash = sign_up.GetHash(passField.Text);
                foreach (var row in data)
                {
                    if (emailField.Text == row[1].ToString() && passwordHash == row[2].ToString())
                    {
                        
                        last_name = row[4].ToString();
                        first_name = row[3].ToString();
                        middle_name = row[5].ToString();
                        string message = $"Вітаємо, {last_name} {first_name}";

                        mainForm = new MainForm(message, emailField.Text, this);
                        mainForm.Show();
                        is_user_found = true;
                        this.Visible = false;
                        break;
                    }
                }

                if (!is_user_found)
                {
                    Alert.ShowWarning("Користувача не знайдено!");
                }
            }
            else
            {
                Alert.ShowError("Заповніть усі поля!");
            }

        }
    }
}
