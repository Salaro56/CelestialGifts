using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Generation;
using Terraria.World.Generation;
using System.Collections.Generic;

using System;
using Terraria.ModLoader.IO;
using System.IO;
using CelestialGifts.Items.Weapons.Melee.Yoyo;

namespace WillsWorld
{
    public class WillsWorld : ModWorld
    {
        public static int biomeTiles = 0;
        // Stuff added with the Boss
        public static bool downedPain = false; // Downed Tutorial Boss
        public static int questsLeft;

        public override void Initialize()
        {
            downedPain = false;
            questsLeft = 10;
        }

        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (downedPain) downed.Add("tutorial");

            return new TagCompound
            {
                {"downed", downed },
                {"questsLeft", questsLeft }
            };
        }

        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedPain = downed.Contains("tutorial");
            if (tag.ContainsKey("questsLeft"))
                questsLeft = tag.GetInt("questsLeft");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if (loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();
                downedPain = flags[0];
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedPain;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedPain = flags[0];
        }

        public override void PostWorldGen()
        {
            // Place some items in Ice Chests

            int[] itemsToPlaceInChests = { ModContent.ItemType<EnchantedYoyo>() };
            int itemsToPlaceInChestsChoice = 0;
            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                // If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Ice Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. 
                if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 1 * 36 && Main.rand.Next(5) == 1)
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == 0)
                        {
                            chest.item[inventoryIndex].SetDefaults(itemsToPlaceInChests[itemsToPlaceInChestsChoice]);
                            itemsToPlaceInChestsChoice = (itemsToPlaceInChestsChoice + 1) % itemsToPlaceInChests.Length;
                            // Alternate approach: Random instead of cyclical: chest.item[inventoryIndex].SetDefaults(Main.rand.Next(itemsToPlaceInIceChests));
                            break;
                        }
                    }
                }
            }
        }

    }
}