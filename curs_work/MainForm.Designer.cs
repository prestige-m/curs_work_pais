namespace curs_work
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.message = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.довідникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.довідникТипиМашинToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.довідникКольориToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.довідникДвигуниToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.довідникПідприємстваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.довідникТипиПальногоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.довідникМоделіToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вхіднаІнформаціяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документТехпаспортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документАктПриняттяОсновнихЗасобівToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userMgmtItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Font = new System.Drawing.Font("Georgia", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.message.Location = new System.Drawing.Point(14, 263);
            this.message.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(62, 24);
            this.message.TabIndex = 0;
            this.message.Text = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Georgia", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.довідникиToolStripMenuItem,
            this.вхіднаІнформаціяToolStripMenuItem,
            this.outputMenuItem,
            this.userMgmtItem,
            this.exitMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(653, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // довідникиToolStripMenuItem
            // 
            this.довідникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.довідникТипиМашинToolStripMenuItem,
            this.довідникКольориToolStripMenuItem,
            this.довідникДвигуниToolStripMenuItem,
            this.довідникПідприємстваToolStripMenuItem,
            this.довідникТипиПальногоToolStripMenuItem,
            this.довідникМоделіToolStripMenuItem});
            this.довідникиToolStripMenuItem.Name = "довідникиToolStripMenuItem";
            this.довідникиToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.довідникиToolStripMenuItem.Text = "Довідники";
            // 
            // довідникТипиМашинToolStripMenuItem
            // 
            this.довідникТипиМашинToolStripMenuItem.Name = "довідникТипиМашинToolStripMenuItem";
            this.довідникТипиМашинToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.довідникТипиМашинToolStripMenuItem.Text = "Довідник \"Типи машин\"";
            this.довідникТипиМашинToolStripMenuItem.Click += new System.EventHandler(this.довідникТипиМашинToolStripMenuItem_Click);
            // 
            // довідникКольориToolStripMenuItem
            // 
            this.довідникКольориToolStripMenuItem.Name = "довідникКольориToolStripMenuItem";
            this.довідникКольориToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.довідникКольориToolStripMenuItem.Text = "Довідник \"Кольори\"";
            this.довідникКольориToolStripMenuItem.Click += new System.EventHandler(this.довідникКольориToolStripMenuItem_Click);
            // 
            // довідникДвигуниToolStripMenuItem
            // 
            this.довідникДвигуниToolStripMenuItem.Name = "довідникДвигуниToolStripMenuItem";
            this.довідникДвигуниToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.довідникДвигуниToolStripMenuItem.Text = "Довідник \"Двигуни\"";
            this.довідникДвигуниToolStripMenuItem.Click += new System.EventHandler(this.довідникДвигуниToolStripMenuItem_Click);
            // 
            // довідникПідприємстваToolStripMenuItem
            // 
            this.довідникПідприємстваToolStripMenuItem.Name = "довідникПідприємстваToolStripMenuItem";
            this.довідникПідприємстваToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.довідникПідприємстваToolStripMenuItem.Text = "Довідник \"Підприємства\"";
            this.довідникПідприємстваToolStripMenuItem.Click += new System.EventHandler(this.довідникПідприємстваToolStripMenuItem_Click);
            // 
            // довідникТипиПальногоToolStripMenuItem
            // 
            this.довідникТипиПальногоToolStripMenuItem.Name = "довідникТипиПальногоToolStripMenuItem";
            this.довідникТипиПальногоToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.довідникТипиПальногоToolStripMenuItem.Text = "Довідник \"Типи пального\"";
            this.довідникТипиПальногоToolStripMenuItem.Click += new System.EventHandler(this.довідникТипиПальногоToolStripMenuItem_Click);
            // 
            // довідникМоделіToolStripMenuItem
            // 
            this.довідникМоделіToolStripMenuItem.Name = "довідникМоделіToolStripMenuItem";
            this.довідникМоделіToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.довідникМоделіToolStripMenuItem.Text = "Довідник \"Моделі\"";
            this.довідникМоделіToolStripMenuItem.Click += new System.EventHandler(this.довідникМоделіToolStripMenuItem_Click);
            // 
            // вхіднаІнформаціяToolStripMenuItem
            // 
            this.вхіднаІнформаціяToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.документТехпаспортToolStripMenuItem,
            this.документАктПриняттяОсновнихЗасобівToolStripMenuItem});
            this.вхіднаІнформаціяToolStripMenuItem.Name = "вхіднаІнформаціяToolStripMenuItem";
            this.вхіднаІнформаціяToolStripMenuItem.Size = new System.Drawing.Size(136, 20);
            this.вхіднаІнформаціяToolStripMenuItem.Text = "Вхідна інформація";
            // 
            // документТехпаспортToolStripMenuItem
            // 
            this.документТехпаспортToolStripMenuItem.Name = "документТехпаспортToolStripMenuItem";
            this.документТехпаспортToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
            this.документТехпаспортToolStripMenuItem.Text = "Документ \"Техпаспорт\"";
            this.документТехпаспортToolStripMenuItem.Click += new System.EventHandler(this.документТехпаспортToolStripMenuItem_Click);
            // 
            // документАктПриняттяОсновнихЗасобівToolStripMenuItem
            // 
            this.документАктПриняттяОсновнихЗасобівToolStripMenuItem.Name = "документАктПриняттяОсновнихЗасобівToolStripMenuItem";
            this.документАктПриняттяОсновнихЗасобівToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
            this.документАктПриняттяОсновнихЗасобівToolStripMenuItem.Text = "Документ \"Акт приняття основних засобів\"";
            this.документАктПриняттяОсновнихЗасобівToolStripMenuItem.Click += new System.EventHandler(this.документАктПриняттяОсновнихЗасобівToolStripMenuItem_Click);
            // 
            // outputMenuItem
            // 
            this.outputMenuItem.Name = "outputMenuItem";
            this.outputMenuItem.Size = new System.Drawing.Size(144, 20);
            this.outputMenuItem.Text = "Вихідна інформація";
            this.outputMenuItem.Click += new System.EventHandler(this.outputMenuItem_Click);
            // 
            // userMgmtItem
            // 
            this.userMgmtItem.Name = "userMgmtItem";
            this.userMgmtItem.Size = new System.Drawing.Size(184, 20);
            this.userMgmtItem.Text = "Керування користувачами";
            this.userMgmtItem.Click += new System.EventHandler(this.userMgmtItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(54, 20);
            this.exitMenuItem.Text = "Вихід";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(73, 109);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(529, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Облік прийнятих транспортних засобів на підприємстві";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 308);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.message);
            this.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Головна форма";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label message;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem довідникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem довідникТипиМашинToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem довідникКольориToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem довідникДвигуниToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem довідникПідприємстваToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem довідникТипиПальногоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem довідникМоделіToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вхіднаІнформаціяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem документТехпаспортToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem документАктПриняттяОсновнихЗасобівToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem userMgmtItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
    }
}