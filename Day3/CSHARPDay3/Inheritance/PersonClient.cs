using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class BankEmployee:Person
    {

        internal BankEmployee(string Name, int Age, string Gender) : 
            base(Name, Age, Gender)
        {

        }
    }
    class PersonClient
    {
        static void Main()
        {
            BankEmployee bankEmployee = new BankEmployee("Suman", 40, "MALE");
            bankEmployee.DisplayNameGender();
            Console.Read();
        }
    }
}
