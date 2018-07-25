using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CelestialGifts.Dusts
{
    public class DivineSpark : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity.Y = Main.rand.Next(-10, 6) * -1f;
            dust.velocity.X *= 0.3f;
            dust.scale *= 1;
        }

        public override bool MidUpdate(Dust dust)
        {
            if (!dust.noGravity)
            {
                dust.velocity.Y += 0.1f;
            }
            if (!dust.noLight)
            {
                float strength = dust.scale * 1f;
                if (strength > 1f)
                {
                    strength = 2f;
                }
                Lighting.AddLight(dust.position, 0.1f * strength, 0.2f * strength, 0.7f * strength);
            }
            return false;
        }

        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            return new Color(lightColor.R, lightColor.G, lightColor.B, 25);
        }
    }
}