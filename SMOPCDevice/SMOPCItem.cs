using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace SMOPCDevice
{
    class SMOPCItem
    {
        public string ItemID;
        public string DeviceName;
        public string SubItemID;
        public string AddrStr;
        public VarEnum DataType;
        public bool ReadOnly;
        public object DeviceObj=null;
        public object CacheValue;
        public int PropID=0;//属性ID
        public SMOPCItem(string ItemID)
        {
            this.ItemID = ItemID;
            int pos = ItemID.IndexOf('.');
            DeviceName = ItemID.Substring(0, pos);
            SubItemID = ItemID.Substring(pos + 1);
        }
        public void ParseSubItemID()
        {
            string tmpStr = SubItemID;
            //以下是DXPlorer的规则，地址部分我们采用Hsl的规则方式，即DB1.0.01
            //DB1:0:01:V:OR   bool类型，取反，只读，改变为：DB1.0.01:V:OR            VT_BOOL
            //DB1:0:01                              改变为：DB1.0.01
            //M0:01:V:OR                            改变为：M0.01:V:OR
            //DB1:3:L:B:OR     byte类型,bcd运算，只读      改变为：DB1.3:L:B:OR      VT_I1
            //DB1:3:B:OR       Ubyte类型...（默认类型）
            //DB1:3
            //DB1:3:W:B:OR      short。。。                VT_I2
            //DB1:3:WU:B:OR      Ushort(word)。。。
            //DB1:3:D:B:OR        LONG...(INT32)            VT_I4
            //DB1:3:D
            //DB1:3:DU:B:OR       ULONG...(DWORD)
            //DB1:3:I:B:OR        longlong                  VT_I8
            //DB1:3:IU:B:OR       ulonglong
            //DB1:3:R:OR         float
            //DB1:3:DR:OR       double
            //DB1:3:OR:S1       string
            //取地址：[A-Za-z]+[0-9]+(\.[0-9]+)?(\.[0-9]+)?(?=:|$)
            //其他  :SW字节交换，:A1排列
            //解释特殊标记，并去除标记
            ReadOnly = Regex.Match(tmpStr, ":OR").Success;//OnlyRead
            //tmpStr = tmpStr.Replace(":OR", "");

            Match M = Regex.Match(tmpStr, @"[A-Za-z]+[0-9]+(\.[0-9]+)?(\.[0-9]{2})?(?=:|$)");
            if(!M.Success)
                throw new Exception("地址格式不对:"+ItemID);
            AddrStr = M.Value;


            if (Regex.Match(tmpStr, @"\.[0-9]{2}(?=:|$)").Success)
            {
                DataType = VarEnum.VT_BOOL;
            }
            else
            if (Regex.Match(tmpStr, @":L(?=:|$)").Success)
            {
                DataType = VarEnum.VT_I1;
            }
            else
            if (Regex.Match(tmpStr, @":W(?=:|$)").Success)
            {
                DataType = VarEnum.VT_I2;
            }
            else
            if (Regex.Match(tmpStr, @":WU(?=:|$)").Success)
            {
                DataType = VarEnum.VT_UI2;
            }
            else
            if (Regex.Match(tmpStr, @":D(?=:|$)").Success)
            {
                DataType = VarEnum.VT_I4;
            }
            else
            if (Regex.Match(tmpStr, @":DU(?=:|$)").Success)
            {
                DataType = VarEnum.VT_UI4;
            }
            else
            if (Regex.Match(tmpStr, @":I(?=:|$)").Success)
            {
                DataType = VarEnum.VT_I8;
            }
            else
            if (Regex.Match(tmpStr, @":IU(?=:|$)").Success)
            {
                DataType = VarEnum.VT_UI8;
            }
            else
            if (Regex.Match(tmpStr, @":R(?=:|$)").Success)
            {
                DataType = VarEnum.VT_R4;
            }
            else
            if (Regex.Match(tmpStr, @":DR(?=:|$)").Success)
            {
                DataType = VarEnum.VT_R8;
            }
            else
            if (Regex.Match(tmpStr, @":S1(?=:|$)").Success)
            {
                DataType = VarEnum.VT_BSTR;
            }
            else
            {
                DataType = VarEnum.VT_UI1;//Ubyte没有类型标记的默认类型
            }
        }
    }
}
