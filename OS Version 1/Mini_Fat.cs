using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;


namespace OS_Version_1
{
    class Mini_Fat
    {
        // array to refer The Fat table
        static int[] Fat = new int[1024];
        
        //1- Method to prepare the Fat in intialize  
        public static void prepare_Fat()
        {
            for(int i = 0; i < Fat.Length; i++)
            {
                if(i <= 4)
                {
                    Fat[i] = -1;
                }
                else
                {
                    Fat[i] = 0;
                }
            }
        }

        //2-Method for print Fat fro debug
        public static void print_Fat_array()
        {
            for(int i=0; i<Fat.Length; i++)
            {
                Console.WriteLine(Fat[i]);
            }
        }

        //3-Method to return available cluster 
        public static int getAvailableCluster()
        {
            int index = -1;
            for(int i=0; i<Fat.Length; i++)
            {
                if (Fat[i] == 0)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        //4-Method to get Cluster state
        public static int getClusterStatus(int clusterIndex)
        {
            return Fat[clusterIndex];
        }

        //5-Method to setting cluster value
        public static void setClusterStatus(int clusterindex, int status)
        {
            Fat[clusterindex] = status;
        }

        //6-Method to set the value of Fat Array
        public static void setFatArray(int[] arr)
        {
            Fat = arr;
        }

        //7-Method to write Fat array in virtual disk
        public static void writeFat()
        {
            //Buffer.BlockCopy(fat, 0, result, 0, result.Length);
            byte[] data = new byte[1024];
            
            for (int i=0; i<4; i++)
            {
                Buffer.BlockCopy(Fat, i*256, data, 0, data.Length);
                virtualDisk.writeCluster(i,data);
            }
        }
        
        //8-Method to read Fat
        public static int[] readFat()
        {
            int[] readed = new int[1024];
            byte[] data = new byte[4096];

            //intialize List of byte to add the data of each cluster in one list    
            List<byte> list = new List<byte>();

            for(int i = 0; i<4; i++)
            {
                list.AddRange(virtualDisk.readCluster(i));
            }
            
            //store the list to data after converted it to array of byte
             data = list.ToArray();

            //convert the array of byte to array of int and return it 
             Buffer.BlockCopy(readed, 0, data, 0, data.Length);
            
            return readed;
        }
    }
}

























/*using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;


namespace OS_Version_1
{
    class Fat
    {
        static int[] fatTable = new int[1024];

        public static void intialize()
        {
            for(int i  = 0; i< 1024; i++)
            {
                if (i < 5)
                {
                    fatTable[i] = -1;
                }
                else
                {
                    fatTable[i] = 0;
                }
            }
            writeFateTable();
        }

        public static void writeFateTable()
        {
            FileStream fs = new FileStream("fatTable.txt", FileMode.Open);
            fs.Seek(1024, SeekOrigin.Begin);

            byte[] result = new byte[fatTable.Length * sizeof(int)];
            Buffer.BlockCopy(fatTable, 0, result, 0, result.Length);

            fs.Write(result);
            fs.Flush();
            fs.Close();
        }

        public static int[] GetFateTable()
        {
            int[] arr = new int[1024];
            FileStream fs = new FileStream(@"fatTable.txt", FileMode.Open);
            fs.Seek(1024, SeekOrigin.Begin);

            byte[] result = new byte[fatTable.Length * sizeof(int)];

            
            fs.Read(result);
            fs.Flush();
            fs.Close();
            //fatTable = result.Select(x => (int)x).ToArray();
            return fatTable;
        }

        public static int getaVailableCluster()
        {
            fatTable = GetFateTable();
            int index = -1 ;
            for(int i = 0; i<fatTable.Length; i++)
            {
                if(fatTable[i] == 0)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        void setClusterStatus(int clusterindex,int status)
        {
            fatTable[clusterindex] = status;
        }
        int getClusterStatus(int clusterIndex)
        {
            return fatTable[clusterIndex];
        }
        //Method to know if there is space in this place 
        public static int getNext(int index)
        {
            fatTable = GetFateTable();
            return fatTable[index];
        }


        //Method to update in fatable 
        public static void setNext(int[] fat , int index)
        {
            fatTable = fat;
            fatTable[index] = -1;
            writeFateTable();
        }



        //Method for test 
        public static void printFatTable()
        {
            fatTable = GetFateTable();
            Console.WriteLine(fatTable.Length);
            for(int i = 0; i<fatTable.Length; i++)
            {
                Console.WriteLine($"index: {i}   value :  {fatTable[i]}");
            }
        }
    }
}
*/