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
    public partial class docForm : Form
    {
        string firmName = "МП \"Сигма\"";
        Graphics graph = null;
        Brush brush = Brushes.Red;
        Font font = new Font("Times New Roman", 10.1f, FontStyle.Regular);
        Font boldFont = new Font("Times New Roman", 10f, FontStyle.Bold);
        Font boldTitle = new Font("Times New Roman", 9f, FontStyle.Bold);
        Font small = new Font("Times New Roman", 8.5f, FontStyle.Regular);
        

        public docForm()
        {
            InitializeComponent();
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
                "Номер пас-\nпорта"
            };

            //graph.FillRectangle(Brushes.White, new Rectangle(14, 178, 137, 122));
            //graph.FillRectangle(Brushes.White, new Rectangle(934, 150, 56, 149));
            //graph.FillRectangle(Brushes.White, new Rectangle(324, 150, 62, 149));
            //graph.FillRectangle(Brushes.White, new Rectangle(709, 150, 51, 149));
            //graph.FillRectangle(Brushes.White, new Rectangle(859, 150, 72, 149));
            //graph.FillRectangle(Brushes.White, new Rectangle(859, 150, 72, 149));
            //graph.FillRectangle(Brushes.White, new Rectangle(992, 150, 56, 149));
            //graph.FillRectangle(Brushes.White, new Rectangle(1051, 150, 41, 149));


            graph.DrawString(firmName, boldFont, brush, new PointF(50, 24));
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
        }


        private void docForm_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = $"X = {e.X}; Y = {e.Y}";
        }
    }
}
