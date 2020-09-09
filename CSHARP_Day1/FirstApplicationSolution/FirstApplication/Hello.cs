using System;


namespace FirstApplication
{
    class Hello
    {
        static void Main()
        {
            Console.WriteLine("WELCOME ALL!!");
            int value1 = 40, value2 = 60,Result;
            Result = value1 * value2;
            //\N
            //By using Iterpolation
            Console.WriteLine("RESULT IS ",Result);
            //Concatenation
            Console.WriteLine("RESULT IS "+Result);

            Console.WriteLine("{0} * {1} ={2}", value1, value2, Result);
            Console.WriteLine("-------------------------------------");
            //Getting Input from USER
            Console.WriteLine("Enter Your Name");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("-------------------------------------");
            string Name = Console.ReadLine();

            Console.WriteLine("My Name is {0}", Name);
           
            Console.WriteLine("Enter your Experience");
            int Experience =Convert.ToInt32( Console.ReadLine());

            Console.WriteLine("Experience {0}", Experience);

            Console.ReadKey();
            //Get your Personal details and Print the Same



        }
    }
}
