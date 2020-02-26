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

        public override void DoConnect(string UsedConnectionStr)
        {
            try
            {
                if(Con.State != ConnectionState.Closed)
                    Con.Close();
                Con.ConnectionString = UsedConnectionStr;  // "server=127.0.0.1;database=User;uid=sa;pwd=123";
                //Con.ConnectionTimeout = ConnectTimeOut;//只读，在连接字符串中定义
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

        public SqlDataReader ReadReader(string Sql)
        {
            if (!Connected) throw new Exception("SQL Server数据库未连接");
            //lock (ReadLock)
            //{
            SqlCommand Cmd = new SqlCommand(Sql, Con); 
            Cmd.CommandType = CommandType.Text;
            try
            {
                return Cmd.ExecuteReader();
            }
            catch (Exception E)
            {
                if (!E.Message.Contains("命令未正确结束"))
                {
                    DisConnect();
                }
                throw;
            }
            //}
        }
        public int ReadFirstInt(string Sql)
        {
            SqlDataReader Reader = ReadReader(Sql);
            if (Reader.Read())
            {
                int V = Convert.ToInt32(Reader[0].ToString());
                Reader.Close();
                return V;
            }
            Reader.Close();
            throw new Exception("没有记录");
        }
        public string ReadFirstStr(string Sql)
        {
            SqlDataReader Reader = ReadReader(Sql);
            string result = null;
            if (Reader.Read())
            {
                string V = Reader[0].ToString();
                Reader.Close();
                result = V;
            }
            Reader.Close();
            return result;
        }
        public DateTime ReadFirstDateTime(string Sql)
        {
            SqlDataReader Reader = ReadReader(Sql);
            if (Reader.Read())
            {
                DateTime D = (DateTime)Reader[0];
                Reader.Close();
                return D;
            }
            Reader.Close();
            throw new Exception("没有记录");
        }

        public int Execute(string Sql)
        {
            if (!Connected) throw new Exception("SQL Server数据库未连接");
            SqlCommand Cmd = new SqlCommand(Sql, Con);
            try
            {
                return Cmd.ExecuteNonQuery();
            }
            catch
            {
                DisConnect();
                throw;
            }
        }

        /// <summary>界面(表）修改后更新到数据库
        /// 
        /// </summary>
        /// <param name="sda"></param>
        /// <param name="dt"></param>
        public void DataTableUpdate(object sda, DataTable dt)
        {
            if (!Connected) throw new Exception("SQL Server数据库未连接");
            //SqlCommandBuilder SCB = new SqlCommandBuilder(sda as SqlDataAdapter);
            (sda as SqlDataAdapter).Update(dt);
        }
        /// <summary>获得表数据,界面可以直接关联到表
        /// 
        /// </summary>
        /// <param name="sda"></param>
        /// <param name="dt"></param>
        /// <param name="Sql"></param>
        public void GetDataTableStatic(ref object sda, ref DataTable dt, string Sql)
        {
            if (!Connected) throw new Exception("SQL Server数据库未连接");
            try
            {
                if (sda == null)
                {
                    sda = new SqlDataAdapter();
                }
                if (dt == null)
                {
                    dt = new DataTable();
                }
                (sda as SqlDataAdapter).SelectCommand = new SqlCommand(Sql, Con);
                dt.Clear();
                (sda as SqlDataAdapter).Fill(dt);
            }
            catch
            {
                DisConnect();
                throw;
            }
        }

        /// <summary>事务中执行多行语句
        /// </summary>
        /// <param name="commands">事务中要执行的所有语句</param>
        /// <returns>事务是否成功执行</returns>
        public void ExecuteCmdsByTrans(List<string> commands)
        {
            using (SqlTransaction transaction = Con.BeginTransaction())
            {
                try
                {
                    foreach (string commandstr in commands)
                    {
                        SqlCommand command = new SqlCommand(commandstr, Con);
                        command.Transaction = transaction;
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    return;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        
        public override object Form
        {
            get { return null; }
        }
    }
}



