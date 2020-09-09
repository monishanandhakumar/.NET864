using System;


namespace PrjSecond
{
    class ArrayEg
    {
        static void Main()
        {
            //Single Dimensional Array
            //datatype[] arrayname=new datatype[size];
            string[] Fruits = new string[5];

           
            for(int i =0;i<Fruits.Length;i++)
            {
                Console.Write("Enter Fruit  Name of index {0}",i);
                Fruits[i] = Console.ReadLine();
            }
            Array.Sort(Fruits);
            Console.WriteLine("Sorted Array");
            for (int i = 0; i < Fruits.Length; i++)
            {
                Console.WriteLine("Enter Fruit  Name of index {0} :{1}", i,Fruits[i]);
               
            }
           

            Console.Read();

        }
    }
}
