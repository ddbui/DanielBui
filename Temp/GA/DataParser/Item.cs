using System;

namespace DataParser
{
    public class Item
    {
        public bool Selected { get; set; }
        public string Channel { get; private set; }

        [System.ComponentModel.DisplayName(@"Good Flight")]
        public double? Good { get; private set; }

        [System.ComponentModel.DisplayName(@"Bad Flight")]
        public double? Bad { get; private set; }

        [System.ComponentModel.DisplayName(@"Difference")]
        public double? Diff { get; private set; }

        [System.ComponentModel.DisplayName(@"Absolute Difference")]
        public double? Absolute { get; private set; }

        public Item(string name, double? good, double? bad)
        {
            Selected = false;
            Channel  = name;
            Good     = good;
            Bad      = bad;
            Diff     = (Good - Bad) / Bad;

            if (Diff != null)
            {
                Absolute = Math.Abs((double) Diff);
            }
        }
    }
}