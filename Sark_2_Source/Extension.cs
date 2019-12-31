using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Sark_2_Source.ast.Items;

namespace Sark_2_Source
{
    public static class Extension
    {
        /// <summary>
        /// Gets Item from Name
        /// </summary>
        /// <param name="Name">The Name of the Item</param>
        /// <returns>An Item object</returns>
        public static Item ToItem(this string Name)
        {
            Item outItem = IDs.Items[0]; // Setting outItem to G/blank.cs
            foreach (Item i in IDs.Items) // Iterating through all items
                if (i.Name == Name) // If the name matches
                    outItem = i;
            //if (outItem.ID == -1.1f || outItem.ID == -1.2f) // If blank throw error
            //    throw new Item.UnknownItemException("Blank item");
            return outItem; // returning the Item object
        }

        /// <summary>
        /// Gets Item from ID
        /// </summary>
        /// <param name="ID">The ID of the Item</param>
        /// <returns>An Item object</returns>
        public static Item ToItem(this float ID)
        {
            Item outItem = IDs.Items[0]; // Setting outItem to G/blank.cs
            foreach (Item i in IDs.Items) // Iterating through all items
                if (i.ID == ID) // If the name matches
                    outItem = i;
            //if (outItem.ID == -1.1f || outItem.ID == -1.2f) // If blank throw error
            //    throw new Item.UnknownItemException("Blank item");
            return outItem; // returning the Item object
        }

        public static ConsoleColor GetColor(this ConsoleColor Colour)
        {
            Debug.Print(Boolean.Parse(Character.Settings["DarkTheme"]).ToString());
            if (Boolean.Parse(Character.Settings["DarkTheme"]))
                return Colour;
            Dictionary<int, int> Colours = new Dictionary<int, int>()
            {
                { 15, 0 }, { 0, 15 }, { 9, 1 }, { 1, 9 }, { 12, 4 },
                { 4, 12 }, { 10, 2 }, { 2, 10 }, { 14, 6 },{ 6, 14 },
                { 13, 5 }, { 5, 15 }, { 7, 8 }, { 8, 7 }
            };
            return (ConsoleColor)Colours[(int)Colour];
        }

        /// <summary>
        /// Gets the Name of the Item with the inputted ID
        /// </summary>
        /// <param name="ID">The ID of the Item</param>
        /// <returns>The Name of the Item</returns>
        public static string ToString(this float ID) => ID.ToItem().Name;

        /// <summary>
        /// Returns the ID of the Item with the inputed name
        /// </summary>
        /// <param name="Name">Name of item</param>
        /// <returns>The ID of the Item </returns>
        public static float ToInt(this string Name) => Name.ToItem().ID;

        /// <summary>
        /// Prints the information of the Item
        /// </summary>
        /// <param name="item">The Item to print the info</param>
        public static void Print(this Item item)
        {
            Console.WriteLine($"ITEM:        {item.Name} [ID: {item.ID}]");
            Console.WriteLine($"DESCRIPTION: {item.Description}");
            if (item.Sellable)
                Console.WriteLine($"VALUE:       {item.Price} Ethryl");
            Console.WriteLine(item.Image);
            Console.WriteLine($"ATTRIBUTES:  ");
            foreach (KeyValuePair<string, dynamic> attribute in item.Attributes)
                Console.WriteLine($"{attribute.Key} : {attribute.Value}");
            Console.WriteLine("\n");
        }

        /// <summary>
        /// Removes all non Alphanumeric characters
        /// </summary>
        /// <param name="input">The string to remove the characters from</param>
        /// <returns>An only Alphanumeric string</returns>
        public static string ToAlphaNum(this string input) => Regex.Replace(input, "[\\w\\d ]+", "", RegexOptions.Compiled);

        /// <summary>
        /// Shows the Inventory Menu
        /// </summary>
        /// <param name="_Inventory">The characters inventory List</param>
        public static void Menu(this List<Item> _Inventory)
        {
            Item[] Inventory = _Inventory.ToArray();
            while (true)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black.GetColor();
                Console.ForegroundColor = ConsoleColor.White.GetColor();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-= INVENTORY =-=-=-=-=-=-=-=-=-=");
                if (Inventory.Length <= 25)
                {
                    for (int x = 0; x < Inventory.Length; x++)
                    {
                        Console.SetCursorPosition(0, x + 1);
                        Console.ForegroundColor = ConsoleColor.Yellow.GetColor();
                        Debug.Print(ConsoleColor.Yellow.GetColor().ToString());
                        Console.Write($"{x + 1}.");
                        Console.ForegroundColor = ConsoleColor.White.GetColor();
                        Console.SetCursorPosition(4, x + 1);
                        Console.Write($"{Inventory[x].Name}");
                    }
                }

                Console.ReadKey();
            }
        }
    }
}
