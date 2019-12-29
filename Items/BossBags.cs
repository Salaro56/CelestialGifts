using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CelestialGifts.Items.Weapons;
using CelestialGifts.Items.Armour;
using static Terraria.ModLoader.ModContent;

namespace CelestialGifts.Items
{
    public class  BossBags : GlobalItem 
    {
        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (arg == ItemID.MoonLordBossBag && Main.rand.Next(10) == 1) 
            {
                player.QuickSpawnItem(ItemType<yoyoCopJustice>());
                player.QuickSpawnItem(ItemType<YoyoCopHat>());
                player.QuickSpawnItem(ItemType<YoyoCopChestpiece>());
                player.QuickSpawnItem(ItemType<YoyoCopLeggings>());
            }
        }
    }
}
