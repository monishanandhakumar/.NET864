using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjSecond
{
    //Enumeration -special set of named valued
    //float,integer,byte,double etc
    /* enum enumname{
     * Enumeration list
     }*/

    enum Feedback { Poor=10, Fair=20, Good=67, VeryGood=90, Excellent=100 }
    class EnumEg
    {
        static void Main()
        {
            int WorstFeedback = Convert.ToInt32(Feedback.Poor);
            Console.WriteLine("Excellent:{0}",(int)Feedback.Excellent);
            Console.WriteLine(WorstFeedback);
            Console.Read();

        }
        
    }
}
