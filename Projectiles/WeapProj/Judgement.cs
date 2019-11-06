using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;

namespace CelestialGifts.Projectiles.WeapProj
{
    class Judgement : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Judgement");
        }

        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            projectile.melee = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = false;
            projectile.timeLeft = 120;
            projectile.penetrate = 1;
            projectile.friendly = true;
        }

        public override void AI()
        {
            for (int d = 0; d < 10; d++)
            {
                int dust = Dust.NewDust(projectile.position, 26, 26, 262, projectile.velocity.X * 0.25f, projectile.velocity.Y * 0.25f, 255, default(Color), 0.7f);
                Main.dust[dust].noGravity = true;
            }

            projectile.velocity.Y = projectile.velocity.Y + 0.1f; // 0.1f for arrow gravity, 0.4f for knife gravity
            if (projectile.velocity.Y > 16f) // This check implements "terminal velocity". We don't want the projectile to keep getting faster and faster. Past 16f this projectile will travel through blocks, so this check is useful.
            {
                projectile.velocity.Y = 16f;
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 3; i++)
            {
                // Calculate new speeds for other projectiles.
                // Rebound at 40% to 70% speed, plus a random amount between -8 and 8
                float speedX = -projectile.velocity.X * Main.rand.NextFloat(.4f, .7f) + Main.rand.NextFloat(-8f, 8f);
                float speedY = -projectile.velocity.Y * Main.rand.Next(40, 70) * 0.01f + Main.rand.Next(-20, 21) * 0.4f; // This is Vanilla code, a little more obscure.
                                                                                                                         // Spawn the Projectile.
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y + speedY, speedX, speedY, ModContent.ProjectileType<Judgement_1>(), (int)(projectile.damage * 0.8), 0f, projectile.owner, 0f, 0f);
            }

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
