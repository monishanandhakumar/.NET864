using System;

namespace Classes_and_Objects
{
    class Student
    {
       internal static string CollegeName;
        int id = 100;

        //Non -static Method can access static variable
       internal void DisplayCollegeDetails()
        {
            Console.WriteLine("CollegeName :{0}", CollegeName);
        }

        internal  static void Display()
        {
            //cant access non static variable in static Method
           // Console.WriteLine("CollegeID :{0}", id);
            Console.WriteLine("CollegeName :{0}", CollegeName);
        }

    }
    class StaticEg
    {
      static  string phno;
        internal static void Displayphno()
        {
            
            Console.WriteLine("CollegeName :{0}", phno);
        }

      public  static void Main()
        {
            phno = "2324324324";
            Console.WriteLine("Enter your College Name");
            Student.CollegeName= Console.ReadLine();
            Student student = new Student();
            student.DisplayCollegeDetails();
            //Calling the static Method of student class
            Student.Display();
            //calling static function from staticEg class

             Displayphno();
            Console.Read();
        }

    }
}
