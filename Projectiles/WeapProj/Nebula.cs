using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna;
using Microsoft.Xna.Framework.Graphics;
using CelestialGifts;
using CelestialGifts.Dusts;
using System.Collections.Generic;
using System;

namespace CelestialGifts.Projectiles.WeapProj
{
    class Nebula : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nebula Blast");
        }
        public override void SetDefaults()
        {
            projectile.aiStyle = 0;
            projectile.ranged = true;
            projectile.width = 3;
            projectile.height = 29;
            projectile.timeLeft = 500;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.scale = 1;
            projectile.penetrate = 1;
            projectile.alpha = 0;
            projectile.damage = 15;
            projectile.friendly = true;
        }

        /*public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;

            projectile.localAI[0] += 1f;
			if (projectile.localAI[0] > 5f)
			{
                projectile.localAI[0] = 0f;
				for (int i = 0; i < 15; i++)
				{
					// Important, changed 173 to 178!
					int dust = Dust.NewDust(projectile.Center, 1, 1, 107, 0f, 0f, 255, default(Color), 1f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].position = projectile.Center;
					Main.dust[dust].scale = 0.5f;
					Main.dust[dust].velocity *= 0.2f;
				}
			}
            projectile.light = 0.9f;
        }*/


        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;

            float num277 = (float)Math.Sqrt((double)(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y));
            float num276 = projectile.localAI[0];
            if (num276 == 0f)
            {
                projectile.localAI[0] = num277;
                num276 = num277;
            }
            float num275 = projectile.position.X;
            float num274 = projectile.position.Y;
            float num273 = 300f;
            bool flag7 = false;
            int num272 = 0;
            if (projectile.ai[1] == 0f)
            {
                for (int num271 = 0; num271 < 200; num271++)
                {
                    if (Main.npc[num271].CanBeChasedBy(this, false) && (projectile.ai[1] == 0f || projectile.ai[1] == (float)(num271 + 1)))
                    {
                        float num270 = Main.npc[num271].position.X + (float)(Main.npc[num271].width / 2);
                        float num269 = Main.npc[num271].position.Y + (float)(Main.npc[num271].height / 2);
                        float num268 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num270) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num269);
                        if (num268 < num273 && Collision.CanHit(new Vector2(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2)), 1, 1, Main.npc[num271].position, Main.npc[num271].width, Main.npc[num271].height))
                        {
                            num273 = num268;
                            num275 = num270;
                            num274 = num269;
                            flag7 = true;
                            num272 = num271;
                        }
                    }
                }
                if (flag7)
                {
                    projectile.ai[1] = (float)(num272 + 1);
                }
                flag7 = false;
            }
            if (projectile.ai[1] > 0f)
            {
                int num267 = (int)(projectile.ai[1] - 1f);
                if (Main.npc[num267].active && Main.npc[num267].CanBeChasedBy(this, true) && !Main.npc[num267].dontTakeDamage)
                {
                    float num266 = Main.npc[num267].position.X + (float)(Main.npc[num267].width / 2);
                    float num265 = Main.npc[num267].position.Y + (float)(Main.npc[num267].height / 2);
                    if (Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num266) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num265) < 1000f)
                    {
                        flag7 = true;
                        num275 = Main.npc[num267].position.X + (float)(Main.npc[num267].width / 2);
                        num274 = Main.npc[num267].position.Y + (float)(Main.npc[num267].height / 2);
                    }
                }
                else
                {
                    projectile.ai[1] = 0f;
                }
            }
            if (!projectile.friendly)
            {
                flag7 = false;
            }
            if (flag7)
            {
                float num444 = num276;
                Vector2 vector7 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                float num264 = num275 - vector7.X;
                float num263 = num274 - vector7.Y;
                float num262 = (float)Math.Sqrt((double)(num264 * num264 + num263 * num263));
                num262 = num444 / num262;
                num264 *= num262;
                num263 *= num262;
                int num258 = 8;
                projectile.velocity.X = (projectile.velocity.X * (float)(num258 - 1) + num264) / (float)num258;
                projectile.velocity.Y = (projectile.velocity.Y * (float)(num258 - 1) + num263) / (float)num258;
            }
        }

        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(2, projectile.Center, 62);    //this make so when this projectile disappear will make this sound. you can find all the sound ID here: https://github.com/bluemagic123/tModLoader/wiki/Vanilla-Sound-IDs
        }

    }
}