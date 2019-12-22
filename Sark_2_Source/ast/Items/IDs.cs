using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sark_2_Source;
using Sark_2_Source.ast;
using Sark_2_Source.ast.Items;
using Sark_2_Source.ast.Items.G;
using Sark_2_Source.ast.Items.W;

namespace Sark_2_Source.ast.Items
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
