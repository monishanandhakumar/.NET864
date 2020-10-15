using System;


namespace MethodEg
{
   /*<accessspecifier> <return type> FunctionName (<p1>...<pn>)
    * {
    *    function-body
    *    return statement
    *    }*/
    class MethodParameters
    {
        string Name;
        int Age;

        void GetUserDetails()
        {
            Console.WriteLine("User Name ");
            Name = Console.ReadLine();
            Console.WriteLine("User Age ");
            Age = Convert.ToInt32(Console.ReadLine());

        }

        void DisplayUserDetails()
        {
            Console.WriteLine("USER NAME :{0} && USER AGE:{1}",Name,Age);
        }

        static void Main()
        {
            MethodParameters methodParameters = new MethodParameters();
            methodParameters.GetUserDetails();
            methodParameters.DisplayUserDetails();
            Console.Read();
        }
    }
}
