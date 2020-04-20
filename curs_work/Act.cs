using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class Act : Form
    {
        private string sql = "SELECT Firms.name AS 'Назва підприємства', Firms.edrpou_code AS 'ЄДРПОУ', doc.number as 'Номер документу', doc.issue_date AS 'Дата'," +
            "doc.user_id as 'Код особи', Operations.id as 'Код операції', doc.sender_id as 'Здавач', doc.receiver_id as 'Одержувач', doc.debit_bill as 'Дебет/Рахунок'," +
            "doc.debit_code as 'Дебет/Код обліку', doc.credit_bill as 'Кредит/Рахунок', doc.credit_code as 'Кредит/Код обліку', doc.primary_cost as 'Первісна вартість'," +
            "TechPassports.cypher as 'Інвентарний шифр', TechPassports.factory_cypher as 'Заводський шифр', doc.object_code as 'Код об’єкту', doc.norm_code as 'Код відрахувань'," +
            "doc.full_recover as 'Норма повного відновлення', doc.full_repair as 'Норми на кап. ремонт', doc.coefficient as 'Поправочний коефіцієнт', doc.equip_type as 'Тип устаткування'," +
            "doc.equip_code as 'Код устаткування', doc.wearout_sum as 'Сума зносу', TechPassports.release_year as 'Рік випуску', doc.expoit_date as 'Початок експлуатації', " +
            "TechPassports.number as 'Номер паспорту', Users.position as 'Розпорядження від',  doc.order_date as 'Дата розпорядження', doc.order_number as 'Номер розпорядження'," +
            "doc.object_place as 'Місце об’єкту', CarTypes.name as 'Найменування об’єкту', Firms.name as 'передається від',  doc.description as 'Хар-ка об’єкта'," +
            "doc.spec_meet as 'Відповідність тех. умовам', doc.need_refine as 'Доробка', doc.results as 'Підсумки іспитів об’єкта', doc.conclusion as 'Висновок комісії'," +
            "doc.spec_list as 'перелік тех. інформації', (SELECT SUBSTRING(Users.first_name, 1, 1)+'. '+SUBSTRING(Users.middle_name, 1, 1) +'. '+Users.last_name as comm_head_name FROM Users " + "" +
            " WHERE Users.id = doc.comm_head_id) as 'Голова комісії', (SELECT Users.position FROM Users WHERE Users.id = doc.comm_head_id) as 'Посада голови', " +
            "(SELECT SUBSTRING(Users.first_name, 1, 1)+'. '+SUBSTRING(Users.middle_name, 1, 1) +'. '+Users.last_name as first_mem_name FROM Users " +
            " WHERE Users.id = doc.first_member_id) as 'Член комісії 1', (SELECT Users.position FROM Users WHERE Users.id = doc.first_member_id) as 'Посада члена комісії 1', " +
            "(SELECT SUBSTRING(Users.first_name, 1, 1)+'. '+SUBSTRING(Users.middle_name, 1, 1) +'. '+Users.last_name as second_mem_name FROM Users WHERE Users.id = doc.second_member_id) as 'Член комісії 2', " +
            "(SELECT Users.position FROM Users WHERE Users.id = doc.second_member_id) as 'Посада члена комісії 2', " +
            "(SELECT SUBSTRING(Users.first_name, 1, 1)+'. '+SUBSTRING(Users.middle_name, 1, 1) +'. '+Users.last_name as second_mem_name FROM Users " +
            "WHERE Users.id = doc.accepted_id) as 'Прийняв', (SELECT Users.position FROM Users WHERE Users.id = doc.accepted_id) as 'Посада (прийняв)', " +
            "(SELECT SUBSTRING(Users.first_name, 1, 1)+'. '+SUBSTRING(Users.middle_name, 1, 1) +'. '+Users.last_name as second_mem_name FROM Users " +
            " WHERE Users.id = doc.handover_id) as 'Здав', (SELECT Users.position FROM Users WHERE Users.id = doc.handover_id) as 'Посада (здав)' FROM AcceptAct as doc " +
            "INNER JOIN Firms ON Firms.id = doc.firm_id " +
            "INNER JOIN Operations ON Operations.id = doc.operation_id " +
            "INNER JOIN TechPassports ON TechPassports.id = doc.tech_passport_id " +
            "INNER JOIN CarTypes ON CarTypes.id = TechPassports.car_type_id " +
            "INNER JOIN Users ON Users.id = doc.user_id";

        DataTable table = null;
        SqlDataAdapter adapter = null;
        private bool isUpdate = false;

        public Act()
        {
            InitializeComponent();
            table = new DataTable();
            AdapterUpdate(sql);
            dataGridView1.DataSource = table;
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

                    int docNumber = Convert.ToInt32(textBox1.Text);
                    DateTime docDate = dateTimePicker1.Value;
                    int userId = Convert.ToInt32(comboBox1.SelectedValue);
                    int operationId = Convert.ToInt32(comboBox2.SelectedValue);
                    int senderId = Convert.ToInt32(comboBox3.SelectedValue);
                    int receiverId = Convert.ToInt32(comboBox6.SelectedValue);
                    int debitBill = Convert.ToInt32(textBox2.Text);
                    int debitCode = Convert.ToInt32(textBox3.Text);
                    int creditBill = Convert.ToInt32(textBox5.Text);
                    int creditCode = Convert.ToInt32(textBox6.Text);
                    int firm_id = Convert.ToInt32(comboBox11.SelectedValue);
                    decimal primary_cost = Convert.ToDecimal(numericUpDown1.Value);
                    string tech_passport_id = comboBox4.SelectedValue.ToString();
                    int object_code = Convert.ToInt32(textBox4.Text);
                    int norm_code = Convert.ToInt32(textBox7.Text);
                    int full_recover = Convert.ToInt32(textBox8.Text);
                    int full_repair = Convert.ToInt32(textBox9.Text);
                    int coefficient = Convert.ToInt32(textBox10.Text);
                    string equip_type = textBox11.Text;
                    int equip_code = Convert.ToInt32(textBox12.Text);
                    int wearout_sum = Convert.ToInt32(textBox13.Text);
                    DateTime expoit_date = dateTimePicker2.Value;
                    DateTime order_date = dateTimePicker3.Value;
                    int order_number = Convert.ToInt32(textBox15.Text);
                    string object_place = textBox16.Text;
                    string description = textBox17.Text;
                    string spec_meet = (checkBox1.Checked) ? "відповідає" : "не відповідає";
                    string need_refine = (checkBox2.Checked) ? "потрібна" : "не потрібна";
                    string results = textBox18.Text;
                    string conclusion = textBox19.Text;
                    string spec_list = textBox20.Text;
                    int comm_head_id = Convert.ToInt32(comboBox5.SelectedValue);
                    int first_member_id = Convert.ToInt32(comboBox7.SelectedValue);
                    int second_member_id = Convert.ToInt32(comboBox8.SelectedValue);
                    int accepted_id = Convert.ToInt32(comboBox9.SelectedValue);
                    int handover_id = Convert.ToInt32(comboBox10.SelectedValue);
                    int booker_id = 1;


                    if (!isUpdate)
                    {       
                        this.acceptActTableAdapter.Insert(firm_id, docDate, userId, operationId, senderId, receiverId, debitBill, debitCode, creditBill,
                            creditCode, primary_cost, tech_passport_id, object_code, norm_code, full_recover, full_repair, coefficient, equip_type,
                            equip_code, wearout_sum, expoit_date, order_date, order_number, object_place, description, spec_meet, need_refine,
                            results, conclusion, spec_list, comm_head_id, first_member_id, second_member_id, accepted_id, handover_id, booker_id);
                        message = "додано";
                    }
                    else
                    {
                        int itemId =  Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                        this.acceptActTableAdapter.UpdateQuery(firm_id, docDate.ToString(), userId, operationId, senderId, receiverId, debitBill, debitCode, creditBill,
                            creditCode, primary_cost, tech_passport_id, object_code, norm_code, full_recover, full_repair, coefficient, equip_type,
                            equip_code, wearout_sum, expoit_date.ToString(), order_date.ToString(), order_number, object_place, description, spec_meet, need_refine,
                            results, conclusion, spec_list, comm_head_id, first_member_id, second_member_id, accepted_id, handover_id, booker_id, itemId);
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
                        this.acceptActTableAdapter.DeleteQuery((int)dataGridView1.CurrentRow.Cells[0].Value);
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

        private void Act_Load(object sender, EventArgs e)
        {
             this.acceptActTableAdapter.Fill(this.carAccountDataSet.AcceptAct);
        }
    }
}