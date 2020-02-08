using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

using Oracle;
using Oracle.ManagedDataAccess.Client;

using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
 
namespace StateManager
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public class SMConnectionORACLE : SMConnection
    {
        OracleConnection Con;
        public override void DoCreateConObj(string UsedConnectionStr)
        {
            Con = new OracleConnection();
        }

        public override void DoConnect(string UsedConnectionStr, int ConnectTimeOutMiliSecs = 1000, int ReadTimeOutMiliSecs = 3000)
        {
            try
            {
                if(Con.State != ConnectionState.Closed)
                    Con.Close();

                Con.ConnectionString = UsedConnectionStr;  // Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.1.11)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=test)));Persist Security Info=True;User ID=sa;Password=123456;Connection Timeout=2;
                
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

        public OracleDataReader ReadReader(string Sql)
        {
            if (!Connected) throw new Exception("ORACLE数据库未连接");
            //lock (ReadLock)
            //{
            OracleCommand Cmd = new OracleCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = Sql;
            Cmd.CommandType = System.Data.CommandType.Text;
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
            OracleDataReader Reader = ReadReader(Sql);
            if (Reader.Read())
            {
                Reader.Close();
                return Convert.ToInt32(Reader[0].ToString());
            }
            Reader.Close();
            throw new Exception("没有记录");
        }
        public string ReadFirstStr(string Sql)
        {
            OracleDataReader Reader = ReadReader(Sql);
            string result = null;
            if (Reader.Read())
            {
                Reader.Close();
                result = Reader[0].ToString();
            }
            Reader.Close();
            return result;
        }
        public DateTime ReadFirstDateTime(string Sql)
        {
            OracleDataReader Reader = ReadReader(Sql);
            if (Reader.Read())
            {
                Reader.Close();
                return (DateTime)Reader[0];
            }
            Reader.Close();
            throw new Exception("没有记录");
        }

        public int Execute(string Sql)
        {
            if (!Connected) throw new Exception("ORACLE数据库未连接");
            OracleCommand Cmd = new OracleCommand(Sql, Con);
            Cmd.CommandType = System.Data.CommandType.Text;
            //Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //Cmd.Parameters.Add("xxx", xxx);//函数的参数
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
            if (!Connected) throw new Exception("ORACLE数据库未连接");
            OracleCommandBuilder SCB = new OracleCommandBuilder(sda as OracleDataAdapter);
            (sda as OracleDataAdapter).Update(dt);
        }
        /// <summary>获得表数据,界面可以直接关联到表
        /// 
        /// </summary>
        /// <param name="sda"></param>
        /// <param name="dt"></param>
        /// <param name="Sql"></param>
        public void GetDataTableStatic(ref object sda, ref DataTable dt, string Sql)
        {
            if (!Connected) throw new Exception("ORACLE数据库未连接");
            try
            {
                if(sda==null)
                {
                    sda = new OracleDataAdapter();
                }
                if(dt==null)
                {
                    dt=new DataTable();
                }
                (sda as OracleDataAdapter).SelectCommand = new OracleCommand(Sql, Con);
                dt.Clear();
                (sda as OracleDataAdapter).Fill(dt);
            }
            catch
            {
                DisConnect();
                throw;
            }
            //方法2，通过Reader
            //SqlCommand command = new SqlCommand("select * from product", DBService.Conn)
            //SqlDataReader dr = command.ExecuteReader();
            //BindingSource bs = new BindingSource();
            //bs.DataSource = dr;
            //this.dataGridView1.DataSource = bs;  
        }

        public override object Form
        {
            get { return null; }
        }
    }
}



