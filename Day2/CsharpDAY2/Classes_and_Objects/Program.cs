using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_and_Objects
{
    class Program
    {
        string OrgName;
        int orgId;

        void DisplayDetails()
        {
            Console.WriteLine(OrgName+ " "+ orgId);

        }
        static void Main(string[] args)
        {
            Program pobj = new Program();
            pobj.orgId = 1001;
            pobj.OrgName = "LTI";
            pobj.DisplayDetails(); // LTI 1001
            Program pobj2 = new Program();
            pobj2.OrgName = "RENOLD";
            pobj2.DisplayDetails();//RENOLD 0
            Console.Read();
        }
    }
}
