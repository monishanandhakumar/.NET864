using System;
using System.IO;

namespace ExceptionHandlingEg
{
    class FileWrite
    {
        public void WriteData()
        {
            FileStream fs = new FileStream("d:\\test.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            try { 
           
            Console.WriteLine("Enter the text which you want to write to the file");
            string str = Console.ReadLine();
            sw.WriteLine(str);
            sw.Flush();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { 
            sw.Close();
            fs.Close();
            }
        }
    }
    class FileEg
    {
        
        static void Main()
        {
            FileWrite wr = new FileWrite();
            wr.WriteData();
            Console.Read();
        }
    }
}
