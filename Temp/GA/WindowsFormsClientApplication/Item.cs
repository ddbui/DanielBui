using System;

namespace WindowsFormsClientApplication
{
    public class Item
    {
        public string Channel { get; private set; }
        public double? Good { get; private set; }
        public double? Bad { get; private set; }
        public double? Diff { get; private set; }

        public double? Absolute { get; private set; }

        public Item(string name, double? good, double? bad)
        {
            // TODO: Check for NULL (Not sure if we need too!)
            Channel = name;
            Good    = good;
            Bad     = bad;
            Diff    = (Good - Bad) / Bad;

            if (Diff != null)
            {
                Absolute = Math.Abs((double) Diff);
            }
        }
    }
}