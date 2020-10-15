using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodEg
{ /*when number of parameters is not known in prior
    params should be the last argument in parameter List
    parameter List can have only one params*/


    class ParamsEg
    {
        //ERROR
       // void Total( params int[] Marks,int id)
        // void Total( int id, params int[] Marks,int a)
        void Total(string id, params int[] Marks)
        {
            int sum = 0;
            foreach(int m in Marks)
            {
                sum += m;
            }
            Console.WriteLine("Total Marks :{0}",sum);
        }

        void ObjParam(int id,params object[] Student)
        {
            Console.WriteLine(id);
            foreach(object stu in Student)
            {
                Console.WriteLine(stu);
            }

        }

        static void Main()
        {
            string Id = "PS100787";
           // int[] Mark = { 89, 90, 78, 89 };
            // new ParamsEg().Total(Id, Mark);
            new ParamsEg().Total(Id, 89, 90, 78, 89);
            new ParamsEg().ObjParam(1001, "SAI", "HR", 56000);
            Console.Read();
        }
    }
}
