using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;//檔案

namespace DataBaseMgt
{
    public partial class DbBackUp : Form
    {
        public DbBackUp()
        {
            InitializeComponent();
        }

        //選擇路徑
        private void btnSel_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            txtDSPath.Text = folderBrowserDialog.SelectedPath.ToString().Trim() + "\\";
        }

        //資料備份
        private void btnDStore_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(txtDSPath.Text.Trim() + ".bak"))
                {
                    MessageBox.Show("該檔案已經存在﹗", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDSPath.Text = "";
                    txtDSPath.Focus();
                }
                else
                {
                    //建立完整備份
                    //string strSQL = "backup database MMS to disk='" + txtDSPath.Text.Trim() + "MMS.full' " + "with format";
                    string strSQL = "backup database MMS to disk='" + txtDSPath.Text.Trim() + ".bak'";
                    Class_SqlClient UseSQL = new Class_SqlClient(); //建立sql連接元件
                    UseSQL.Edit_Data(strSQL);
                    MessageBox.Show("數據備份成功﹗", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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