using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Sark_2_Source.ast;
using Sark_2_Source.ast.Items;

namespace Sark_2_Source
{
    class Program
    {
        static void Main(string[] args)
        {
            Character.Inventory.Add((-1.1f).ToItem());
            Character.Inventory.Add((-1.2f).ToItem());
            Character.Settings["DarkTheme"] = "false";
            Character.Inventory.Menu();
        }
    }
}
