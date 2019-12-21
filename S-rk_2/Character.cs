using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S_rk_2.ast;

namespace S_rk_2
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
        public static List<item> Inventory = new List<item>();

        /// <summary>
        ///  Dictionary for settings, accessed by setting in []: eg. Character.Settings["SpeechSpeed"]
        /// </summary>
        public static Dictionary<string, dynamic> Settings = new Dictionary<string, dynamic>()
        {
            {"SpeechSpeed", 4},
            {"Profanity", false},
            {"ColourTheme", "dark"},
            {"SpecialEffects", true}
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


    }
}
