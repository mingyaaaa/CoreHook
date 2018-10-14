﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CoreHook.Unmanaged
{
    public class Binary
    {
        public static byte[] StructToByteArray(object obj, int? length = null)
        {
            var objectLength = Marshal.SizeOf(obj);
            var arr = new byte[length ?? objectLength];

            var ptr = Marshal.AllocHGlobal(objectLength);

            Marshal.StructureToPtr(obj, ptr, false);
            Marshal.Copy(ptr, arr, 0, objectLength);
            Marshal.FreeHGlobal(ptr);

            return arr;
        }
    }
}