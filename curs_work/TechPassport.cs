using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace curs_work
{
    public partial class TechPassport : Form
    {
        DataTable table = null;
        SqlDataAdapter adapter = null;
        private bool isUpdate = false;
        string sql = "SELECT pas.id AS Код, CarTypes.name AS Тип, CarModels.name AS Модель, pas.number AS Номер," +
                " pas.release_year AS [Рік випуску], pas.max_weight AS Вага, Engines.name AS Двигун, Colors.name AS Колір, " +
                "pas.cypher AS Шифр, pas.factory_cypher AS [Заводський шифр] FROM TechPassports AS pas " +
                "INNER JOIN CarTypes ON CarTypes.id = pas.car_type_id " +
                "INNER JOIN CarModels ON CarModels.id = pas.car_model_id " +
                "INNER JOIN Engines ON Engines.id = pas.engine_id " +
                "INNER JOIN Colors ON Colors.id = pas.color_id";
        public TechPassport()
        {
            InitializeComponent();
            table = new DataTable();
            AdapterUpdate(sql);
            dataGridView1.DataSource = table;
            for(int year=DateTime.Now.Year; year >= 1900; year--)
            {
                comboBox2.Items.Add(year.ToString());
            }
            comboBox2.SelectedIndex = 0;
        }

        private void AdapterUpdate(string query)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, DatabaseConnection.Connection);
            table.Rows.Clear();
            adapter.Update(table);
            adapter.Fill(table);
        }

        private void Engines_Load(object sender, EventArgs e)
        {
            this.adapter.Fill(this.carAccountDataSet.Engines);
        }

        private void add_bt_Click(object sender, EventArgs e)
        {
            string message = "";
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    int item_id = 1;
                    if (dataGridView1.Rows.Count > 0)
                    {
                        item_id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[0].Value) + 1;
                    }
                    
                    int car_type_id = Convert.ToInt32(comboBox1.SelectedValue);
                    int car_model_id = Convert.ToInt32(comboBox3.SelectedValue);
                    string number = textBox1.Text;
                    int year = Convert.ToInt32(comboBox2.SelectedItem);
                    double weight = Convert.ToDouble(textBox2.Text);
                    int engine_id = Convert.ToInt32(comboBox4.SelectedValue);
                    int color_id = Convert.ToInt32(comboBox5.SelectedValue);
                    int cypher = Convert.ToInt32(textBox3.Text);
                    int factory_cypher = Convert.ToInt32(textBox4.Text);

                    if (!isUpdate)
                    {
                        this.techPassportsTableAdapter.InsertQuery(item_id.ToString(), car_type_id, car_model_id, number, year, weight, engine_id, color_id, cypher, factory_cypher);
                        message = "додано";
                    }
                    else
                    {
                        string item_iD = (string)dataGridView1.CurrentRow.Cells[0].Value;
                        this.techPassportsTableAdapter.UpdateQuery(car_type_id, car_model_id, number, year, weight, engine_id, color_id, cypher, factory_cypher, item_iD);
                        message = "оновлено";
                    }
                    AdapterUpdate(sql);

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
                        this.techPassportsTableAdapter.DeleteQuery((string)dataGridView1.CurrentRow.Cells[0].Value);
                        AdapterUpdate(sql);

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
                string param = searchBox.Text;
                string newQuery = sql + $" WHERE CarTypes.name LIKE '%{param}%' OR CarModels.name LIKE '%{param}%' OR pas.number LIKE '%{param}%' " +
                    $"OR pas.release_year LIKE '%{param}%' OR pas.max_weight LIKE '%{param}%' OR Engines.name LIKE '%{param}%' OR Colors.name LIKE '%{param}%'";

                AdapterUpdate(newQuery);
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
            this.AdapterUpdate(sql);
        }

        private void GetValues()
        {
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox5.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            label1.Text = "Код: " + dataGridView1.CurrentRow.Cells[0].Value.ToString();
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
                textBox4.Clear();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
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

        private void TechPassport_Load(object sender, EventArgs e)
        {
            this.colorsTableAdapter.Fill(this.carAccountDataSet.Colors);
            this.enginesTableAdapter.Fill(this.carAccountDataSet.Engines);
            this.carModelsTableAdapter.Fill(this.carAccountDataSet.CarModels);
            this.carTypesTableAdapter.Fill(this.carAccountDataSet.CarTypes);
        }
    }
}