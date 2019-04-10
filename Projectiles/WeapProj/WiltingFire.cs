using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialGifts.Projectiles.WeapProj
{
    class WiltingFire : ModProjectile
    {
        public override string Texture {get { return "Terraria/Projectile_" + ProjectileID.BallofFire; } }
        public override void SetStaticDefaults()
        {
        }
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.BallofFire);
            aiType = ProjectileID.BallofFire;
            projectile.magic = true;
            projectile.penetrate = 2;
            projectile.ignoreWater = false;
            projectile.alpha = 180;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //If collide with tile, reduce the penetrate.
            //So the projectile can reflect at most 5 times
            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
            }
            else
            {
                Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
                Main.PlaySound(SoundID.Item10, projectile.position);
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
            }
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if(Main.rand.Next(3) == 0)
            {
                target.AddBuff(BuffID.OnFire, 120);
            }
        }

        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
            for (int d = 1; d < 50; d++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire, projectile.velocity.X * 0.15f, projectile.velocity.Y * 0.15f, 155, default(Color), 1);
                Main.dust[dust].noGravity = false;
                Main.PlaySound(SoundID.Item14);
            }
        }

    }
}
