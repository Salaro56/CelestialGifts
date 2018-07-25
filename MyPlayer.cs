using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace CelestialGifts
{
    public class MyPlayer : ModPlayer
    {
        public bool Loki = false;
        public bool SolidRock = false;

        public override void ResetEffects()
        {
            Loki = false;
            SolidRock = false;
        }
    }
}