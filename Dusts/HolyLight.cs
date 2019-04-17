using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace CelestialGifts.Dusts
{
    class HolyLight : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity.Y = Main.rand.Next(-6, 6) * 0.25f;
            dust.velocity.X *= 0.25f;
            dust.scale *= 0.7f;
            dust.noGravity = true;
        }

        public override bool MidUpdate(Dust dust)
        {
            if (!dust.noGravity)
            {
                dust.velocity.Y += 0.05f;
            }
            if (!dust.noLight)
            {
                float strength = dust.scale * 1f;
                if (strength > 1f)
                {
                    strength = 1f;
                }
                Lighting.AddLight(dust.position, 0.1f * strength, 0.2f * strength, 0.7f * strength);
            }
            return false;
        }

        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            return new Color(255, 255, 255, 10);
        }
    }
}
