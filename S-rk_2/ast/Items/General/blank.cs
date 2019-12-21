using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_rk_2.ast.Items.General
{
    static class blank
    {
        public static Dictionary<string, dynamic> Attributes = new Dictionary<string, dynamic>();
        public static bool Sellable = false;
        public static int ID = -1;
        public static int Price = -1;
        public static string Name = "blank";
        public static string Description = "blank dev item";
        public static string Image = "";
        public static Item ToItem() => new Item(Sellable, ID, Price, Name, Description, Image, Attributes);
    }
}
