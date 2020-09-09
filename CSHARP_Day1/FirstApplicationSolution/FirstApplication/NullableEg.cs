using System;


namespace FirstApplication
{
    class NullableEg
    {
        static void Main()
        {
            //Age(int) column in null in tblEmployee
            
            //Nullable Type
          
     
            int? Age = null;
            /*  if(Age!=null)
               {
                   Console.WriteLine("Äge is {0}", Age);
               }
               else
               {
                   Console.WriteLine("Age is null.Please update your Age!! ");
               }*/

            //NullCoalescing Operator
            Console.WriteLine("Age is {0}",Age??0);

            Console.WriteLine("----------------------------------");

            string OrgName = null;
            Console.WriteLine("OrgName:{0}", OrgName??"No Org Name");
            //when occurs an type conversion error
            Console.WriteLine("OrgName:{0}", (OrgName ?? "No Org Name").ToString());
            Console.WriteLine("----------------------------------");

            int AvailableTickets,TotalTickets=100;
            int? TicketonSale = null;
            AvailableTickets = TotalTickets - (TicketonSale ?? 0);
            Console.WriteLine("AvailableTickets ={0}", AvailableTickets);

            Console.ReadKey();

        }
    }
}
