using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace curs_work
{
    public partial class docForm : Form
    {
        Graphics graph = null;
        Brush brush = Brushes.Black;
        Font font = new Font("Times New Roman", 10.1f, FontStyle.Regular);
        Font boldFont = new Font("Times New Roman", 10f, FontStyle.Bold);
        Font boldTitle = new Font("Times New Roman", 9f, FontStyle.Bold);
        Font small = new Font("Times New Roman", 8.5f, FontStyle.Regular);
        Font textFont = new Font("Times New Roman", 10f, FontStyle.Bold | FontStyle.Italic);


        string firmName = "МП \"Сигма\"";
        int edrpou = 12345678;
        int docNumber = 7;
        DateTime docDate = DateTime.Now;
        int userId = 1;
        int operationId = 2;
        string senderName = "МП \"Альфа\"";
        string receiverName = "Будівельна ділянка №2";
        int debitBill = 104;
        int debitCode = 4;
        int creditBill = 152;
        int creditCode = 1;
        decimal primary_cost = 832680.60M;
        int cypher = 1048567;
        int cypher_factory = 4879;
        int object_code = 234;
        int norm_code = 1;
        decimal full_recover = 0.125M;
        int full_repair = 0;
        double coefficient = 0.0;
        string equip_type = "Будтехніка";
        int equip_code = 274;
        decimal wearout_sum = 0.0M;
        int release_year = 2020;
        DateTime expoit_date = DateTime.Now;
        
        string tech_passport_id = "567";
        string user_position = "керівника підприємства № 132";
        DateTime order_date = DateTime.Now;

        int order_number = 1;
        string object_place = "у приміщенні будівельной ділянки №3";
        string object_name = "бетонозмішувача";
        string place = "у виробничій споруди будівельної ділянки №3";
        string description = "бетонозмішувач місткістю 3м";
        string spec_meet = "відповідає";
        string need_refine = "не потрібна";
        string results = "знаходиться в робочому стані в повній комплектації";
        string conclusion = "прийняти в експлуатацію";
        string spec_list = "технічний паспорт, інструкція по експлуатації";
        string comm_head_name = "Р.Т. Расулов";
        string comm_head_position = "головний інженер";
        string first_member_name = "І.Л.Гусєва";
        string first_member_position = "головний бухгалтер";
        string second_member_name = "Я.І. Портнов";
        string second_member_position = "механік";
        string accepted_name = "Н.Д. Абраменко";
        string accepted_position = "начальник будділянки №3";
        string handover_name = "С.Н. Матюхін";
        string handover_position = "комірник";
        int booker_id = 1;


        public docForm(string firmName, int edrpou, int docNumber, DateTime docDate, int userId, int operationId, string senderName, string receiverName, int debitBill, int debitCode, int creditBill,
                            int creditCode, decimal primary_cost, int cypher, int cypher_factory, int object_code, int norm_code,decimal full_recover, int full_repair, double coefficient, string equip_type,
                            int equip_code, decimal wearout_sum, int release_year, DateTime expoit_date, string tech_passport_id, string user_position, DateTime order_date, string object_place,
                            string description, string spec_meet, string need_refine, string results, string conclusion, string spec_list, string comm_head_name, string comm_head_position,
                            string first_member_name, string first_member_position, string second_member_name, string second_member_position, string accepted_name, string accepted_position,
                            string handover_name, string handover_position)
        {
            InitializeComponent();
            this.firmName = firmName;
            this.edrpou = edrpou;
            this.docNumber = docNumber;
            this.docDate = docDate;
            this.userId = userId;
            this.operationId = operationId;
            this.senderName = senderName;
            this.receiverName = receiverName;
            this.debitBill = debitBill;
            this.debitCode = debitCode;
            this.creditBill = creditBill;
            this.creditCode = creditCode;
            this.primary_cost = primary_cost;
            this.cypher = cypher;
            this.cypher_factory = cypher_factory;
            this.object_code = object_code;
            this.norm_code = norm_code;
            this.full_recover = full_recover;
            this.full_repair = full_repair;
            this.coefficient = coefficient;
            this.equip_type = equip_type;
            this.equip_code = equip_code;
            this.wearout_sum = wearout_sum;
            this.release_year = release_year;
            this.expoit_date = expoit_date;

            this.tech_passport_id = tech_passport_id;
            this.user_position = user_position;
            this.order_date = order_date;
            this.object_place = object_place;
            this.object_name = "бетонозмішувача";
            this.place = "";
            this.description = description;
            this.spec_meet = spec_meet;
            this.need_refine = need_refine;
            this.results = results;
            this.conclusion = conclusion;
            this.spec_list = spec_list;
            this.comm_head_name = comm_head_name;
            this.comm_head_position = comm_head_position;
            this.first_member_name = first_member_name;
            this.first_member_position = first_member_position;
            this.second_member_name = second_member_name;
            this.second_member_position = second_member_position;
            this.accepted_name = accepted_name;
            this.accepted_position = accepted_position;
            this.handover_name = handover_name;
            this.handover_position = handover_position;
            int booker_id = 1;
        }

        public void PrintForm()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintImage);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pd;

            if (printDialog.ShowDialog() == DialogResult.OK)
                printDialog.Document.Print(); 
        }

        void PrintImage(object o, PrintPageEventArgs e)
        {
            int x = SystemInformation.WorkingArea.X;
            int y = SystemInformation.WorkingArea.Y;
            int width = this.Width;
            int height = this.Height;

            Rectangle bounds = new Rectangle(x, y, width, height);

            Bitmap img = new Bitmap(width, height);

            this.DrawToBitmap(img, bounds);
            Point p = new Point(100, 100);
            e.Graphics.DrawImage(img, p);
        }

        public void DrawVertical(Pen pen, int x, int y1, int y2)
        {
            graph.DrawLine(pen, new Point(x, y1), new Point(x, y2));
        }

        public void DrawHorizontal(Pen pen, int x, int y, int x2)
        {
            graph.DrawLine(pen, new Point(x, y), new Point(x2, y));
        }

        public void DrawRectangle(Pen pen, int x, int y, int x2, int y2)
        {
            graph.DrawRectangle(pen, new Rectangle(new Point(x, y), new Size(x2 - x, y2 - y)));
        }

        public string DateToString(DateTime date)
        {
            return $"« {date.Day} » {date.Month}  {date.Year} р.";

        }

        private void docForm_Paint(object sender, PaintEventArgs e)
        {
            graph = e.Graphics;
            Pen linePen = new Pen(brush, 2);

            DrawHorizontal(linePen, 14, 39, 308);
            DrawHorizontal(linePen, 197, 68, 308);
            DrawHorizontal(linePen, 781, 67, 890);
            DrawHorizontal(linePen, 781, 81, 922);
            DrawHorizontal(linePen, 712, 95, 983);

            DrawRectangle(linePen, 595, 105, 1093, 148);
            DrawHorizontal(linePen, 595, 134, 1093);
            DrawRectangle(linePen, 13, 148, 1093, 362);
            DrawRectangle(linePen, 13, 178, 1093, 302);
            DrawHorizontal(linePen, 13, 317, 1093);
            DrawVertical(linePen, 687, 105, 147);
            DrawVertical(linePen, 782, 105, 147);
            DrawVertical(linePen, 975, 105, 147);

            DrawVertical(linePen, 78, 148, 362);
            DrawVertical(linePen, 153, 148, 362);
            DrawVertical(linePen, 195, 177, 362);
            DrawVertical(linePen, 280, 177, 362);
            DrawVertical(linePen, 451, 177, 362);
            DrawVertical(linePen, 579, 177, 362);
            DrawVertical(linePen, 664, 177, 362);
            DrawVertical(linePen, 814, 177, 362);
            DrawVertical(linePen, 238, 148, 362);
            DrawVertical(linePen, 322, 148, 362);
            DrawVertical(linePen, 322, 148, 362);
            DrawVertical(linePen, 387, 148, 362);
            DrawVertical(linePen, 504, 148, 362);
            DrawVertical(linePen, 622, 148, 362);
            DrawVertical(linePen, 707, 148, 362);
            DrawVertical(linePen, 761, 148, 362);
            DrawVertical(linePen, 857, 148, 362);
            DrawVertical(linePen, 932, 148, 362);
            DrawVertical(linePen, 991, 148, 362);
            DrawVertical(linePen, 1049, 148, 362);


            DrawHorizontal(linePen, 216, 384, 878);
            DrawHorizontal(linePen, 904, 384, 1087);
            DrawHorizontal(linePen, 21, 398, 603);
            DrawHorizontal(linePen, 719, 398, 1096);
            DrawHorizontal(linePen, 306, 424, 1100);
            DrawHorizontal(linePen, 323, 438, 1100);
            DrawHorizontal(linePen, 202, 462, 1100);
            DrawHorizontal(linePen, 313, 476, 1100);
            DrawHorizontal(linePen, 198, 502, 1100);
            DrawHorizontal(linePen, 155, 525, 582);
            DrawHorizontal(linePen, 683, 525, 1100);
            DrawHorizontal(linePen, 248, 540, 1100);

            DrawHorizontal(linePen, 140, 563, 376);
            DrawHorizontal(linePen, 493, 563, 651);
            DrawHorizontal(linePen, 760, 563, 954);
            DrawHorizontal(linePen, 140, 587, 376);
            DrawHorizontal(linePen, 493, 587, 651);
            DrawHorizontal(linePen, 760, 587, 954);
            DrawHorizontal(linePen, 140, 612, 376);
            DrawHorizontal(linePen, 493, 612, 651);
            DrawHorizontal(linePen, 760, 612, 954);
            DrawHorizontal(linePen, 140, 637, 376);
            DrawHorizontal(linePen, 493, 637, 651);
            DrawHorizontal(linePen, 760, 637, 954);
            DrawHorizontal(linePen, 255, 661, 426);
            DrawHorizontal(linePen, 493, 661, 651);
            DrawHorizontal(linePen, 760, 661, 954);
            DrawHorizontal(linePen, 255, 686, 426);
            DrawHorizontal(linePen, 493, 686, 651);
            DrawHorizontal(linePen, 760, 686, 954);
            DrawHorizontal(linePen, 449, 725, 660);

            string[] docText =
            {
                "підприємство, організація", "Ідентифікаційний код ЄДРПОУ", "Типова форма № ОЗ-1", "Затвердженна наказом мінстату України від 29.25.95р. №352",
                "Код за УКУД", "Затверджую", "АКТ\nПРИЙМАННЯ ПЕРЕДАЧІ (ВНУТРІШНЬОГО ПЕРЕМІЩЕННЯ) ОСНОВНИХ ЗАСОБІВ", "Здавач", "Одержувач", "Дебет", "Кредит", "Шифр",
                "Код", "Норми аморт-\nвідрахувань", "Устаткування", "номер\nдокумента", "дата\nскладання", "код особи, яка відповідає за\nзбереження основних засобів",
                "код виду операції", "Цех, відділ, дільниця,\nлінія", "раху-\nнок,\nсуб-\nра-\nхунок", "код\nана-\nлітич-\nного\nобліку", "Первісна\nбалан-\nсова\nвартість",
                "Інвертар-\nний", "за-\nводсь-\nкий", "рахунка та\nоб’єкта\nаналітич-\nного обліку\n(для відне-\nсення\nамортиза-\nційних від-\nрахуваннь)",
                "нор-\nми\nамор-\nтиз.\nвід-\nра-\nху-\nвань", "на\nповне\nвід-\nнов-\nлен-\nня", "на\nкап.\nремонт", "Поп-\nравоч-\nний\nкоефі-\nціент", "вид", "код", 
                "Сума\nамортиза-\nції(зносу)\nза даними\nпереоцінки\nабо за\nдокумен-\nтами\nпридбання", "Рік\nвипуску\n(побу-\nдови)", "Дата\nвведе-\nння в\nексплуа-\nтацію\n(місяць, рік)",
                "Номер пас-\nпорта", "На підставі наказу, розпорядження", "від", "у", "Проведений огляд", "що приймається (передається) в експлуатацію від", 
                "У момент приймання (передачі) об’єкт знаходится в", "Коротка характеристика об’єкта", "Об’єкт технічним умовам відповідає (не відповідає)",
                "Доробка не потрібна (потрібна)", "Підсумки іспитів об’єкта", "Висновок комісії", "Додаток.", "Перелік технічної інформації", "Голова комісії", "Члени комісії",
                "Об’єкт основних засобів прийняв", "здав", "Відмітка бухгалтерії про відкриття картки або переміщення об’єкта",
                "Головний бухгалтер (бухгалтер)"
            };

            graph.FillRectangle(Brushes.White, new Rectangle(14, 178, 137, 122));
            graph.FillRectangle(Brushes.White, new Rectangle(934, 150, 56, 149));
            graph.FillRectangle(Brushes.White, new Rectangle(324, 150, 62, 149));
            graph.FillRectangle(Brushes.White, new Rectangle(709, 150, 51, 149));
            graph.FillRectangle(Brushes.White, new Rectangle(859, 150, 72, 149));
            graph.FillRectangle(Brushes.White, new Rectangle(859, 150, 72, 149));
            graph.FillRectangle(Brushes.White, new Rectangle(992, 150, 56, 149));
            graph.FillRectangle(Brushes.White, new Rectangle(1051, 150, 41, 149));

            graph.DrawString(docText[0], small, brush, new PointF(65, 40));
            graph.DrawString(docText[1], font, brush, new PointF(12, 54));
            graph.DrawString(docText[2], boldFont, brush, new PointF(705, 25));
            graph.DrawString(docText[3], font, brush, new PointF(705, 39));
            graph.DrawString(docText[4], font, brush, new PointF(705, 53));
            graph.DrawString(docText[5], font, brush, new PointF(705, 68));


            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            graph.DrawString(docText[6], boldTitle, brush, new Rectangle(22, 70, 580, 100), stringFormat);
            graph.DrawString(docText[7], font, brush, new PointF(25, 156));
            graph.DrawString(docText[8], font, brush, new PointF(83, 156));
            graph.DrawString(docText[9], font, brush, new PointF(174, 156));
            graph.DrawString(docText[10], font, brush, new PointF(258, 156));
            graph.DrawString(docText[11], font, brush, new PointF(429, 156));
            graph.DrawString(docText[12], font, brush, new PointF(552, 156));
            graph.DrawString(docText[13], font, brush, new PointF(626, 148));
            graph.DrawString(docText[14], font, brush, new PointF(770, 156));

            graph.DrawString(docText[15], font, brush, new Rectangle(597, 108, 87, 22), stringFormat);
            graph.DrawString(docText[16], font, brush, new Rectangle(690, 108, 87, 22), stringFormat);
            graph.DrawString(docText[17], font, brush, new Rectangle(784, 108, 189, 22), stringFormat);
            graph.DrawString(docText[18], font, brush, new PointF(981, 111));
            graph.DrawString(docText[19], font, brush, new Rectangle(14, 178, 136, 121), stringFormat);
            graph.DrawString(docText[20], font, brush, new Rectangle(150, 180, 45, 121), stringFormat);
            graph.DrawString(docText[21], font, brush, new Rectangle(193, 180, 45, 121), stringFormat);
            graph.DrawString(docText[20], font, brush, new Rectangle(236, 180, 45, 121), stringFormat);
            graph.DrawString(docText[21], font, brush, new Rectangle(279, 180, 45, 121), stringFormat);

            graph.DrawString(docText[22], font, brush, new Rectangle(322, 180, 64, 121), stringFormat);
            graph.DrawString(docText[23], font, brush, new Rectangle(387, 180, 64, 121), stringFormat);
            graph.DrawString(docText[24], font, brush, new Rectangle(451, 180, 52, 121), stringFormat);
            graph.DrawString(docText[25], font, brush, new Rectangle(504, 180, 75, 121), stringFormat);
            graph.DrawString(docText[26], font, brush, new Rectangle(579, 180, 43, 121), stringFormat);
            graph.DrawString(docText[27], font, brush, new Rectangle(621, 180, 43, 121), stringFormat);
            graph.DrawString(docText[28], font, brush, new Rectangle(664, 180, 43, 121), stringFormat);
            graph.DrawString(docText[29], font, brush, new Rectangle(707, 148, 52, 151), stringFormat);
            graph.DrawString(docText[30], font, brush, new Rectangle(760, 180, 53, 121), stringFormat);
            graph.DrawString(docText[31], font, brush, new Rectangle(814, 180, 43, 121), stringFormat);

            graph.DrawString(docText[32], font, brush, new Rectangle(857, 148, 75, 151), stringFormat);
            graph.DrawString(docText[33], font, brush, new Rectangle(932, 148, 58, 151), stringFormat);
            graph.DrawString(docText[34], font, brush, new Rectangle(991, 148, 58, 151), stringFormat);
            graph.DrawString(docText[35], font, brush, new Rectangle(1049, 148, 44, 151), stringFormat);

            graph.DrawString(docText[36], font, brush, new PointF(12, 370));
            graph.DrawString(docText[37], font, brush, new PointF(877, 370));
            graph.DrawString(docText[38], font, brush, new PointF(12, 385));
            graph.DrawString(docText[39], font, brush, new PointF(604, 385));
            graph.DrawString(docText[40], font, brush, new PointF(12, 410));
            graph.DrawString(docText[41], font, brush, new PointF(12, 424));
            graph.DrawString(docText[42], font, brush, new PointF(12, 449));
            graph.DrawString(docText[43], font, brush, new PointF(12, 463));

            graph.DrawString(docText[44], font, brush, new PointF(12, 488));
            graph.DrawString(docText[45], font, brush, new PointF(12, 513));
            graph.DrawString(docText[46], font, brush, new PointF(582, 513));
            graph.DrawString(docText[47], font, brush, new PointF(12, 527));
            graph.DrawString(docText[48], font, brush, new PointF(75, 527));

            graph.DrawString(docText[49], font, brush, new PointF(54, 550));
            graph.DrawString(docText[50], font, brush, new PointF(54, 575));
            graph.DrawString(docText[51], font, brush, new PointF(54, 648));
            graph.DrawString(docText[52], font, brush, new PointF(54, 675));
            graph.DrawString(docText[53], font, brush, new PointF(54, 712));
            graph.DrawString(docText[54], font, brush, new PointF(707, 712));

            graph.DrawString("1", small, brush, new PointF(43, 302));
            graph.DrawString("2", small, brush, new PointF(112, 302));
            graph.DrawString("3", small, brush, new PointF(171, 302));
            graph.DrawString("4", small, brush, new PointF(214, 302));
            graph.DrawString("5", small, brush, new PointF(257, 302));
            graph.DrawString("6", small, brush, new PointF(300, 302));
            graph.DrawString("7", small, brush, new PointF(353, 302));
            graph.DrawString("8", small, brush, new PointF(417, 302));
            graph.DrawString("9", small, brush, new PointF(476, 302));
            graph.DrawString("10", small, brush, new PointF(538, 302));
            graph.DrawString("11", small, brush, new PointF(598, 302));
            graph.DrawString("12", small, brush, new PointF(638, 302));
            graph.DrawString("13", small, brush, new PointF(681, 302));
            graph.DrawString("14", small, brush, new PointF(730, 302));
            graph.DrawString("15", small, brush, new PointF(784, 302));
            graph.DrawString("16", small, brush, new PointF(833, 302));
            graph.DrawString("17", small, brush, new PointF(891, 302));
            graph.DrawString("18", small, brush, new PointF(958, 302));
            graph.DrawString("19", small, brush, new PointF(1017, 302));
            graph.DrawString("20", small, brush, new PointF(1067, 302));

            //fill up
            graph.DrawString(firmName, textFont, brush, new PointF(50, 24));
            graph.DrawString(edrpou.ToString(), textFont, brush, new PointF(206, 54));
            graph.DrawString(docNumber.ToString(), textFont, brush, new PointF(636, 134));
            graph.DrawString(docDate.ToShortDateString() + " р.", textFont, brush, new PointF(694, 134));
            graph.DrawString(userId.ToString(), textFont, brush, new PointF(878, 134));
            graph.DrawString(operationId.ToString(), textFont, brush, new PointF(1025, 134));
            graph.DrawString(senderName, textFont, brush, new Rectangle(15, 317, 62, 43), stringFormat);
            graph.DrawString(receiverName, textFont, brush, new Rectangle(79, 317, 75, 43), stringFormat);
            graph.DrawString(debitBill.ToString(), textFont, brush, new Rectangle(152, 315, 40, 46), stringFormat);
            graph.DrawString(debitCode.ToString(), textFont, brush, new Rectangle(194, 315, 40, 46), stringFormat);
            graph.DrawString(creditBill.ToString(), textFont, brush, new Rectangle(238, 315, 40, 46), stringFormat);
            graph.DrawString(creditCode.ToString(), textFont, brush, new Rectangle(280, 315, 40, 46), stringFormat);
            graph.DrawString(primary_cost.ToString(), textFont, brush, new Rectangle(322, 315, 65, 46), stringFormat);
            graph.DrawString(cypher.ToString(), textFont, brush, new Rectangle(385, 315, 65, 46), stringFormat);
            graph.DrawString(cypher_factory.ToString(), textFont, brush, new Rectangle(451, 315, 51, 46), stringFormat);
            graph.DrawString($"{object_code}", textFont, brush, new Rectangle(504, 315, 75, 46), stringFormat);
            graph.DrawString($"0{norm_code}", textFont, brush, new Rectangle(579, 315, 42, 46), stringFormat);

            graph.DrawString(string.Format("{0:0.00}", full_recover), textFont, brush, new Rectangle(622, 315, 42, 46), stringFormat);
            graph.DrawString($"{full_repair}", textFont, brush, new Rectangle(663, 315, 42, 46), stringFormat);
            graph.DrawString(string.Format("{0:0.0}", coefficient), textFont, brush, new Rectangle(706, 315, 54, 46), stringFormat);
            graph.DrawString($"{equip_type}", textFont, brush, new Rectangle(761, 315, 55, 46), stringFormat);
            graph.DrawString($"{equip_code}", textFont, brush, new Rectangle(814, 315, 44, 46), stringFormat);
            graph.DrawString($"{wearout_sum}", textFont, brush, new Rectangle(856, 315, 76, 46), stringFormat);
            graph.DrawString($"{release_year}", textFont, brush, new Rectangle(932, 315, 60, 46), stringFormat);
            graph.DrawString($"{expoit_date.ToShortDateString()}", textFont, brush, new Rectangle(990, 315, 60, 46), stringFormat);
            graph.DrawString($"{tech_passport_id}", textFont, brush, new Rectangle(1050, 315, 42, 46), stringFormat);

            graph.DrawString($"{user_position}", textFont, brush, new PointF(228, 368));
            graph.DrawString($"{order_date.ToShortDateString()} р.", textFont, brush, new PointF(907, 368));
            graph.DrawString($"{object_place}", textFont, brush, new PointF(41, 383));
            graph.DrawString($"{object_name}", textFont, brush, new PointF(724, 383));
            graph.DrawString($"{firmName}", textFont, brush, new PointF(327, 410));
            graph.DrawString($"{place}", textFont, brush, new PointF(349, 425));
            graph.DrawString($"{description}", textFont, brush, new PointF(215, 448));
            graph.DrawString($"{spec_meet}", textFont, brush, new PointF(373, 462));
            graph.DrawString($"{need_refine}", textFont, brush, new PointF(282, 489));
            graph.DrawString($"{results}", textFont, brush, new PointF(206, 511));
            graph.DrawString($"{conclusion}", textFont, brush, new PointF(720, 511));
            graph.DrawString($"{spec_list}", textFont, brush, new PointF(268, 526));
            graph.DrawString($"{comm_head_position}", textFont, brush, new PointF(170, 548));
            graph.DrawString($"{comm_head_name}", textFont, brush, new PointF(802, 548));
            graph.DrawString($"{first_member_position}", textFont, brush, new PointF(170, 572));
            graph.DrawString($"{first_member_name}", textFont, brush, new PointF(802, 572));
            graph.DrawString($"{second_member_position}", textFont, brush, new PointF(170, 596));
            graph.DrawString($"{second_member_name}", textFont, brush, new PointF(802, 596));
            graph.DrawString($"{accepted_position}", textFont, brush, new PointF(267, 646));
            graph.DrawString($"{accepted_name}", textFont, brush, new PointF(802, 646));
            graph.DrawString($"{handover_position}", textFont, brush, new PointF(267, 672));
            graph.DrawString($"{handover_name}", textFont, brush, new PointF(802, 672));
            graph.DrawString($"{docDate.ToShortDateString()} р.", textFont, brush, new PointF(460, 710));
        }


        private void docForm_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void docForm_Load(object sender, EventArgs e)
        {
            PrintForm();
        }
    }
}
