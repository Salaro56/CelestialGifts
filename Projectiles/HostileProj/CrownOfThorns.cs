using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CelestialGifts.Dusts;
using Microsoft.Xna.Framework;

namespace CelestialGifts.Projectiles.HostileProj
{
    class CrownOfThorns : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crown of Thorns");
            Main.projFrames[projectile.type] = 1;
            projectile.tileCollide = true;
        }

        public override void SetDefaults()
        {
            projectile.aiStyle = -1;
            projectile.width = 20;
            projectile.height = 20;
            projectile.hostile = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 500;
            projectile.scale = 2f;
            projectile.damage = 20;
            drawOriginOffsetX = 10;
            drawOriginOffsetY = 10;
        }

        public override void AI()
        {
            for(int i = 0; i < 10; i++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X - 20, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType<HolyLight>(), projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 1f);
                Main.dust[dust].noGravity = true;
            }
            projectile.rotation += 0.4f * (float)projectile.direction; 
        }
    }
}
