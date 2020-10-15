using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodEg
{
    //call by value and call by reference
    //See the difference btw ref and out

    class Call_V_R_Eg
    {
        void ByValue(int value)
        {
            value = 210;
            Console.WriteLine("Inside Call by value :{0}", value);
        }

        void ByReference(ref int value)
        {
            value = 300;
            Console.WriteLine("Inside Call by value :{0}", value);
        }
        void Calculation( int value1,int value2,out int add,out int product,out float div)
        {
            add = value1 + value2;
            product = value1 * value2;
            if (value2 > 0)
                div =(float) value1 / value2;
            else
                div = 0;
        }

        static void Main()
        {
            int number = 100,sum =0,product =0;
            float div = 0f;
            // Call_V_R_Eg obj = new Call_V_R_Eg();
            //ANONYMOUS OBJECT
            new Call_V_R_Eg().ByValue(number);
            Console.WriteLine("Number :{0}",number);
            Console.WriteLine("----------------------");
            new Call_V_R_Eg().ByReference(ref number);
            Console.WriteLine("Number :{0}", number);
            Console.WriteLine("----------------------");
            new Call_V_R_Eg().Calculation(0,0,out sum,out product,out div);
            if(sum>0 && product >0)
            {
                Console.WriteLine("Sum :{0}  &&  Product:{1}",sum,product);
            }
            else
            {
                Console.WriteLine("Values are not greater than Zero!!");
            }

            Console.Read();
        }
    }
}
