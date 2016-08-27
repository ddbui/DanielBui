using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Singleton
{
    // The singleton class
    public class Singleton 
    {
        // Private constructor
        Singleton() 
        { 
        } 
 
        // A property that returns a Singleton instance created by Nested
        public static Singleton Instance 
        { 
            get 
            { 
                return Nested.instance; 
            }
        }
    
        // Nested class, only accessible to Singleton
        class Nested
        {
            // Static constructor
            static Nested()
            {
            }

            // A static member that returns a Singleton instance.
            internal static readonly Singleton instance = new Singleton();
        }
    } 
}
