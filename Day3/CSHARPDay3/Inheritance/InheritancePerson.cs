using System;
namespace Inheritance
{
  public  class Person
    {
       public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public string BankName="SBI";


       public Person(string Name, int Age, string Gender)
        {
            this.Name = Name;
            this.Age = Age;
            this.Gender = Gender;
            Console.WriteLine("Person class Constructor");
        }

    protected  void DisplayPerson()
        {
            Console.WriteLine("Name:{0}||Age:{1}||Gender:{2}",Name,Age,Gender);
        }
        internal protected void DisplayNameGender()
        {
            Console.WriteLine("Name:{0}||Gender:{2}", Name, Gender);
        }
        ~Person()
        {
            Console.WriteLine("Person Destructor");
        }
    }
    class Employee:Person
    {
        public int Eid { get; set; }
        public int Salaryperhour { get; set; }
        public string BankName="HDFC";


        public Employee(string Name, int Age, string Gender,int Eid, int Salaryperhour) :base(Name,Age,Gender)
        {
            this.Eid = Eid;
            this.Salaryperhour = Salaryperhour;

            Console.WriteLine("Employee class Constructor");
        }

      internal  void DisplayEmployee()
        {
            DisplayPerson();
            Console.WriteLine("Name:{0}||Eid:{1}||Salary:{2}", Name, Eid, Salaryperhour);
            Console.WriteLine("Person Bank :{0} || Employee Bank :{1}", base.BankName,BankName);
        }
        ~Employee()
        {
            Console.WriteLine("Employee Destructor");
        }
        
    }

    class FullTimeEmployee : Employee
    {
        int WorkingHours { get; set; }
        int TotalSalary;

        internal FullTimeEmployee(string Name, int Age, string Gender,
            int Eid, int Salaryperhour, int WorkingHours):base(Name, Age, Gender,Eid, Salaryperhour)
            {
            this.WorkingHours = WorkingHours;
            Console.WriteLine("FullTimeEmployee Constructor");
            }

      internal   void CalculateSalary()
        {
            TotalSalary = Salaryperhour * WorkingHours;
            Console.WriteLine("Name:{0}||Eid:{1}||TotalSalary:{2}",Name,Eid,TotalSalary);
        }
        ~FullTimeEmployee()
        {
            Console.WriteLine("FullTimeEmployee destructor");
        }

    }
    class InheritancePerson
    {
        static void Main()
        {
            //Employee employee = new Employee("SAI", 25, "Male", 1001,500);

            //employee.DisplayEmployee();

            FullTimeEmployee fullTimeEmployee = new FullTimeEmployee("SAI", 25, "Male", 1001, 500,10);
            fullTimeEmployee.DisplayEmployee();
            fullTimeEmployee.CalculateSalary();
            GC.Collect();
            Console.Read();
        }

    }
}
