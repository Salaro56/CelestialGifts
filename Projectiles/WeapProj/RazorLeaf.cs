using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using CelestialGifts.Dusts;

namespace CelestialGifts.Projectiles.WeapProj
{
    class RazorLeaf : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Razor Leaf");
        }

        public override void SetDefaults()
        {
            projectile.melee = true;
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = true;
            projectile.scale = 0f;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] > 9f)
            {
                for (int i = 0; i < 2; i++)
                {
                    Vector2 projectilePosition = projectile.position;
                    projectilePosition -= projectile.velocity * ((float)i * 0.25f);
                    projectile.alpha = 0;
                    int dust = Dust.NewDust(projectilePosition, 1, 1, 163, 0f, 0f, 255, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].position = projectilePosition;
                    Main.dust[dust].scale = (float)Main.rand.Next(70, 110) * 0.025f;
                    Main.dust[dust].velocity *= 0.2f;
                }
            }
            projectile.light = 0.9f;
            if (projectile.alpha > 0)
            {
                projectile.alpha -= 1;
            }

        }
        public override void Kill(int timeLeft)
        {

            Main.PlaySound(2, projectile.Center, 10);    //this make so when this projectile disappear will make this sound. you can find all the sound ID here: https://github.com/bluemagic123/tModLoader/wiki/Vanilla-Sound-IDs

            for (int i = 0; i < 100; i++) //this i a for loop tham make the dust spawn , the higher is the value the more dust will spawn
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 163, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 120, Color.Green);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                Main.dust[dust].velocity *= -0.8f;
            }
        }
    }
}
