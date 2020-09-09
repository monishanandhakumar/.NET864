using System;


namespace FirstApplication
{
    class TypeConversionEg
    {
        static void Main()
        {
            //Implicit Conversion
            //no data loss, no exception
            int i = 100;
           float f = i;
            double d = f;
            Console.WriteLine("Implicit Conversion");
            Console.WriteLine("Int -->float-->Double :{0}",d);

            //Explicit Conversion
            float f1 = 23456789.89f;
            int value = Convert.ToInt32(f1);

            Console.WriteLine("Explicit  Conversion");
            Console.WriteLine("Float-->Int :{0}", value);
            Console.Read();

        }
    }
}
