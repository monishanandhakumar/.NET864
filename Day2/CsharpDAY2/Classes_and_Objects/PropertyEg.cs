using System;


namespace Classes_and_Objects
{
    // private variable of the class
    class Mobile
    {
        //Read-Only Property or Accessor
      public  string MobileName { get; private set; }
       public string Modelno { get; set; }
        private int cost;
       public int Cost
        {
            get
            {
                return cost;
            }

            set
            {
                cost = value;
            }
        }

      public  Mobile(string MobileName)
        {
            this.MobileName = MobileName;
            
        }

     internal   void DisplayMobileDetails()
        {
            Console.WriteLine("{0}", MobileName);
        }

    }
    class MobileInfo
    {

    }
    class PropertyEg
    {
        static void Main()
        {
            Mobile mobile = new Mobile("OnePlus");
            mobile.Cost = 6700;
            mobile.DisplayMobileDetails();
            Console.Read();

        }
    }
}
