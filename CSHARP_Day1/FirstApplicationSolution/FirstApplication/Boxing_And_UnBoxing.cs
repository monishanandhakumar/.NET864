using System;


namespace FirstApplication
{
    class Boxing_And_UnBoxing
    {
        static void Main()
        {
            int Data = 10;

            object o = Data;  // boxing 
            int j = Convert.ToInt32(o); // unboxing
            int g = (int)o;
        }
    }
}
