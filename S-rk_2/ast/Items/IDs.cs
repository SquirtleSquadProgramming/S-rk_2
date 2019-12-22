using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S_rk_2;
using S_rk_2.ast;
using S_rk_2.ast.Items;
using S_rk_2.ast.Items.G;
using S_rk_2.ast.Items.W;

namespace S_rk_2.ast.Items
{
    static class IDs
    {
        public static List<Item> Items = new List<Item>()
        {
            // Items
            blankG.ToItem(),

            // Weapons
            blankW.ToItem()
        };
    }
}
