using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace StateManager
{
	//WEB应用时安全接口
    [ComImport, Guid("1D9AD540-F2C9-4368-8697-C4AAFCCE9C55")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IObjectSafety
    {
        [PreserveSig]
        void GetInterfacceSafyOptions(int riid,out int pdwSupportedOptions,out int pdwEnabledOptions);

        [PreserveSig]
        void SetInterfaceSafetyOptions(int riid,int dwOptionsSetMask,int dwEnabledOptions);
    }
}


        // public void GetInterfacceSafyOptions(int riid, out int pdwSupportedOptions, out int pdwEnabledOptions)
        // {
            // pdwSupportedOptions = 1;
            // pdwEnabledOptions = 2;
        // }

        // public void SetInterfaceSafetyOptions(int riid, int dwOptionsSetMask, int dwEnabledOptions)
        // {
            // throw new NotImplementedException();
        // }
