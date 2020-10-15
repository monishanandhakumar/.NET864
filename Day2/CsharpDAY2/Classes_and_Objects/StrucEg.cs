using System;


namespace Classes_and_Objects
{
    //a structure is a value type data type. It helps you to make a
    //single variable hold related data of various data types
    /*Access_Modifier struct structure_name
{

   // Fields 
   // Parameterized constructor 
   // Constants 
   // Properties 
   // Indexers 
   // Events 
   // Methods etc.
   
}*/
    public struct Pen
    {
        // Declaring different data types 
        public string PenName { get; private set; }
     
        public string Color { get; set; }

        public Pen(string PenName,string Color)
        {
            this.PenName = PenName;
            this.Color = Color;
        }
    }
    class StrucEg
    {
        static void Main()
        {
            // Declare P1 of type Pen 
            Pen P1 = new Pen("Parker","Blue");

          //Error
          //  P1.PenName = "Board Marker";
           P1.Color = "Red";

            // Displaying the values  
            Console.WriteLine("{0}||{1}",P1.PenName, P1.Color);
            Console.Read();
        }

    }
}
