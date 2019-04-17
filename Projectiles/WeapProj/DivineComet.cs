using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Dusts;

namespace CelestialGifts.Projectiles.WeapProj
{
    public class DivineComet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divine Comet");
        }
        public override void SetDefaults()
        {
            projectile.CloneDefaults(503);
            aiType = 503;
            projectile.magic = true;
            projectile.width = 60;
            projectile.height = 60;
            projectile.timeLeft = 500;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.scale = 1.5f;
            projectile.penetrate = 1;
        }


        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 20; i++) //this i a for loop tham make the dust spawn , the higher is the value the more dust will spawn
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.SolarFlare, projectile.velocity.X * 0.25f, projectile.velocity.Y * 0.25f, 120, default(Color), 2.50f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                Main.dust[dust].velocity *= -1f;
            }
            int rand = Main.rand.Next(5); //Generates integers from 0 to 4
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 9); //Bullet noise
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
        }
    }
}
