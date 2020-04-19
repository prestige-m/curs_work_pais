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
    public partial class Colors : Form
    {
        private bool isUpdate = false;
        public Colors()
        {
            InitializeComponent();
        }

        private void Colors_Load(object sender, EventArgs e)
        {
            this.colorsTableAdapter.Fill(this.carAccountDataSet.Colors);
        }

        private void add_bt_Click(object sender, EventArgs e)
        {
            string message = "";
            try
            {
                if (textBox1.Text != "")
                {
                    if (!isUpdate)
                    {
                        this.colorsTableAdapter.Insert(textBox1.Text);
                        message = "додано";
                    }
                    else
                    {
                        this.colorsTableAdapter.UpdateQuery(textBox1.Text, (int)dataGridView1.CurrentRow.Cells[0].Value);
                        message = "оновлено";
                    }
                    this.colorsTableAdapter.Update(this.carAccountDataSet.Colors);
                    this.colorsTableAdapter.Fill(this.carAccountDataSet.Colors);

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
                        this.colorsTableAdapter.DeleteQuery((int)dataGridView1.CurrentRow.Cells[0].Value);
                        this.colorsTableAdapter.Update(this.carAccountDataSet.Colors);
                        this.colorsTableAdapter.Fill(this.carAccountDataSet.Colors);

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
                this.colorsTableAdapter.SearchQuery(this.carAccountDataSet.Colors, textBox2.Text);
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

        private void showAllBtn_Click(object sender, EventArgs e)
        {
            this.colorsTableAdapter.Fill(this.carAccountDataSet.Colors);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                textBox1.Text = (string)dataGridView1.CurrentRow.Cells[1].Value;
                label1.Text = "Код: " + (int)dataGridView1.CurrentRow.Cells[0].Value;
                isUpdate = true;
                addBtn.Text = "Оновити";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            label1.Text = "";
            isUpdate = false;
            addBtn.Text = "Додати";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (isUpdate && dataGridView1.CurrentRow != null)
            {
                textBox1.Text = (string)dataGridView1.CurrentRow.Cells[1].Value;
                label1.Text = "Код: " + (int)dataGridView1.CurrentRow.Cells[0].Value;
            }
        }
    }
}