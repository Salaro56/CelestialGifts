using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace CelestialGifts.Projectiles.WeapProj
{
    class Judgement_1 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Judgement");
        }

        public override void SetDefaults()
        {
            projectile.melee = true;
            projectile.width = 20;
            projectile.height = 8;
            projectile.penetrate = 1;
            projectile.timeLeft = 500;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.friendly = true;
        }

        public override void AI()
        {
            Vector2 target = Main.MouseWorld;
            Vector2 direction = target - projectile.Center;
            direction.Normalize();
            projectile.velocity = (projectile.velocity + direction * 0.5f);

            for (int d = 0; d < 10; d++)
            {
                int dust = Dust.NewDust(projectile.Center, 1, 1, 262, projectile.velocity.X * 0.25f, projectile.velocity.Y * 0.25f, 255, default(Color), 0.7f);
                Main.dust[dust].noGravity = true;
            }
            projectile.rotation = projectile.velocity.ToRotation();
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item14, projectile.position);
            for (int d = 0; d < 100; d++)
            {
                int dust = Dust.NewDust((projectile.position), 50, 50, 262, projectile.velocity.X * 0, projectile.velocity.Y * 0, 55, default(Color), 1);
                int dust2 = Dust.NewDust(new Vector2(projectile.position.X - 16, projectile.position.Y + 16), 90, 10, 262, projectile.velocity.X * 0, projectile.velocity.Y * 0, 55, default(Color), 1);
                int dust3 = Dust.NewDust(new Vector2(projectile.position.X + 16, projectile.position.Y - 16), 10, 90, 262, projectile.velocity.X * 0, projectile.velocity.Y * 0, 55, default(Color), 1);
                Main.dust[dust].noGravity = true;
                Main.dust[dust2].noGravity = true;
                Main.dust[dust3].noGravity = true;
            }
        }
    }
}
