using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace curs_work
{
    public partial class Act : Form
    {
        private string sql = "";

        /*
         
SELECT Firms.name AS 'Назва підприємства', Firms.edrpou_code AS 'ЄДРПОУ', doc.number as 'Номер документу', doc.issue_date AS 'Дата',
doc.user_id as 'Код особи', Operations.id as 'Код операції', doc.sender_id as 'Здавач', doc.receiver_id as 'Одержувач', doc.debit_bill as 'Дебет/Рахунок',
doc.debit_code as 'Дебет/Код обліку', doc.credit_bill as 'Кредит/Рахунок', doc.credit_code as 'Кредит/Код обліку', doc.primary_cost as 'Первісна вартість',
TechPassports.cypher as 'Інвентарний шифр', TechPassports.factory_cypher as 'Заводський шифр', doc.object_code as 'Код об’єкту', doc.norm_code as 'Код відрахувань',
doc.full_recover as 'Норма повного відновлення', doc.full_repair as 'Норми на кап. ремонт', doc.coefficient as 'Поправочний коефіцієнт', doc.equip_type as 'Тип устаткування',
doc.equip_code as 'Код устаткування', doc.wearout_sum as 'Сума зносу', TechPassports.release_year as 'Рік випуску', doc.expoit_date as 'Початок експлуатації',
TechPassports.number as 'Номер паспорту', Users.position as 'Розпорядження від',  doc.order_date as 'Дата розпорядження', doc.order_number as 'Номер розпорядження',
doc.object_place as 'Місце об’єкту', CarTypes.name as 'Найменування об’єкту', Firms.name as 'передається від',  doc.description as 'Хар-ка об’єкта',
doc.spec_meet as 'Відповідність тех. умовам', doc.need_refine as 'Доробка', doc.results as 'Підсумки іспитів об’єкта', doc.conclusion as 'Висновок комісії',
doc.spec_list as 'перелік тех. інформації', (SELECT SUBSTRING(Users.first_name, 1, 1)+'. '+SUBSTRING(Users.middle_name, 1, 1) +'. '+Users.last_name as comm_head_name FROM Users 
WHERE Users.id = doc.comm_head_id) as 'Голова комісії', (SELECT Users.position FROM Users WHERE Users.id = doc.comm_head_id) as 'Посада голови', 
(SELECT SUBSTRING(Users.first_name, 1, 1)+'. '+SUBSTRING(Users.middle_name, 1, 1) +'. '+Users.last_name as first_mem_name FROM Users 
WHERE Users.id = doc.first_member_id) as 'Член комісії 1',
(SELECT Users.position FROM Users WHERE Users.id = doc.first_member_id) as 'Посада члена комісії 1', 
(SELECT SUBSTRING(Users.first_name, 1, 1)+'. '+SUBSTRING(Users.middle_name, 1, 1) +'. '+Users.last_name as second_mem_name FROM Users
 WHERE Users.id = doc.second_member_id) as 'Член комісії 2',
 (SELECT Users.position FROM Users WHERE Users.id = doc.second_member_id) as 'Посада члена комісії 2', 
 (SELECT SUBSTRING(Users.first_name, 1, 1)+'. '+SUBSTRING(Users.middle_name, 1, 1) +'. '+Users.last_name as second_mem_name FROM Users
 WHERE Users.id = doc.accepted_id) as 'Прийняв',
  (SELECT Users.position FROM Users WHERE Users.id = doc.accepted_id) as 'Посада (прийняв)', 
 (SELECT SUBSTRING(Users.first_name, 1, 1)+'. '+SUBSTRING(Users.middle_name, 1, 1) +'. '+Users.last_name as second_mem_name FROM Users
 WHERE Users.id = doc.handover_id) as 'Здав',
 (SELECT Users.position FROM Users WHERE Users.id = doc.handover_id) as 'Посада (здав)'
FROM AcceptAct as doc
INNER JOIN Firms ON Firms.id = doc.firm_id
INNER JOIN Operations ON Operations.id = doc.operation_id
INNER JOIN TechPassports ON TechPassports.id = doc.tech_passport_id
INNER JOIN CarTypes ON CarTypes.id = TechPassports.car_type_id
INNER JOIN Users ON Users.id = doc.user_id
        */
        public Act()
        {
            InitializeComponent();
        }

        private void Act_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "carAccountDataSet.AcceptanceAct". При необходимости она может быть перемещена или удалена.
            this.acceptanceActTableAdapter.Fill(this.carAccountDataSet.AcceptanceAct);

        }
    }
}
