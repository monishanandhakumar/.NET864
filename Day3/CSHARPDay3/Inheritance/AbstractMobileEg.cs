using System;

namespace Inheritance
{
    abstract class ISOstandard
    {
       internal ISOstandard()
        {
            Console.WriteLine("ISOstandardConstructor");
        }
        public abstract int Terms();
        
    }
    //cant create object for abstract class
    abstract class MobileStandard: ISOstandard
    {
        public int EmployeeCount = 20;
        //Abstract Method
        public  abstract void Call();
        //Non -Abstract Method
        internal void MobileStandardEmployee()
        {
            Console.WriteLine("MobileStandardEmployee:{0}", EmployeeCount);
        }
    }
    //Implement all the abstract method of MobileStandard
    class Apple : MobileStandard
    {
        public override int Terms()
        {
            Console.WriteLine("Apple Terms and Condition");
            return 0;
        }
        public  override void Call()
        {
            Console.WriteLine("Apple Call");
        }
    }
    class Samsung: MobileStandard
    {
        public override int Terms()
        {
            Console.WriteLine("Apple Terms and Condition");
            return 0;
        }
        public override void Call()
        {
            Console.WriteLine("Samsung Call");
        }
    }
    class AbstractMobileEg
    {
        static void Main()
        {
            /* Apple apple = new Apple();
             apple.MobileStandardEmployee();
             apple.Call();
             Samsung samsung = new Samsung();
             samsung.Call();*/
            //run time polymorphism or Dynamic polymorphism
            MobileStandard mobileStandard;
            mobileStandard = new Apple();
            mobileStandard.Call(); //call Method in Apple
            Console.WriteLine(mobileStandard.Terms()); 
            mobileStandard = new Samsung();
            mobileStandard.Call(); //Call Method in samsung
            Console.WriteLine(mobileStandard.Terms());
            Console.Read();
        }
    }
}
