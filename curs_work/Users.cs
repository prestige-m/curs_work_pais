using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace curs_work
{
    public partial class Users : Form
    {
        private bool isUpdate = false;
        public Users()
        {
            InitializeComponent();
        }

        private void add_bt_Click(object sender, EventArgs e)
        {
            string message = "";
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
                {
                    string email = textBox1.Text;
                    string passwordHash = sign_up.GetHash(textBox2.Text);
                    string first_name = textBox3.Text;
                    string last_name = textBox4.Text;
                    string middle_name = textBox5.Text;
                    string position = textBox6.Text;

                    if (!isUpdate)
                    {
                        this.usersTableAdapter.Insert(email, passwordHash, first_name, last_name, middle_name, position);
                        message = "додано";
                    }
                    else
                    {
                        this.usersTableAdapter.UpdateQuery(email, passwordHash, first_name, last_name, middle_name, position, (int)dataGridView1.CurrentRow.Cells[0].Value);
                        message = "оновлено";
                    }
                    this.usersTableAdapter.Update(this.carAccountDataSet.Users);
                    this.usersTableAdapter.Fill(this.carAccountDataSet.Users);

                    Thread.Sleep(1000);
                    Refresh();
                    MessageBox.Show($"Успішно {message}!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Усі поля повинні бути заповнені!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Виникли проблеми при запиті!\nСпробуйте ще раз.");
            }
        }

        private void delete_bt_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    if (MessageBox.Show("Ви дійсно збираєтесь видалити запис?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.usersTableAdapter.DeleteQuery((int)dataGridView1.CurrentRow.Cells[0].Value);
                        this.usersTableAdapter.Update(this.carAccountDataSet.Users);
                        this.usersTableAdapter.Fill(this.carAccountDataSet.Users);

                        Thread.Sleep(1000);
                        Refresh();
                        MessageBox.Show("Дані видалені!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else MessageBox.Show("Немає записів для видалення!");
            }
            catch
            {
                MessageBox.Show("Виникли проблеми при видаленні!\nСпробуйте ще раз.");
            }
        }

        private void search_bt_Click(object sender, EventArgs e)
        {
            try
            {
                this.usersTableAdapter.SearchQuery(this.carAccountDataSet.Users, searchBox.Text);
            }
            catch
            {
                MessageBox.Show("Виникли проблеми при пошуку!\nСпробуйте ще раз.");
            }
        }

        private void keyPress(object sender, KeyPressEventArgs e)
        {
            string pattern = @"^[a-zа-яії0-9\s,./\-\\]$";
            if (!Regex.IsMatch(e.KeyChar.ToString(), pattern, RegexOptions.IgnoreCase) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void keyPressInt(object sender, KeyPressEventArgs e)
        {
            string pattern = @"^[0-9]$";
            if (!Regex.IsMatch(e.KeyChar.ToString(), pattern, RegexOptions.IgnoreCase) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void keyPressDouble(object sender, KeyPressEventArgs e)
        {
            string pattern = @"^[0-9,]$";
            if (!Regex.IsMatch(e.KeyChar.ToString(), pattern, RegexOptions.IgnoreCase) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void showAllBtn_Click(object sender, EventArgs e)
        {
            this.usersTableAdapter.Fill(this.carAccountDataSet.Users);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                GetValues();
                isUpdate = true;
                addBtn.Text = "Оновити";
            }
            else
            {
                ClearData();
            }
        }

        private void ClearData()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void GetValues()
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
           // textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            label1.Text = "Код: " + dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ClearData();
            label1.Text = "";
            isUpdate = false;
            addBtn.Text = "Додати";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (isUpdate && dataGridView1.CurrentRow != null)
            {
                GetValues();
            }
        }

        private void Users_Load(object sender, EventArgs e)
        {
            this.usersTableAdapter.Fill(this.carAccountDataSet.Users);
        }
    }
}