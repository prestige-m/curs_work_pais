﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace curs_work
{
    public partial class sign_up : Form
    {
        public sign_up()
        {
            InitializeComponent();
        }

        public static string GetHash(string value)
        {
            using (SHA1 sha1Hash = SHA1.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(value);
                byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

                return hash;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(emailField.Text != "" && passField.Text != "" && repeatPassField.Text != "" && lastNameField.Text != "" && nameField.Text != "" && midnameField.Text != "")
            {
                if (passField.Text == repeatPassField.Text)
                {
                    string sql_query = "select * from Users";
                    bool active_user = false;

                    List<object[]> data = DatabaseConnection.ExecuteReader(sql_query);

                    foreach (var row in data)
                    {
                        if (emailField.Text == row[0].ToString())
                        {
                            active_user = true;
                            break;
                        }
                    }

                    if (!active_user)
                    {
                        string sql = "insert into Users values(@email, @password, @first_name, @last_name, @middle_name)";
                        List<SqlParameter> parms = new List<SqlParameter>();

                        SqlParameter param = new SqlParameter("@email", SqlDbType.VarChar, 150);
                        param.Value = emailField.Text;
                        parms.Add(param);

                        param = new SqlParameter("@password", SqlDbType.VarChar, 150);
                        param.Value = GetHash(passField.Text);
                        parms.Add(param);
                        param = new SqlParameter("@first_name", SqlDbType.VarChar, 100);
                        param.Value = nameField.Text;
                        parms.Add(param);
                        param = new SqlParameter("@last_name", SqlDbType.VarChar, 100);
                        param.Value = lastNameField.Text;
                        parms.Add(param);
                        param = new SqlParameter("@middle_name", SqlDbType.VarChar, 100);
                        param.Value = midnameField.Text;
                        parms.Add(param);

                        if(DatabaseConnection.ExecuteNonQuery(sql, parms.ToArray()) != 0)
                        {
                            Alert.ShowMessage("Аккаунт успішно зареєстровано!");
                        }
                     
                    }
                    else  Alert.ShowError("Введений email вже існує");

                }
                else Alert.ShowError("Паролі не співпадають!");
            }
            else Alert.ShowError("Заповніть усі поля!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sign_in form = new sign_in();
            form.Show();
            this.Hide();
        }
    }
}
