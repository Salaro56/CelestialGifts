using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CelestialGifts;
using Microsoft.Xna.Framework;

namespace CelestialGifts.Projectiles.WeapProj
{
    class HolyFire : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Fire");
        }

        public override void SetDefaults()
        {
            projectile.melee = true;
            projectile.width = 25;
            projectile.height = 25;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.scale = 1;
            projectile.penetrate = 1;
            projectile.friendly = true;
        }

        public override void AI()
        {

            projectile.rotation += 0.8f * (float)projectile.direction;

            projectile.ai[0] += 1f;
            if(projectile.ai[0] >= 32f)
            {
                projectile.ai[0] = 32f;
                projectile.velocity.Y = projectile.velocity.Y + 0.7f;
            }
            if(projectile.velocity.Y > 20f)
            {
                projectile.velocity.Y = 20f;
            }

            for(int d = 0; d < 10; d++)
            {
                int dust = Dust.NewDust(projectile.position, 26, 26, 262, projectile.velocity.X * 0.25f, projectile.velocity.Y * 0.25f, 255, default(Color), 0.7f);
                Main.dust[dust].noGravity = true;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 120);
            for (int d = 0; d < 70; d++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y - 200), 50, 200,262, projectile.velocity.X * 0, projectile.velocity.Y * 0, 55, default(Color), 2);
                int dust2 = Dust.NewDust(new Vector2(projectile.position.X + 18, projectile.position.Y - 400), 20, 200, 262, projectile.velocity.X * 0, projectile.velocity.Y * 0, 55, default(Color), 2);
                Main.dust[dust].noGravity = true;
                Main.dust[dust2].noGravity = true;
            }
            for (int d = 0; d < 4; d++)
            {
                int dust = Dust.NewDust((projectile.position), 50, 50, DustID.Smoke, projectile.velocity.X * 0, projectile.velocity.Y * 0, 100, default(Color), 4);
            }
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
