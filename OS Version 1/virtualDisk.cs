using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace OS_Version_1
{
    class virtualDisk
    {
        static  FileStream disk;
        static String path;

        ///1- <summary>
        /// Method that take the name of file and check if exists or not 
        /// if exists read the Fat from file
        /// if not create the file and prepare method to intialize the fat array then
        /// write it in file 
        /// </summary>
        /// <param name="fileName"></param>
        
        public static void intialize(String fileName)
        {
            path = fileName;
            if (!File.Exists(fileName))
            {
                 disk = new FileStream(fileName, FileMode.Create);
                Mini_Fat.prepare_Fat();
                Mini_Fat.writeFat();
            }
            else
            {
                Mini_Fat.readFat();
            }
            
        }

        //2-Method to write cluster in file
        public static void writeCluster(int cluster, byte[] data)
        {
            disk = File.Open(path, FileMode.Open);
            disk.Seek(1024 * cluster, SeekOrigin.Begin);
            disk.Write(data);
            disk.Flush();
            disk.Close();
        }



        //3-Method to read cluster from file
        public static byte[] readCluster(int index)
        {
            byte[] result = new byte[1024];

            disk = File.Open(path, FileMode.Open);
            disk.Seek(1024 * index, SeekOrigin.Begin);

            disk.Read(result);
            disk.Close();

            return result;
        }
    }
}

























/*using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OS_Version_1
{
    class virsualDisk
    {
        public static void AppendAllBytes(string path, byte[] bytes)
        {
            //argument-checking here.
            using (var stream = new FileStream(path, FileMode.Append))
            {
                stream.Write(bytes, 0, bytes.Length);
            }
        }
        public static void intialize()
        {
            byte[] result = new byte[4024];
            
            for (int i = 0; i < 256; i++)
            {
                int intValue = 0;
                byte[] intBytes = BitConverter.GetBytes(intValue);
                result = intBytes;
                AppendAllBytes("fatTable.txt", result);
            }
            

            for (int i = 0; i < 1024; i++)
            {
                int intValue = 0;
                byte[] intBytes = BitConverter.GetBytes(intValue);
                result = intBytes;
                AppendAllBytes("fatTable.txt", result);
            }

        }

        //Method to write cluster in file
        public static void writeCluster(byte[] data , int index)
        {
            FileStream fs = new FileStream("fatTable.txt", FileMode.Open);
            fs.Seek(1024*index, SeekOrigin.Begin);

            byte[] result = new byte[1024];

            //to store only 1024 byte
            result = data; 

            fs.Write(result);
            fs.Flush();
        }

        //Method to read cluster from file
        public static byte[] getCluster(int index)
        {
            byte[] result = new byte[1024];
            FileStream fs = new FileStream("fatTable.txt", FileMode.Open);
            fs.Seek(1024 * index, SeekOrigin.Begin);

            fs.Read(result);
            
            return result;
        }
    }
}
*/