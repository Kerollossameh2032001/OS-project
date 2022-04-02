using System;
using System.Collections.Generic;
using System.Text;

namespace OS_Version_1
{
    class directory : Directory_Entry
    {
        static List<Directory_Entry> list = new List<Directory_Entry>();
        
        public static void writeContentDirectory()
        {
            byte[] data = new byte[list.Count * 32];
           
            List<byte> conv = new List<byte>();
            for (int i=0; i < list.Count; i++)
            {
                //conv.AddRange();
            }
        } 
    }
}
