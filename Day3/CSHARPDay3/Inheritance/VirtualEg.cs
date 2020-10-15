using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
  class RBIBank
    {
        public virtual string HomeLoan()
        {
            return "9%";
        }

          public  void Test()
          {
              Console.WriteLine("Sample Method of RBI");
          }
       // public abstract void Test();

        public  void Sample()
        {
            Console.WriteLine("I am sample in RBI");
        }
    }

    class SBI:RBIBank
    {
        public override string HomeLoan()
        {
            return "10.5%";
        }

        /*  public override void Test()
          {

          }*/
        public new void Sample()
        {
            Console.WriteLine("I am sample in RBI");
        }
    }

    class INDIAN : RBIBank
    {
        public override string HomeLoan()
        {
            return "7.5%";
        }
        public new void Sample()
        {
            Console.WriteLine("I am sample in Indian");
        }

    }
    class VirtualEg
    {
        static void Main()
        {
            RBIBank rBIBank = new RBIBank();
              Console.WriteLine("RBI :{0}", rBIBank.HomeLoan());  
              rBIBank.Test();
            rBIBank.Sample();

              SBI sBI = new SBI();
              Console.WriteLine("SBI:{0}",sBI.HomeLoan());
            sBI.Sample();
              INDIAN iNDIAN = new INDIAN();
              Console.WriteLine("Indian:{0}", iNDIAN.HomeLoan());

           
            
            Console.Read();

        }
    }
}
