using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna;
using Microsoft.Xna.Framework.Graphics;
using CelestialGifts;
using CelestialGifts.Dusts;
using System.Collections.Generic;

namespace CelestialGifts.Projectiles
{
    class Nebula : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nebula Blast");
        }
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.GreenLaser);
            aiType = ProjectileID.ChlorophyteBullet;
            projectile.ranged = true;
            projectile.width = 10;
            projectile.height = 10;
            projectile.timeLeft = 500;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.scale = 1;
            projectile.penetrate = 1;
            projectile.alpha = 330;
        }

        public override void AI()
        {
            projectile.localAI[0] += 1f;
			if (projectile.localAI[0] > 9f)
			{
				for (int i = 0; i < 4; i++)
				{
					Vector2 projectilePosition = projectile.position;
					projectilePosition -= projectile.velocity * ((float)i * 0.25f);
					projectile.alpha = 0;
					// Important, changed 173 to 178!
					int dust = Dust.NewDust(projectilePosition, 1, 1, 173, 0f, 0f, 255, default(Color), 1f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].position = projectilePosition;
					Main.dust[dust].scale = (float)Main.rand.Next(70, 110) * 0.013f;
					Main.dust[dust].velocity *= 0.2f;
				}
			}
            projectile.light = 0.9f;
            if (projectile.alpha > 0)
                {
                    projectile.alpha -= 1;
                }
        }

        public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI)
        {
            base.DrawBehind(index, drawCacheProjsBehindNPCsAndTiles, drawCacheProjsBehindNPCs, drawCacheProjsBehindProjectiles, drawCacheProjsOverWiresUI);
        }

        public override void Kill(int timeLeft)
        {

            Main.PlaySound(2, projectile.Center, 62);    //this make so when this projectile disappear will make this sound. you can find all the sound ID here: https://github.com/bluemagic123/tModLoader/wiki/Vanilla-Sound-IDs

            for (int i = 0; i < 20; i++) //this i a for loop tham make the dust spawn , the higher is the value the more dust will spawn
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType<EtherealFlame>(), projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 120, Color.Green);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                Main.dust[dust].velocity *= 1.5f;
            }
        }

    }
}