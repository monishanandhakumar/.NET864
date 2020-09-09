using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjSecond
{
    class StringFunctionEg
    {
        static void Main()
        {
            string Firstname = "Sai";
            string Name = "Monisha Devi";
            Console.WriteLine("TO UPPER :{0}", Firstname.ToUpper());
            Console.WriteLine("TO Lower:{0}", Firstname.ToLower());
            Console.WriteLine("Length:{0}", Name.Length);
            bool isContains = Name.Contains("UP");
            Console.WriteLine("Contains UP:{0}", isContains);
            Console.WriteLine("Substring : {0}", Name.Substring(3, 5));

            //trim 

            Console.Read();

        }

    }
}
