using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using CelestialGifts.Items.Weapons.Range;

namespace CelestialGifts
{
    public class MyPlayer : ModPlayer
    {
        public bool Loki = false;
        public bool SolidRock = false;
        public bool MrSmiles = false;
        public bool SlimePet = false;
        public bool DQueen = false;
        public override void ResetEffects()
        {
            Loki = false;
            SolidRock = false;
            MrSmiles = false;
            SlimePet = false;
            DQueen = false;
        }

        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            if(junk)
            {
                return;
            }
            if(player.ZoneBeach && liquidType == 0 && Main.rand.Next(25) == 1)
            {
                caughtType = ModContent.ItemType<BassCannon>();
            }
        }
    }
}