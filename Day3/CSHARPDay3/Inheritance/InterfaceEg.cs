using System;


namespace Inheritance
{
    interface IScientificCalculator
    {
        string CalciName(string Name);
        int Add(int data1, int data2);
        void Tan();
    }
    class Calculation:INormalCalculator, IScientificCalculator
    {
      public  string CalciName(string Name)
        {
            return Name;
        }
        

        public int Add(int data1, int data2)
        {
            return data1 + data2;
        }


        public void Tan()
        {
            Console.WriteLine("Tan 45 is 1");
        }
        //Implementing same method from both Interface
        string IScientificCalculator.CalciName(string Name)
        {
            Console.WriteLine("Scentific Calci Interface");
            return Name;
        }

        string INormalCalculator.CalciName(string Name)
        {
            Console.WriteLine("Normal Calci Interface");
            return Name;
        }


    }
    class InterfaceEg
    {
        static void Main()
        {
            Calculation calculation = new Calculation();
          //  Console.WriteLine("Name:{0}",calculation.CalciName("NormalCalculator"));
            Console.WriteLine("Add:{0}",calculation.Add(90,8));
            calculation.Tan();
            INormalCalculator normalCalculator = new Calculation();
            normalCalculator.CalciName("NormalCalci");
            IScientificCalculator scientificCalculator = new Calculation();
            scientificCalculator.CalciName("Scientific");

            Console.Read();
        }
    }
}
