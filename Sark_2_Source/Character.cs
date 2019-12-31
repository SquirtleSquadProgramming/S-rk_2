using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sark_2_Source.ast;
using Sark_2_Source.ast.Items;
using System.IO;
using System.Diagnostics;
using Sark_2_Source;

namespace Sark_2_Source
{
    public static class Character
    {
        /// <summary>
        /// Integer dictionary
        /// </summary>
        public static Dictionary<string, int> intDict = new Dictionary<string, int>()
        {
            {"story", 0}, // What stage of the story the user is at
            {"ethryl", 0}, // How much ethryl they have
            {"abilityPoints", 0}, // How many abilityPoints the have
            
            // Health levels
            {"maxHealth", 0}, // x/maxHealth hp
            {"health", 0}, // health/x hp

            // XP level
            {"currentXP", 0}, // How much XP they have
            {"maxXP", 0}, // maxXP until the next level
            {"level", 0}, // The level the player is at

            // Magika levels (same concept as health)
            {"maxMagika", 0},
            {"magika", 0}
        };

        /// <summary>
        /// String Dictionary
        /// </summary>
        public static Dictionary<string, string> strDict = new Dictionary<string, string>()
        {
            {"name", ""}, // Character's name
            {"class", ""} //             class
        };

        /// <summary>
        /// List for Inventory
        /// </summary>
        public static List<Item> Inventory = new List<Item>();

        /// <summary>
        ///  Dictionary for settings, accessed by setting in []: eg. Character.Settings["SpeechSpeed"]
        /// </summary>
        public static Dictionary<string, string> Settings = new Dictionary<string, string>()
        {
            {"SpeechSpeed", "4"},
            {"Profanity", "false"},
            {"DarkTheme", "true"},
            {"SpecialEffects", "true"}
        };

        /// <summary>
        /// Ability scores dictionary (modifer) [from -5 to 5]
        /// </summary>
        public static Dictionary<string, int> AbilityScores = new Dictionary<string, int>()
        {
            {"constitution", 0},
            {"charisma", 0 },
            {"intelligence", 0 },
            {"perception", 0 },
            {"strength", 0 },
            {"stealth", 0 },
        };

        public static void SaveCharacter()
        {
            string Output = "";
            foreach (KeyValuePair<string, int> entry in intDict)
                Output += String.Format("'{0}':'{1}',", entry.Key, entry.Value);
            Output = Output.Substring(0, Output.Length - 1) + "§";
            foreach (KeyValuePair<string, string> entry in strDict)
                Output += String.Format("'{0}':'{1}',", entry.Key, entry.Value);
            Output = Output.Substring(0, Output.Length - 1) + "§";
            foreach (KeyValuePair<string, string> entry in Settings)
                Output += String.Format("'{0}':'{1}',", entry.Key, entry.Value);
            Output = Output.Substring(0, Output.Length - 1) + "§";
            foreach (KeyValuePair<string, int> entry in AbilityScores)
                Output += String.Format("'{0}':'{1}',", entry.Key, entry.Value);
            Output = Output.Substring(0, Output.Length - 1) + "§";
            foreach (Item item in Inventory)
                Output += "'" + item.ID.ToString() + "',";
            string fileURL = Environment.CurrentDirectory + "\\" + strDict["name"] + ".save";
            File.WriteAllText(fileURL, Output.Substring(0, Output.Length - 1));
        }

        public static void LoadCharacter(string nameOrPath)
        {
            if (!nameOrPath.Contains(".save"))
                nameOrPath = Environment.CurrentDirectory + "\\" + nameOrPath + ".save";
            string[] data = File.ReadAllText(nameOrPath).Split('§');
            string[][] data1 = new string[5][];
            for (int i = 0; i < data.Length; i++)
                data1[i] = data[i].Split(',');
            foreach (string x in data1[0])
                intDict[x.Split(':')[0].Replace("\'", "")] = Int32.Parse(x.Split(':')[1].Replace("\'", ""));
            foreach (string x in data1[1])
                strDict[x.Split(':')[0].Replace("\'", "")] = x.Split(':')[1].Replace("\'", "");
            foreach (string x in data1[2])
                Settings[x.Split(':')[0].Replace("\'", "")] = x.Split(':')[1].Replace("\'", "");
            foreach (string x in data1[3])
                AbilityScores[x.Split(':')[0].Replace("\'", "")] = Int32.Parse(x.Split(':')[1].Replace("\'", ""));
            foreach (string x in data1[4])
                Inventory.Add(float.Parse(x.Replace("'", "")).ToItem());
        }
    }
}
