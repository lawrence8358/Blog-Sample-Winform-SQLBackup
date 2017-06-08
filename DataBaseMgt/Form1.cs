using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataBaseMgt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DbBackUp FORM = new DbBackUp();
            FORM.StartPosition = FormStartPosition.CenterScreen;
            FORM.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DbRevert FORM = new DbRevert();
            FORM.StartPosition = FormStartPosition.CenterScreen;
            FORM.Show();
        }
    }
}