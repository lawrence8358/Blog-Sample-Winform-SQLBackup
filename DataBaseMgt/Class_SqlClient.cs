using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;//新增命名空間 for SQL Server

namespace DataBaseMgt
{
    class Class_SqlClient
    {       
        //宣告資料庫連接字串
        string ConnString = "server=localhost;database=MMS;uid=sa;pwd=123456789";
        SqlConnection conn;
        SqlCommand cmd;
        string errorMsg;

        #region "新增、刪除、修改資料的函數"
        /// <summary>
        /// 新增、刪除、修改資料的函數
        /// </summary>
        /// <param name="strSQL">SQL語法</param>
        /// <returns>寫入資料後直接釋放</returns>
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
                cmd = SqlCmdString(strSQL);//等價於上面三句宣告
                i = cmd.ExecuteNonQuery();//若沒有任何資料進行異動,則會回傳0
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

        #region"SqlConnection，開啟資料庫連接"
        /// <summary>
        /// 開啟資料庫連接
        /// </summary>
        public void GetConn()
        {
            conn = new SqlConnection(ConnString);
            conn.Open();
        }
        #endregion

        #region"SqlCommand，對資料來源執行sql命令"
        /// <summary>
        /// 獲取SqlCommand之值cmd
        /// </summary>
        /// <param name="strSQL">SQL語法</param>
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
