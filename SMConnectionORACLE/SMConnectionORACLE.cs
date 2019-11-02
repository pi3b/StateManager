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
            Cmd.CommandType = CommandType.Text;
            OracleDataReader Reader = null;
            try
            {
                Reader = Cmd.ExecuteReader();
            }
            catch (Exception E)
            {
                if (!E.Message.Contains("命令未正确结束"))
                {
                    DisConnect();
                }
                throw;
            }
            return Reader;
            //}
        }
        public int ReadFirstInt(string Sql)
        {
            OracleDataReader Reader = ReadReader(Sql);
            int result = 0;
            if (Reader.Read())
            {
                result = Convert.ToInt32(Reader[0].ToString());
            }
            Reader.Close();
            return result;
        }
        public string ReadFirstStr(string Sql)
        {
            OracleDataReader Reader = ReadReader(Sql);
            string result = null;
            if (Reader.Read())
            {
                result = Reader[0].ToString();
            }
            Reader.Close();
            return result;
        }
        public DateTime ReadFirstDateTime(string Sql)
        {
            OracleDataReader Reader = ReadReader(Sql);
            DateTime result;
            if (Reader.Read())
            {
                result = (DateTime)Reader[0];
                Reader.Close();
                return result;
            }
            else
            {
                Reader.Close();
                throw new Exception("没有返回值");
            }
        }
        public int Execute(string Sql)
        {
            if (!Connected) throw new Exception("ORACLE数据库未连接");
            OracleCommand Cmd = new OracleCommand(Sql, Con);
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
        public void DataTableUpdate(object sda, DataTable dt)
        {
            if (!Connected) throw new Exception("ORACLE数据库未连接");
            OracleCommandBuilder SCB = new OracleCommandBuilder(sda as OracleDataAdapter);
            (sda as OracleDataAdapter).Update(dt);
        }
        public void GetDataTableStatic(ref OracleDataAdapter sda, ref DataTable dt, string Sql)
        {
            if (!Connected) throw new Exception("ORACLE数据库未连接");
            try
            {
                sda.SelectCommand = new OracleCommand(Sql, Con);
                sda.Fill(dt);
            }
            catch
            {
                DisConnect();
                throw;
            }
            //SqlCommand command = new SqlCommand("select * from product", DBService.Conn)
            //SqlDataReader dr = command.ExecuteReader();
            //BindingSource bs = new BindingSource();
            //bs.DataSource = dr;
            //this.dataGridView1.DataSource = bs;  
        }


    }
}



