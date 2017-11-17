using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ResourceLibrary
{
    public class CustomResources
    {
        public static ComponentResourceKey SadTileBrush => new ComponentResourceKey(
            typeof(CustomResources), "SadTileBrush");
    }
}
