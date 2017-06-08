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

        //要開啟的檔案
        private void btnSel_Click(object sender, EventArgs e)
        {
            //預設開啟路徑
            openFileDialog.InitialDirectory = Application.StartupPath + "\\";
            //檔案類型
            openFileDialog.Filter = "bak files (*.bak)|*.bak";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.ShowDialog();
            txtDRPath.Text = openFileDialog.FileName.ToString().Trim();
        }

        //資料還原
        private void btnDRevert_Click(object sender, EventArgs e)
        {
            try
            {
                string strSQL = "use master restore database MMS from disk='" + txtDRPath.Text.Trim() + "'WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 10, restricted_user";
                Class_SqlClient UseSQL = new Class_SqlClient(); //建立sql連接元件
                if (UseSQL.Edit_Data(strSQL))
                {
                    MessageBox.Show("數據還原成功﹗", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("數據還原失敗，目前資料庫正在使用中﹗", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //退出
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}