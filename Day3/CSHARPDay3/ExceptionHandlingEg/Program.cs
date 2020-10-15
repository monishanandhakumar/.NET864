using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingEg
{
    class ExceptionEg
    {
        internal int value = 20;
        string[] Book = { "JAVA", "DBMS", "SQLSERVER" };

        public void Calculate()
        {

            //value = value / 0;
             try
             {
               //  value = value / 0;
               Console.WriteLine("array :{0}",Book[5]);
             }
            //error
            /*  catch (Exception e)
              {
                  Console.WriteLine(e);

              }*/
                  catch (DivideByZeroException e)
                  {
                      Console.WriteLine(e.Message);

                  }
                  catch (IndexOutOfRangeException e)
                  {
                      Console.WriteLine(e.Source);

                  }
                  catch (Exception e)
                  {
                      Console.WriteLine(e);

                  }
            //Only when the exception is handled finally block gets executed
            finally
            {
                Console.WriteLine("Finally Block");
            }


        }

    }
    

    class Program
    {

        static void Main(string[] args)
        {
            ExceptionEg exceptionEg = new ExceptionEg();
            exceptionEg.Calculate();
            Console.Read();
        }
    }
}
