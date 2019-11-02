using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

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
    }
}