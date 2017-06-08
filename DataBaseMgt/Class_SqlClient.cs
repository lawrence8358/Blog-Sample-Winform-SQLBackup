using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;//�s�W�R�W�Ŷ� for SQL Server

namespace DataBaseMgt
{
    class Class_SqlClient
    {       
        //�ŧi��Ʈw�s���r��
        string ConnString = "server=localhost;database=MMS;uid=sa;pwd=123456789";
        SqlConnection conn;
        SqlCommand cmd;
        string errorMsg;

        #region "�s�W�B�R���B�ק��ƪ����"
        /// <summary>
        /// �s�W�B�R���B�ק��ƪ����
        /// </summary>
        /// <param name="strSQL">SQL�y�k</param>
        /// <returns>�g�J��ƫ᪽������</returns>
        public bool Edit_Data(string strSQL)
        {
            int i = 0;
            /*
            SqlConnection Conn = new SqlConnection(ConnString);
            Conn.Open();

            SqlCommand cmd = new SqlCommand(SQLcmd, Conn);
             */
            try
            {
                cmd = SqlCmdString(strSQL);//������W���T�y�ŧi
                i = cmd.ExecuteNonQuery();//�Y�S�������ƶi�沧��,�h�|�^��0
                cmd.Dispose();
                return (i == 1 ? true : false);

                /*if (i == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }*/
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }
            finally
            {
                //cmd.Dispose();
                conn.Close();
            }
        }
        #endregion

        #region"SqlConnection�A�}�Ҹ�Ʈw�s��"
        /// <summary>
        /// �}�Ҹ�Ʈw�s��
        /// </summary>
        public void GetConn()
        {
            conn = new SqlConnection(ConnString);
            conn.Open();
        }
        #endregion

        #region"SqlCommand�A���ƨӷ�����sql�R�O"
        /// <summary>
        /// ���SqlCommand����cmd
        /// </summary>
        /// <param name="strSQL">SQL�y�k</param>
        /// <returns></returns>
        public SqlCommand SqlCmdString(string strSQL)
        {
            GetConn();
            cmd = new SqlCommand(strSQL, conn);
            return cmd;
        }
        #endregion
    }
}
