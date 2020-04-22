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
        sign_in parent = null;
        public MainForm(string welcomeMessage, string login, sign_in parent)
        {
            InitializeComponent();
            message.Text = welcomeMessage;
            bool isAdmin = login.Split('@')[0] == "admin";
            userMgmtItem.Visible = isAdmin;
            this.parent = parent;
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

        private void userMgmtItem_Click(object sender, EventArgs e)
        {
            Users form = new Users();
            form.Show();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            parent.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Close();
        }

        private void outputMenuItem_Click(object sender, EventArgs e)
        {
            OutForm form = new OutForm();
            form.Show();
        }
    }
}
