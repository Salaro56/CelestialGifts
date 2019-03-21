using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using CelestialGifts.Dusts;
using Microsoft.Xna.Framework.Graphics;
using CelestialGifts.Projectiles.WeapProj;

namespace CelestialGifts.Projectiles
{
    public class Kings_Wave : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The King's Force");
        }

        public override void SetDefaults()
        {
            projectile.width = 50;
            projectile.height = 70;
            projectile.aiStyle = -1;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.damage = 50;
            projectile.scale = 1;
            projectile.tileCollide = false;
            projectile.alpha = 125;
        }
        public override void AI()
        {
            projectile.ai[0] += 1f;
            if(projectile.ai[0] >= 30f)
                {
                    projectile.Kill();
                }
            projectile.rotation = projectile.velocity.ToRotation();
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire, projectile.velocity.X * 0.25f, projectile.velocity.Y * 0.25f, 80, default(Color), 1.2f);
            int dust2 =Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire, projectile.velocity.X * 0.15f, projectile.velocity.Y * 0.15f, 60, default(Color), 0.7f);
            int dust3 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire, projectile.velocity.X * 0.35f, projectile.velocity.Y * 0.35f, 100, default(Color), 1.2f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust2].noGravity = true;
            Main.dust[dust3].noGravity = true;
        }
        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(projectile.Center, (projectile.velocity * 0), 296, projectile.damage, 5f);
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14); //Bullet noise

        }
    }
}
