using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    interface INormalCalculator
    {
        //by default public and abstract
        string CalciName(string Name);
        int Add(int data1,int data2);
       
    }
}
