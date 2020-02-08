using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using Newtonsoft.Json;

namespace StateManager
{
    public class AlarmManager:IPlugIn
    {
        public SqliteFileDB DB;
        AlarmReplyForm AlarmReplyForm;
        public AlarmManager()
        {
        }
        public string ReadAlarmAsk(string ID)
        {
            return DB.ReadFirstStr(string.Format("SELECT ASK FROM ALARM WHERE ID='{0}';", ID));
        }
        public void SetAlarmReply(string ID, string REPLY)
        {
            DB.Excute(string.Format("UPDATE ALARM SET REPLY='{0}',REPLYTIME=DATETIME() WHERE ID={1};", REPLY, ID));
        }
        public void DeleteAlarm(string ID)
        {
            DB.Excute(string.Format("DELETE FROM ALARM WHERE ID={0};", ID));
        }
        public void ShowReSolveFrom(string ID)
        {
            string SONAME = "", MSG = "", ASK = "",ASKTIME="", REPLY = "";
            SQLiteDataReader Reader = DB.ReadReader(string.Format("SELECT SONAME,MSG,ASK,ASKTIME,REPLY,REPLYTIME FROM ALARM WHERE ID={0}", ID));
            if (Reader.Read())
            {
                SONAME = Reader["SONAME"].ToString();
                MSG = Reader["MSG"].ToString();
                ASK = Reader["ASK"].ToString();
                ASKTIME = Reader["ASKTIME"].ToString();
                REPLY = Reader["REPLY"].ToString();
            }
            Reader.Close();
            AlarmReplyForm.SetData(SONAME, MSG, ASK,ASKTIME, REPLY);
            if (AlarmReplyForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                REPLY = AlarmReplyForm.Result;
                SetAlarmReply(ID, REPLY);
            }
        }

        //后台使用
        public void AddAlarm(string SONAME, string Msg, string Ask)
        {
            DeActiveAlarm(SONAME);
            DB.Excute(string.Format("INSERT INTO ALARM(SONAME,MSG,ASK,ASKTIME) VALUES('{0}','{1}','{2}',DATETIME())",
                SONAME, Msg, Ask));
        }
        public string ReadAlarmReply(string SONAME)
        {
            return DB.ReadFirstStr(string.Format("SELECT REPLY FROM ALARM WHERE SONAME='{0}' AND ACTIVE=1 ORDER BY ID DESC;", SONAME));
        }
        public string DeActiveAlarm(string SONAME)
        {
            return DB.ReadFirstStr(string.Format("UPDATE ALARM SET ACTIVE=0 WHERE SONAME='{0}';", SONAME));
        }

        public string DisplayName
        {
            get { return "报警列表"; }
        }

        public void FInit()
        {
            throw new NotImplementedException();
        }

        public void Init(Newtonsoft.Json.Linq.JObject jo, SManager SManager)
        {
            this.DB = DB;
            AlarmReplyForm = new AlarmReplyForm();
        }

        public System.Windows.Forms.Form PlugInForm
        {
            get { throw new NotImplementedException(); }
        }
    }
}
