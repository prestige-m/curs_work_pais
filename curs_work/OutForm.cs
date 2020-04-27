using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace curs_work
{
    public partial class OutForm : Form
    {
        private static string db_query = "SELECT TechPassports.id AS Код, CarTypes.name AS Тип, CarModels.name AS Модель, TechPassports.number AS Номер,  " +
                                    " TechPassports.release_year AS [Рік випуску], TechPassports.max_weight AS Вага, Engines.name AS Двигун, Colors.name AS Колір, " + 
                                    " TechPassports.cypher as Шифр, TechPassports.factory_cypher as [Заводський шифр] FROM TechPassports " +
                                    " INNER JOIN CarModels ON CarModels.id = TechPassports.car_model_id " +
                                    " INNER JOIN CarTypes ON CarTypes.id = TechPassports.car_type_id " +
                                    " INNER JOIN Engines ON Engines.id = TechPassports.engine_id " +
                                    " INNER JOIN Colors ON Colors.id = TechPassports.color_id ";

        private string sql1 = db_query + " WHERE TechPassports.id IN (SELECT tech_passport_id FROM AcceptAct)";
        private string sql2 = db_query + " WHERE TechPassports.id NOT IN (SELECT tech_passport_id FROM AcceptAct)";

        DataTable table1 = new DataTable();
        DataTable table2 = new DataTable();
        SqlDataAdapter adapter = null;
        Bitmap bitmap;

        public OutForm()
        {
            InitializeComponent();
            AdapterUpdate(sql1, ref table1);
            AdapterUpdate(sql2, ref table2);
            dataGridView1.DataSource = table1;
            dataGridView2.DataSource = table2;
        }

        private void AdapterUpdate(string query, ref DataTable db_table)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, DatabaseConnection.Connection);
            db_table.Rows.Clear();
            adapter.Update(db_table);
            adapter.Fill(db_table);
        }

        public void PrintForm()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);

            PrintDialog printDialog = new PrintDialog();
            
            int height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height;
            int width = dataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
            bitmap = new Bitmap(width, height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, width, height));

            printDialog.Document = pd;
            if (printDialog.ShowDialog() == DialogResult.OK)
                printDialog.Document.Print();
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e) 
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }


        private void друкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintForm();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string startTime = dateTimePicker1.Value.ToShortDateString();
            string endTime = searchDate.Value.ToShortDateString();
            string query = OutForm.db_query + $" WHERE TechPassports.id IN (SELECT tech_passport_id FROM AcceptAct WHERE issue_date BETWEEN '{startTime}' AND '{endTime}')";
            AdapterUpdate(query, ref table1);
        }

        private void діаграмаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> titles = new List<string>();
            List<int> values = new List<int>();
            string startTime = dateTimePicker1.Value.ToShortDateString();
            string endTime = searchDate.Value.ToShortDateString();

            string query = $"SELECT COUNT(*), CarTypes.name FROM TechPassports INNER JOIN CarTypes ON CarTypes.id = TechPassports.car_type_id " +
                 $" WHERE TechPassports.id IN (SELECT tech_passport_id FROM AcceptAct WHERE issue_date BETWEEN '{startTime}' AND '{endTime}') GROUP BY CarTypes.name";
            List<object[]> data = DatabaseConnection.ExecuteReader(query);

            foreach (var row in data)
            {
                values.Add(Convert.ToInt32(row[0]));
                titles.Add(row[1].ToString());
            }
            Diagram form = new Diagram(titles.ToArray(), values.ToArray());
            form.Show();
        }

        private void searchDate_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker picker = (DateTimePicker)sender;
            if (picker.Value < dateTimePicker1.Value || picker.Value > DateTime.Now)
            {
                Alert.ShowWarning("Некорректно задана дата!");
                picker.Value = DateTime.Now;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker picker = (DateTimePicker)sender;
            if (picker.Value > DateTime.Now)
            {
                Alert.ShowWarning("Некорректно задана дата!");
                picker.Value = DateTime.Now;
            }
        }
    }
}
