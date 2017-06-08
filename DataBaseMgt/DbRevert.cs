using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataBaseMgt
{
    public partial class DbRevert : Form
    {
        public DbRevert()
        {
            InitializeComponent();
        }

        //�n�}�Ҫ��ɮ�
        private void btnSel_Click(object sender, EventArgs e)
        {
            //�w�]�}�Ҹ��|
            openFileDialog.InitialDirectory = Application.StartupPath + "\\";
            //�ɮ�����
            openFileDialog.Filter = "bak files (*.bak)|*.bak";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.ShowDialog();
            txtDRPath.Text = openFileDialog.FileName.ToString().Trim();
        }

        //����٭�
        private void btnDRevert_Click(object sender, EventArgs e)
        {
            try
            {
                string strSQL = "use master restore database MMS from disk='" + txtDRPath.Text.Trim() + "'WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 10, restricted_user";
                Class_SqlClient UseSQL = new Class_SqlClient(); //�إ�sql�s������
                if (UseSQL.Edit_Data(strSQL))
                {
                    MessageBox.Show("�ƾ��٭즨�\�T", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("�ƾ��٭쥢�ѡA�ثe��Ʈw���b�ϥΤ��T", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //�h�X
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}