using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialGifts.Projectiles.WeapProj
{
    class GalacticaStarBoi : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            
        }

        public override void SetDefaults()
        {
            projectile.damage = 90;
            projectile.melee = true;
            projectile.penetrate = 1;
            projectile.width = 20;
            projectile.height = 20;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.timeLeft = 25;
            projectile.friendly = true;
        }

        public override void AI()
        {
            projectile.rotation += 0.4f * (float)projectile.direction;
            projectile.light = 0.9f;
            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] > 3f)
            {
                projectile.alpha = 0;
            }
            if (projectile.ai[0] >= 20f)
            {
                projectile.ai[0] = 20f;
                projectile.velocity.Y += 0.055f;
            }
            if (Main.myPlayer == projectile.owner)
            {
                if (projectile.ai[1] >= 0f)
                {
                    projectile.penetrate =1;
                }
                else if (projectile.penetrate < 2)
                {
                    projectile.penetrate = 3;
                }
                if (projectile.ai[1] >= 0f)
                {
                    projectile.ai[1] += 1f;
                }
                if (projectile.ai[1] > (float)Main.rand.Next(5, 10))
                {
                    projectile.ai[1] = -1000f;
                    float scaleFactor4 = projectile.velocity.Length();
                    Vector2 velocity = projectile.velocity;
                    velocity.Normalize();
                    int num161 = Main.rand.Next(1, 3);
                    for (int num162 = 0; num162 < num161; num162++)
                    {
                        Vector2 vector12 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                        vector12.Normalize();
                        vector12 += velocity * 2f;
                        vector12.Normalize();
                        vector12 *= scaleFactor4;
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector12.X, vector12.Y, projectile.type, projectile.damage, projectile.knockBack, projectile.owner, 0f, -1000f);
                    }
                }
            }
        }
        
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                // Calculate new speeds for other projectiles.
                // Rebound at 40% to 70% speed, plus a random amount between -8 and 8
                float speedX = -projectile.velocity.X * Main.rand.NextFloat(.1f, .7f) + Main.rand.NextFloat(-10f, 4f);
                float speedY = -projectile.velocity.Y * Main.rand.Next(5, 10) * 0.01f + Main.rand.Next(-10, 10) * 0.4f; // This is Vanilla code, a little more obscure.
                                                                                                                         // Spawn the Projectile.
                Projectile.NewProjectile(projectile.position.X + speedX, projectile.position.Y + speedY, speedX, speedY, mod.ProjectileType<HolyFire>(), (int)(projectile.damage * 0.5), 0f, projectile.owner, 0f, 0f);
            }
        }
    }
}
