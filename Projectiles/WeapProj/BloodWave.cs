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
    class BloodWave : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Wave");
            Main.projFrames[projectile.type] = 28;
        }
        public override void SetDefaults()
        {
            projectile.width = 68;
            projectile.height = 64;
            projectile.melee = true;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 180;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation();
            int timer = 0;
            timer += 1;
            if(timer <= 60)
            {
                if (projectile.velocity.X < 25f)
                {
                    projectile.velocity = projectile.velocity * 1.2f;
                }
                else if (projectile.velocity.X > 25f)
                {
                    projectile.velocity.X = 25f;
                }
            }

            if (++projectile.frameCounter >= 1)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 28)
                {
                    projectile.frame = 0;
                }
            }
        }
    }
}
