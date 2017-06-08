using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;//�ɮ�

namespace DataBaseMgt
{
    public partial class DbBackUp : Form
    {
        public DbBackUp()
        {
            InitializeComponent();
        }

        //��ܸ��|
        private void btnSel_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            txtDSPath.Text = folderBrowserDialog.SelectedPath.ToString().Trim() + "\\";
        }

        //��Ƴƥ�
        private void btnDStore_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(txtDSPath.Text.Trim() + ".bak"))
                {
                    MessageBox.Show("���ɮפw�g�s�b�T", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDSPath.Text = "";
                    txtDSPath.Focus();
                }
                else
                {
                    //�إߧ���ƥ�
                    //string strSQL = "backup database MMS to disk='" + txtDSPath.Text.Trim() + "MMS.full' " + "with format";
                    string strSQL = "backup database MMS to disk='" + txtDSPath.Text.Trim() + ".bak'";
                    Class_SqlClient UseSQL = new Class_SqlClient(); //�إ�sql�s������
                    UseSQL.Edit_Data(strSQL);
                    MessageBox.Show("�ƾڳƥ����\�T", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
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