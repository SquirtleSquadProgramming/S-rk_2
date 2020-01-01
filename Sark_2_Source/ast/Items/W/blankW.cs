using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sark_2_Source.ast.Items.W
{
    static class blankw
    {
        public static Dictionary<string, dynamic> Attributes = new Dictionary<string, dynamic>();
        public static bool Sellable = false;
        public static float ID = -1.2f;
        public static int Price = -1;
        public static string Name = "blankw";
        public static string Description = "blank dev item";
        public static string Image = "";
        public static Item ToItem() => new Item(Sellable, ID, Price, Name, Description, Image, Attributes);
    }
}
