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
    public partial class MainForm : Form
    {
        public MainForm(string welcomeMessage)
        {
            InitializeComponent();
            message.Text = welcomeMessage;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void довідникТипиМашинToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarTypes form = new CarTypes();
            form.Show();
        }

        private void довідникКольориToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Colors form = new Colors();
            form.Show();
        }

        private void довідникДвигуниToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Engines form = new Engines();
            form.Show();
        }

        private void довідникПідприємстваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Firms form = new Firms();
            form.Show();
        }

        private void довідникТипиПальногоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FuelTypes form = new FuelTypes();
            form.Show();
        }

        private void довідникМоделіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Models form = new Models();
            form.Show();
        }

        private void документТехпаспортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TechPassport form = new TechPassport();
            form.Show();
        }

        private void документАктПриняттяОсновнихЗасобівToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Act form = new Act();
            form.Show();
        }
    }
}
