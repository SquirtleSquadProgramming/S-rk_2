using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S_rk_2.ast.Items;

namespace S_rk_2
{
    public static class Extension
    {
        public static Item ToItem(this string Name)
        {
            Item outItem = Item.Items[0];
            foreach (Item i in Item.Items)
                if (i.Name == Name)
                    outItem = i;
            if (outItem.ID == -1)
                throw new Item.UnknownItemException("Blank item");
            return outItem;
        }

        public static Item ToItem(this int ID)
        {
            Item outItem = Item.Items[0];
            foreach (Item i in Item.Items)
                if (i.ID == ID)
                    outItem = i;
            if (outItem.ID == -1)
                throw new Item.UnknownItemException("Blank item");
            return outItem;
        }

        public static string ToString(this int ID)
        {
            Item outItem = Item.Items[0];
            foreach (Item i in Item.Items)
                if (i.ID == ID)
                    outItem = i;
            if (outItem.ID == -1)
                throw new Item.UnknownItemException("Blank item");
            return outItem.Name;
        }

        public static int ToInt(this string Name)
        {
            Item outItem = Item.Items[0];
            foreach (Item i in Item.Items)
                if (i.Name == Name)
                    outItem = i;
            if (outItem.ID == -1)
                throw new Item.UnknownItemException("Blank item");
            return outItem.ID;
        }

        public static string Print(this Item item)
        {
            Console.WriteLine($"ITEM:        {item.Name} [ID: {item.ID}]");
            Console.WriteLine($"DESCRIPTION: {item.Description}");
            if (item.Sellable)
                Console.WriteLine($"VALUE:       {item.Price} Ethryl");
            Console.WriteLine(item.Image);
            Console.WriteLine($"ATTRIBUTES:  ");
            foreach (KeyValuePair<string, dynamic> attribute in item.Attributes)
            {
                Console.WriteLine($"{attribute.Key} : {attribute.Value}");
            }
            Console.WriteLine("\n");
            return "";
        }
    }
}
