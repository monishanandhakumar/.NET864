using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_and_Objects
{
    /*Constructor name same that of your class name
     * no return 
     * initialization*/
    class Department
    {
     internal static  String Orgname ;
        int Did;
        string Dname,Location;

      internal  Department()
        {
            Console.WriteLine("This is a default Constructor");
        }


       /* internal Department(string Orgname)
        {
           this.Orgname = Orgname;
        }*/

        internal  Department(int id, string name,string Location)
        {
            Did = id;
            Dname = name;
            this.Location = Location; //this current instance
        }

        internal void DisplayDeptDetails()
        {
            
            Console.WriteLine("ID :{0} || NAME:{1} || LOCATION:{2} ||ORGNAME:{3}",Did,Dname,Location,Orgname);
        }

        internal void DisplayOrgDetails()
        {
            Console.WriteLine("Orgname:{0}", Orgname);
           
        }

    }
    class ConstructorEg
    {
        
    }
}
