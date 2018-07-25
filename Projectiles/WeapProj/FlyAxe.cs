using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialGifts.Projectiles.WeapProj
{
    public class Battlefly_proj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BUTTERFLIES BOIIIIII");
        }
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.aiStyle = 1;
            projectile.thrown = true;
            projectile.penetrate = 2;      //this is how many enemy this projectile penetrate before desapear
            projectile.extraUpdates = 1;
            aiType = ProjectileID.BoneJavelin;
        }

        public override void AI()
        {
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 120f)       //how much time the projectile can travel before landing
            {
                projectile.velocity.Y = projectile.velocity.Y + 0.15f;    // projectile fall velocity
                projectile.velocity.X = projectile.velocity.X * 1f;    // projectile velocity
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {                                                           // sound that the projectile make when hiting the terrain
            {
                projectile.Kill();

                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            }
            return false;
        }
    }
}