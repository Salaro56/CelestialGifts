using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using CelestialGifts.Projectiles.WeapProj;

namespace CelestialGifts.Projectiles.Minions
{
    class MrSmiley : HoverShooter
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 1;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true; //This is necessary for right-click targeting
        }

        public override void SetDefaults()
        {
            projectile.netImportant = true; //For multiplayer use
            projectile.width = 24;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = 1;
            projectile.penetrate = -1;
            projectile.timeLeft = 18000;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            inertia = 20f;
            shoot = ProjectileID.ScutlixLaserFriendly;
            shootSpeed = 12f;
        }
        public override void CheckActive()
        {
            Player player = Main.player[projectile.owner];
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
            if (player.dead)
            {
                modPlayer.MrSmiles = false;
            }
            if (modPlayer.MrSmiles)
            { // Make sure you are resetting this bool in ModPlayer.ResetEffects. See ExamplePlayer.ResetEffects
                projectile.timeLeft = 2;
            }
        }

        public override void CreateDust()
        {
            if (projectile.ai[0] == 0f)
            {
                if (Main.rand.NextBool(5))
                {
                    int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height / 2, DustID.Fire);
                    Main.dust[dust].velocity.Y -= 1.2f;
                    Main.dust[dust].noGravity = true;
                }
            }
            else
            {
                if (Main.rand.NextBool(3))
                {
                    Vector2 dustVel = projectile.velocity;
                    if (dustVel != Vector2.Zero)
                    {
                        dustVel.Normalize();
                    }
                    int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire);
                    Main.dust[dust].velocity -= 1.2f * dustVel;
                    Main.dust[dust].noGravity = true;
                }
            }
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.6f, 0.9f, 0.3f);
        }

        //public override void SelectFrame()
        //{
            //projectile.frameCounter++;
            //if (projectile.frameCounter >= 8)
            //{
                //projectile.frameCounter = 0;
               // projectile.frame = (projectile.frame + 1) % 3;
            //}
        //}
    }
}
