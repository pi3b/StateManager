using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
 
namespace StateManager
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public class SMConnectionMSSQL : SMConnection
    {
        SqlConnection Con;
        public override void DoCreateConObj(string UsedConnectionStr)
        {
            Con = new SqlConnection(UsedConnectionStr);
        }

        public override void DoConnect(string UsedConnectionStr, int ConnectTimeOutMiliSecs = 1000, int ReadTimeOutMiliSecs = 3000)
        {
            try
            {
                if(Con.State != ConnectionState.Closed)
                    Con.Close();
                Con.ConnectionString = UsedConnectionStr;  // "server=127.0.0.1;database=User;uid=sa;pwd=123";
                Con.Open();
                if (Con.State != ConnectionState.Open)
                {
                    throw new Exception("连接失败。");
                }
            }
            catch
            {
                Con.Close();
                throw;
            }
        }

        public override void DoDisConnect()
        {
            Con.Close();
            if (Con.State != ConnectionState.Closed)
            {
                throw new Exception("断开失败。");
            }
        }
        

        public string Query(string SQL)
        {
            if(!Connected) return "";
            SqlCommand Cmd = new SqlCommand(SQL, Con); 
            try
            {
                string V="";
                SqlDataReader dataReader = Cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    V = (string)dataReader["value"];
                }
                dataReader.Close();
                return V;
            }
            catch
            {
                throw;
            } 
        }
        /// <summary>
        /// 查询表
        /// </summary>
        /// <param name="connectString">数据库连接字符串</param>
        /// <param name="selectstr">SQL语句</param>
        /// <returns>数据表</returns>
        public DataTable GetCommand(string connectString, string selectstr)
        {
            if(string .IsNullOrEmpty (connectString )||string .IsNullOrEmpty (selectstr ))
            {
                return null;
            }
            DataTable table = new DataTable();
 
            string err = "";
            using (SqlConnection dbc = new SqlConnection(connectString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand(selectstr, dbc);
                    adapter.Fill(table);
                }
                catch(Exception ex)
                {
                    err = ex.Message;
                }
            }
 
            if (err.Length > 0)
            {
                throw new Exception(HttpStatusCode.InternalServerError.ToString());
            }
            else
            {
                return table;
            }
        }

        /// <summary>
        /// 执行一个事务
        /// </summary>
        /// <param name="connectString">数据库连接字符串</param>
        /// <param name="commands">事务中要执行的所有语句</param>
        /// <returns>事务是否成功执行</returns>
        public bool ExecuteTransaction(string connectString,List<string> commands)
        {
            if (string.IsNullOrEmpty(connectString) || commands == null)
            {
                return false;
            }
 
            string err = "";
            bool ret = false;
            using (SqlConnection dbc = new SqlConnection(connectString))
            {
                dbc.Open();
                using (SqlTransaction transaction = dbc.BeginTransaction())
                {
                    try
                    {
                        foreach (string commandstr in commands)
                        {
                            SqlCommand command = new SqlCommand(commandstr, dbc);
                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        ret = true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        err = ex.Message;
                    }
                }
            }
 
            if (err.Length > 0)
            {
                throw new Exception(HttpStatusCode.InternalServerError.ToString());
            }
            else
            {
                return ret;
            }
        }
    }
}



