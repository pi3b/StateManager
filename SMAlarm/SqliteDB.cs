using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SQLite;
using System.Data.SQLite.Generic;

namespace StateManager
{
    public class SqliteFileDB
    {
        public SQLiteConnection Con = new SQLiteConnection();
        string filepath;
        public void Connect(string path)
        {
            try
            {
                filepath = path;
                Con.ConnectionString = string.Format("Data Source={0};Version=3;", path);//Password=123123123;
                //Con.SetPassword("SManager");
                Con.Open();
            }
            catch (Exception E)
            {
                Debug.WriteLine(E.Message);
                throw;
            }
        }
        public void ReConnect()
        {
            Con.Close();
            Connect(filepath);
        }
        public bool Connected
        {
            get{
                return Con.State != ConnectionState.Closed;
            }
        }
        public void DidyDB()
        {
            SQLiteCommand sqlCom = Con.CreateCommand();
            sqlCom.CommandText = "VACUUM";
            sqlCom.ExecuteNonQuery();
        }
        public SQLiteDataReader ReadReader(string Sql)
        {
            SQLiteCommand Cmd = new SQLiteCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = Sql;
            Cmd.CommandType = CommandType.Text;
            SQLiteDataReader Reader= Cmd.ExecuteReader();
            return Reader;
        }
        public dynamic ReadFirstValue(string Sql)
        {
            SQLiteDataReader Reader = ReadReader(Sql);
            if (Reader.Read())
            {
                dynamic v = Reader[0];
                Reader.Close();
                return v;
            }
            Reader.Close();
            return null;
        }
        public void GetDataTableStatic(ref object sda, ref DataTable dt, string Sql)
        {
            if (!Connected) throw new Exception("sqlite数据库未连接");
            try
            {
                if(sda==null)
                { 
                    sda=new SQLiteDataAdapter();
                }
                if(dt==null)
                {
                    dt=new DataTable();
                }
                (sda as SQLiteDataAdapter).SelectCommand = new SQLiteCommand(Sql, Con);
                dt.Clear();
                (sda as SQLiteDataAdapter).Fill(dt);
            }
            catch
            {
                ReConnect();
                throw;
            }
        }
        public void Excute(string Sql)
        {
            SQLiteCommand Cmd = new SQLiteCommand(Sql,Con);
            Cmd.ExecuteNonQuery();
        }
        public void DataTableUpdate(object sda, DataTable dt)
        {
            if (!Connected) throw new Exception("sqlite数据库未连接");
            //SQLiteCommandBuilder SCB = new SQLiteCommandBuilder(sda as SQLiteDataAdapter);
            (sda as SQLiteDataAdapter).Update(dt);
        }

    }
}
