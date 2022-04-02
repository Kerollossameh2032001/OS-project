using System;
using System.Collections.Generic;
using System.Text;

namespace OS_Version_1
{
    class Directory_Entry
    {
         char[] dir_name = new char[11];
        //attr -> 0x0(file),,,  0x10(directory)
         byte attr;
         int[] dir_empty = new int[3];
         int dir_firstcluster;
         byte dir_filesize;


        public Directory_Entry()
        {
        }
        public Directory_Entry(char[] name , byte type , int firstcluster)
        {
            dir_name = name;
            attr = type;
            dir_firstcluster = firstcluster;
        }
        
        
        
        public char[] get_dirName {
            get{
                return dir_name;
            }
            set
            {
                dir_name = value;
            }
        }
        public byte get_attr {
            get
            {
                return attr;
            }
            set
            {
                attr = value;
            }
        }
        public int[] get_dirEmpty {
            get
            {
                return dir_empty;
            }
            set
            {
                dir_empty = value;
            }
        }
        public int get_dirFirstCluster {
            get
            {
                return dir_firstcluster;
            }
            set
            {
                dir_firstcluster = value;
            }
        }
        public byte get_dirSize {
            get
            {
                return dir_filesize;
            }
            set
            {
                dir_filesize = value;
            }
        }

    }
}
  