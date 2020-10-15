using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_and_Objects
{
    class ClientDepartment
    {
        static void Main()
        {
            Console.WriteLine("Main Function Begins");

            Console.WriteLine("Enter the Organization Name");
            Department.Orgname = Console.ReadLine();

            new Department();
            // new Department("LTI").DisplayOrgDetails();
            new Department().DisplayOrgDetails();
            //Single Department
            Department department = new Department(100, "HR", "Chennai");
            department.DisplayDeptDetails();
            Console.WriteLine("------------Array of Object------------------");
            //Multiple Department
            //Array of Object
            Department[] deptarray = new Department[3];
            deptarray[0] = new Department(101, "Sales", "Pune");
            deptarray[1] = new Department(102, "Finance", "Pune");
            deptarray[2]= new Department(100, "HR", "Chennai");

            foreach(Department d in deptarray )
            {
                d.DisplayDeptDetails();
            }

          
            Console.Read();
        }
    }
}
