using CelestialGifts.Dusts;
using CelestialGifts.Projectiles.WeapProj;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialGifts.Projectiles.WeapProj
{

    public class PiercingLight : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "Piercing Light";
            projectile.width = 20;
            projectile.height = 20;
            projectile.timeLeft = 400;
            projectile.penetrate = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.ranged = true;
            projectile.aiStyle = 0;
            projectile.scale = 1;
        }

        public override void AI()
        {
            Player owner = Main.player[projectile.owner]; //Makes a player variable of owner set as the player using the projectile
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
            projectile.light = 0.9f; //Lights up the whole room
            projectile.ai[0] += 1f; // Use a timer to wait 15 ticks before applying gravity.
            if (projectile.ai[0] >= 120f)
            {
                projectile.ai[0] = 120f;
                projectile.velocity.Y = projectile.velocity.Y + 0.1f;
            }
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
            //dust
            for (int i = 0; i < 10; i++)
            {
                int num309 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), 8, 8, mod.DustType<HolyLight>(), projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, Color.Silver, 1.25f);
                Main.dust[num309].velocity *= -0.25f;
                num309 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), 8, 8, 107, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, Color.Silver, 1.25f);
                Main.dust[num309].velocity *= -0.15f;
                Main.dust[num309].position -= projectile.velocity * 0.4f;
            }
        }

        public override void Kill(int timeLeft)
        {
            for(int d = 1; d < 100; d++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X - 10, projectile.position.Y - 25), 50, 50, mod.DustType<EtherealFlame>(), projectile.velocity.X * 0.25f, projectile.velocity.Y * 0.25f, 190, default(Color), 2f);
                Main.dust[dust].noGravity = true;
            }
        }
    }
}
