using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using StateManager;

namespace SMOPCDevice
{
    [Guid("D3BA2ABA-93EF-4D6E-869B-004C4FE95ADD")]
    public interface ISMOPCDevice
    { 
        bool ItemIDAdd(string ItemID);
        bool ItemIDWriteAble(string ItemID);
        int ItemIDPropID(string ItemID);
        int ItemIDDataType(string ItemID);
        object GetItemValue(string ItemID);
        void SetItemValue(string ItemID, object Value);
        string EnumItemIDs();
    }

    [Guid("25930171-2872-4EC3-A81B-0E11229501B0")]//如果不定义也是会自动生成的
    [ClassInterface(ClassInterfaceType.None)]//不为类生成类接口
    public class SMOPCDevice : ISMOPCDevice
    {
        Dictionary<string, SMOPCItem> Items = new Dictionary<string, SMOPCItem>();
        public SManager SManager;
        public SMOPCDevice()
        {
            SManager = new SManager(Application.StartupPath+"\\SMOPCDevice.json");
            SManager.Start();
        }
        public bool ItemIDAdd(string ItemID)
        {
            SMOPCItem item;
            try
            {
                item = new SMOPCItem(ItemID);
                object obj = SManager.GetSOObject(item.DeviceName);

                if (obj!=null)//是否在SM连接列表中
                {
                    item.ParseSubItemID();
                    Items.Add(ItemID, item);
                    item.PropID = 2;
                    return true;
                }
                else
                    return false;
            }
            catch(Exception E)
            {
                MessageBox.Show(E.Message);
                return false;
            }
        }

        public bool ItemIDWriteAble(string ItemID)
        {
            return !Items[ItemID].ReadOnly;
        }

        public int ItemIDPropID(string ItemID)
        {
            if (!Items.ContainsKey(ItemID))
                return 0;
            return (int)Items[ItemID].PropID;
        }

        public int ItemIDDataType(string ItemID)
        {

            return (int)Items[ItemID].DataType;
        }


        public string EnumItemIDs()
        {
            string[] s = new string[11] { 
                "PLC_S7.DB1.0.01:此示例表示设备PLC_S7的DB1.0.01位可读可写", 
                "PLC_S7.DB1.0.02:OR:此示例表示只读数据", 
                "PLC_S7.DB1.0:L:此示例为byte类型",
                "PLC_S7.DB1.0:W:此示例为short(16位)类型",
                "PLC_S7.DB1.0:D:此示例为long(32位)类型",
                "PLC_S7.DB1.7:DR:此示例为double类型",
                "PLC_S7.DB1.15:S1:此示例为bstr字符串类型",
                "PLC_S7.DB1.0:此示例为Ubyte类型",
                "PLC_S7.DB1.0:WU:此示例为Ushort(16位)类型",
                "PLC_S7.DB1.0:DU:此示例为Ulong(32位)类型",
                "PLC_S7.DB1.0:IU:此示例为ulonglong(64位)类型",
            
            };//用户可按格式任意添加
            return string.Join("\n", s);
        }


        public object GetItemValue(string ItemID)
        {
            try
            {
                //MessageBox.Show(ItemID);
                string DeviceName = Items[ItemID].DeviceName;
                string AddrStr = Items[ItemID].AddrStr;
                dynamic DeviceObj = SManager.GetSOObject(DeviceName);
                if (!DeviceObj.Connected) return null;
                //if (SManager.GetSO(DeviceName).OnTime("", 1000))//保证实时性
                {
                    switch (Items[ItemID].DataType)
                    {
                        case VarEnum.VT_BOOL:
                            Items[ItemID].CacheValue = (bool)DeviceObj.ReadBool(AddrStr);
                            break;
                        case VarEnum.VT_BSTR:
                            Items[ItemID].CacheValue = "测试字符串";
                            break;
                        case VarEnum.VT_I2:
                            Items[ItemID].CacheValue = (Int16)DeviceObj.ReadInt16(AddrStr);
                            break;
                        case VarEnum.VT_I4:
                            Items[ItemID].CacheValue = (Int32)DeviceObj.ReadInt32(AddrStr);
                            break;
                        default:
                            Items[ItemID].CacheValue = null;
                            break;

                    }
                }
                //MessageBox.Show(Items[ItemID].CacheValue.ToString());
                return Items[ItemID].CacheValue;
            }
            catch
            {
                return null;
            }
        }

        public void SetItemValue(string ItemID, object Value)
        {
            string DeviceName = Items[ItemID].DeviceName;
            string AddrStr = Items[ItemID].AddrStr;
            dynamic DeviceObj = SManager.GetSOObject(DeviceName);
            if (!DeviceObj.Connected) return;
            switch (Items[ItemID].DataType)
            {
                case VarEnum.VT_BOOL:
                    DeviceObj.Write(AddrStr,(bool)Value);
                    break;
                case VarEnum.VT_BSTR:
                    DeviceObj.Write(AddrStr, (string)Value);
                    break;
                case VarEnum.VT_I2:
                    DeviceObj.Write(AddrStr, (Int16)Value);
                    break;
                case VarEnum.VT_I4:
                    DeviceObj.Write(AddrStr, (Int32)Value);
                    break;
                default:
                    break;

            }
        }
    }
}
