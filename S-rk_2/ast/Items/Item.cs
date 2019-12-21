using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using S_rk_2.ast.Items.General;

namespace S_rk_2.ast.Items
{
    public class Item
    {
        public bool Sellable { get; set; }
        public int ID { get; set; }
        public int Price { get; set; }
        public string Name { get; set; } // CANNOT EXCEDE 20 CHARACTERS
        public string Description { get; set; }
        public string Image { get; set; }
        public Dictionary<string, dynamic> Attributes { get; set; }

        public Item(bool Sellable_, int _ID, int _Price, string _Name, string _Description, string _Image, Dictionary<string, dynamic> _Attributes)
        {
            if (_Name.Length > 20)
                throw new LengthException($"Exception with item name's length as it excedes the maximum of 20 characters. Name: {_Name} || ID: {_ID}");

            Sellable = Sellable_;
            ID = _ID;
            Price = _Price;
            Name = _Name;
            Description = _Description;
            Image = _Image;
            Attributes = _Attributes;
        }

        public static void showItemInfoGUI(Item item)
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
        }

        public static List<Item> Items = new List<Item>()
        {
            blank.ToItem()
        };

        #region Exception Stuff
        [Serializable]
        public class UnknownItemException : Exception
        {
            public UnknownItemException() { }
            public UnknownItemException(string Message) { }
            public UnknownItemException(string Message, Exception inner) { }
            protected UnknownItemException(SerializationInfo info, StreamingContext context) { }
        }

        [Serializable]
        private class LengthException : Exception
        {
            public LengthException() { }
            public LengthException(string message) { }
            public LengthException(string message, Exception innerException) { }
            protected LengthException(SerializationInfo info, StreamingContext context) { }
        }
        #endregion
    }
}
