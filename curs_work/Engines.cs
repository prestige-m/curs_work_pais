﻿using System;
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
    public partial class Engines : Form
    {

        private bool isUpdate = false;
        public Engines()
        {
            InitializeComponent();
        }

        private void Engines_Load(object sender, EventArgs e)
        {
            this.fuelTypesTableAdapter.Fill(this.carAccountDataSet.FuelTypes);
            this.enginesTableAdapter.Fill(this.carAccountDataSet.Engines);
        }

        private void add_bt_Click(object sender, EventArgs e)
        {
            string message = "";
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    int capacity = int.Parse(textBox2.Text);
                    double volume = double.Parse(textBox3.Text);
                    int fuel_id = Convert.ToInt32(comboBox1.SelectedValue);

                    if (!isUpdate)
                    { 
                        this.enginesTableAdapter.Insert(textBox1.Text, capacity, volume, fuel_id);
                        message = "додано";
                    }
                    else
                    {
                        this.enginesTableAdapter.UpdateQuery(textBox1.Text, capacity, volume, fuel_id, (int)dataGridView1.CurrentRow.Cells[0].Value);
                        message = "оновлено";
                    }
                    this.enginesTableAdapter.Update(this.carAccountDataSet.Engines);
                    this.enginesTableAdapter.Fill(this.carAccountDataSet.Engines);

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
                        this.enginesTableAdapter.DeleteQuery((int)dataGridView1.CurrentRow.Cells[0].Value);
                        this.enginesTableAdapter.Update(this.carAccountDataSet.Engines);
                        this.enginesTableAdapter.Fill(this.carAccountDataSet.Engines);

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
                this.enginesTableAdapter.SearchQuery(this.carAccountDataSet.Engines, searchBox.Text);
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
            this.enginesTableAdapter.Fill(this.carAccountDataSet.Engines);
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
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }

        private void GetValues()
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            label1.Text = "Код: " + dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
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
    }
}