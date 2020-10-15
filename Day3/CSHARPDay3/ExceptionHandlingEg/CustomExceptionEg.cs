using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingEg
{
    public class AgeNotValidException:ApplicationException
    {
        public AgeNotValidException(string Message):base(Message)
        {

        }
    }

    class Student
    {
      public  string Name { get; set; }
        public int Age { get; set; }
      internal  Student (string Name, int Age)
        {
            Name = this.Name;
            Age = this.Age;
        }

        public void AgeCheck()
        {
            string Result;
            try
            {
                if (Age > 20)
                {
                    Console.WriteLine("Registered!!");
                }
                else
                {
                    throw new AgeNotValidException("Age should be greater than 20 to register!!");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

    }

    class CustomExceptionEg
    {
        static void Main()
        {
            Student student = new Student("SRi",19);
            student.AgeCheck();
            Console.Read();
        }

    }
}
