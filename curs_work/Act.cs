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
        private string sql = "SELECT doc.number as 'Номер документу', doc.issue_date AS 'Дата', Firms.name AS 'Назва підприємства', Firms.edrpou_code AS 'ЄДРПОУ', " +
            "doc.user_id as 'Код особи', Operations.id as 'Код операції', doc.sender_id as 'Здавач', doc.receiver_id as 'Одержувач', doc.debit_bill as 'Дебет/Рахунок'," +
            "doc.debit_code as 'Дебет/Код обліку', doc.credit_bill as 'Кредит/Рахунок', doc.credit_code as 'Кредит/Код обліку', doc.primary_cost as 'Первісна вартість'," +
            "TechPassports.cypher as 'Інвентарний шифр', TechPassports.factory_cypher as 'Заводський шифр', doc.object_code as 'Код об’єкту', doc.norm_code as 'Код відрахувань'," +
            "doc.full_recover as 'Норма повного відновлення', doc.full_repair as 'Норми на кап. ремонт', doc.coefficient as 'Поправочний коефіцієнт', doc.equip_type as 'Тип устаткування'," +
            "doc.equip_code as 'Код устаткування', doc.wearout_sum as 'Сума зносу', TechPassports.release_year as 'Рік випуску', doc.expoit_date as 'Початок експлуатації', " +
            "TechPassports.number as 'Номер паспорту', Users.position as 'Розпорядження від',  [Orders].[date] as 'Дата розпорядження', " +
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
            "INNER JOIN Users ON Users.id = doc.user_id " + 
            "INNER JOIN Orders ON Orders.id = doc.order_id";

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

            string sql_query = "SELECT * FROM TechPassports WHERE TechPassports.id NOT IN (SELECT tech_passport_id FROM AcceptAct)";
            SetComboData(sql_query, ref comboBox4);
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
                if (textBox5.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox6.Text != "" && textBox5.Text != ""
                    && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != ""
                    && textBox13.Text != "" && textBox16.Text != "" && textBox18.Text != "" && textBox19.Text != "" && textBox20.Text != "")
                {
                    int item_id = 1;
                    if (dataGridView1.Rows.Count > 0)
                    {
                        item_id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[0].Value) + 1;
                    }

                    //int docNumber = Convert.ToInt32(textBox1.Text);
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
                    double coefficient = Convert.ToDouble(textBox10.Text);
                    string equip_type = textBox11.Text;
                    int equip_code = Convert.ToInt32(textBox12.Text);
                    decimal wearout_sum = Convert.ToDecimal(textBox13.Text);
                    DateTime expoit_date = dateTimePicker2.Value;
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
                    int order_id = Convert.ToInt32(comboBox12.SelectedValue);

                    if (!isUpdate)
                    { 
                        this.acceptActTableAdapter.Insert(firm_id, docDate, userId, operationId, senderId, receiverId, debitBill, debitCode, creditBill,
                            creditCode, primary_cost, tech_passport_id, object_code, norm_code, full_recover, full_repair, coefficient, equip_type,
                            equip_code, wearout_sum, expoit_date, object_place, description, spec_meet, need_refine,
                            results, conclusion, spec_list, comm_head_id, first_member_id, second_member_id, accepted_id, handover_id, order_id);
                        message = "додано";
                    }
                    else
                    {
                        int itemId =  Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                        this.acceptActTableAdapter.UpdateQuery(firm_id, docDate.ToString(), userId, operationId, senderId, receiverId, debitBill, debitCode, creditBill,
                            creditCode, primary_cost, tech_passport_id, object_code, norm_code, full_recover, full_repair, coefficient, equip_type,
                            equip_code, wearout_sum, expoit_date.ToString(), object_place, description, spec_meet, need_refine,
                            results, conclusion, spec_list, comm_head_id, first_member_id, second_member_id, accepted_id, handover_id, order_id, itemId);
                        message = "оновлено";
                    }
                    AdapterUpdate(sql);

                    Thread.Sleep(1000);
                    Refresh();
                    MessageBox.Show($"Успішно {message}!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Усі поля повинні бути заповнені!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникли проблеми при запиті!\nСпробуйте ще раз. {ex}");
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
                int number = -1;
                try
                {
                    number = Convert.ToInt32(searchBox.Text);
                }
                catch { }
                DateTime date = searchDate.Value;
                string newQuery = this.sql + $" WHERE doc.number='{number}' OR doc.issue_date='{date.ToShortDateString()}'";
                AdapterUpdate(newQuery);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникли проблеми при пошуку!\nСпробуйте ще раз. {ex}");
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
            comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox5.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            label36.Text = "#" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
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
                ClearTexts();
            }
        }

        private void ClearTexts()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox16.Clear();
            textBox19.Clear();
            textBox20.Clear();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ClearTexts();
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
            this.ordersTableAdapter.Fill(this.carAccountDataSet.Orders);
            this.techPassportsTableAdapter.Fill(this.carAccountDataSet.TechPassports);
            this.operationsTableAdapter.Fill(this.carAccountDataSet.Operations);
            this.firmsTableAdapter.Fill(this.carAccountDataSet.Firms);
            this.usersTableAdapter.Fill(this.carAccountDataSet.Users);
            this.acceptActTableAdapter.Fill(this.carAccountDataSet.AcceptAct);

            SelectBox3();
            SelectBox6();
            SelectBox7();
            SelectBox8();
            SelectBox9();
            SelectBox10();

            string query = "SELECT * FROM TechPassports WHERE TechPassports.id NOT IN (SELECT tech_passport_id FROM AcceptAct)";
            SetComboData(query, ref comboBox4);
        }

        private void SetComboData(string query, ref ComboBox sender)
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, DatabaseConnection.Connection);
            adapter.Update(table);
            adapter.Fill(table);
            sender.DataSource = table;
        }

        private void SelectBox3()
        {
            string name = comboBox11.Text;
            string query = $"SELECT * FROM Firms WHERE name != '{name}'";
            SetComboData(query, ref comboBox3);
        }

        private void SelectBox6()
        {
            string name1 = comboBox11.Text;
            string name2 = comboBox3.Text;
            string query = $"SELECT * FROM Firms WHERE name != '{name1}' AND name != '{name2}'";
            SetComboData(query, ref comboBox6);
        }

        private void SelectBox7()
        {
            string name = comboBox5.Text;
            string query = $"SELECT * FROM Users WHERE last_name != '{name}'";
            SetComboData(query, ref comboBox7);
        }
        private void SelectBox8()
        {
            string name1 = comboBox5.Text;
            string name2 = comboBox7.Text;
            string query = $"SELECT * FROM Users WHERE last_name != '{name1}' AND last_name != '{name2}'";
            SetComboData(query, ref comboBox8);
        }
        private void SelectBox9()
        {
            string name1 = comboBox5.Text;
            string name2 = comboBox7.Text;
            string name3 = comboBox8.Text;
            string query = $"SELECT * FROM Users WHERE last_name != '{name1}' AND last_name != '{name2}' AND last_name != '{name3}'";
            SetComboData(query, ref comboBox9);
        }
        private void SelectBox10()
        {
            string name1 = comboBox5.Text;
            string name2 = comboBox7.Text;
            string name3 = comboBox8.Text;
            string name4 = comboBox9.Text;
            string query = $"SELECT * FROM Users WHERE last_name != '{name1}' AND last_name != '{name2}' AND last_name != '{name3}' AND last_name != '{name4}'";
            SetComboData(query, ref comboBox10);
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectBox6();
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectBox3();
            SelectBox6();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectBox7();
            SelectBox8();
            SelectBox9();
            SelectBox10();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectBox8();
            SelectBox9();
            SelectBox10();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectBox9();
            SelectBox10();
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectBox10();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int docNumber = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                DateTime docDate = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[1].Value);

                string firmName = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                int edrpou = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value);                
                int userId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value);
                int operationId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value);
                string senderName = Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value);
                string receiverName = Convert.ToString(dataGridView1.CurrentRow.Cells[7].Value);
                int debitBill = Convert.ToInt32(dataGridView1.CurrentRow.Cells[8].Value);
                int debitCode = Convert.ToInt32(dataGridView1.CurrentRow.Cells[9].Value);
                int creditBill = Convert.ToInt32(dataGridView1.CurrentRow.Cells[10].Value);
                int creditCode = Convert.ToInt32(dataGridView1.CurrentRow.Cells[11].Value);
                decimal primary_cost = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[12].Value);
                int cypher = Convert.ToInt32(dataGridView1.CurrentRow.Cells[13].Value);
                int cypher_factory = Convert.ToInt32(dataGridView1.CurrentRow.Cells[14].Value);
                int object_code = Convert.ToInt32(dataGridView1.CurrentRow.Cells[15].Value);
                int norm_code = Convert.ToInt32(dataGridView1.CurrentRow.Cells[16].Value);
                decimal full_recover = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[17].Value);
                int full_repair = Convert.ToInt32(dataGridView1.CurrentRow.Cells[18].Value);
                double coefficient = Convert.ToDouble(dataGridView1.CurrentRow.Cells[19].Value);
                string equip_type = Convert.ToString(dataGridView1.CurrentRow.Cells[20].Value);
                int equip_code = Convert.ToInt32(dataGridView1.CurrentRow.Cells[21].Value);
                decimal wearout_sum = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[22].Value);
                int release_year = Convert.ToInt32(dataGridView1.CurrentRow.Cells[23].Value);
                DateTime expoit_date = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[24].Value);
                string tech_passport_id = Convert.ToString(dataGridView1.CurrentRow.Cells[25].Value);
                string user_position = Convert.ToString(dataGridView1.CurrentRow.Cells[26].Value);
                DateTime order_date = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[27].Value);
                string object_place = Convert.ToString(dataGridView1.CurrentRow.Cells[28].Value);
                string description = Convert.ToString(dataGridView1.CurrentRow.Cells[31].Value);
                string spec_meet = Convert.ToString(dataGridView1.CurrentRow.Cells[32].Value);
                string need_refine = Convert.ToString(dataGridView1.CurrentRow.Cells[33].Value);
                string results = Convert.ToString(dataGridView1.CurrentRow.Cells[34].Value);
                string conclusion = Convert.ToString(dataGridView1.CurrentRow.Cells[35].Value);
                string spec_list = Convert.ToString(dataGridView1.CurrentRow.Cells[36].Value);
                string comm_head_name = Convert.ToString(dataGridView1.CurrentRow.Cells[37].Value);
                string comm_head_position = Convert.ToString(dataGridView1.CurrentRow.Cells[38].Value);
                string first_member_name = Convert.ToString(dataGridView1.CurrentRow.Cells[39].Value);
                string first_member_position = Convert.ToString(dataGridView1.CurrentRow.Cells[40].Value);
                string second_member_name = Convert.ToString(dataGridView1.CurrentRow.Cells[41].Value);
                string second_member_position = Convert.ToString(dataGridView1.CurrentRow.Cells[42].Value);
                string accepted_name = Convert.ToString(dataGridView1.CurrentRow.Cells[43].Value);
                string accepted_position = Convert.ToString(dataGridView1.CurrentRow.Cells[44].Value);
                string handover_name = Convert.ToString(dataGridView1.CurrentRow.Cells[45].Value);
                string handover_position = Convert.ToString(dataGridView1.CurrentRow.Cells[46].Value);

                docForm form = new docForm(firmName, edrpou, docNumber, docDate, userId, operationId, senderName, receiverName, debitBill, debitCode, creditBill,
                                creditCode, primary_cost, cypher, cypher_factory, object_code, norm_code, full_recover, full_repair, coefficient, equip_type,
                                equip_code, wearout_sum, release_year, expoit_date, tech_passport_id, user_position, order_date, object_place,
                                description, spec_meet, need_refine, results, conclusion, spec_list, comm_head_name, comm_head_position,
                                first_member_name, first_member_position, second_member_name, second_member_position, accepted_name, accepted_position,
                                handover_name, handover_position);
                form.Show();
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker picker = (DateTimePicker)sender;
            if (picker.Value < dateTimePicker1.Value)
            {
                Alert.ShowWarning("Дата експлуатації має бути більша, ніж дата акту прийняття!");
                picker.Value = dateTimePicker1.Value;
            }
        }
    }
}