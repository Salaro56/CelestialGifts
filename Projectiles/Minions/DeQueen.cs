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
    class DeQueen : HoverShooter
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 8;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true; //This is necessary for right-click targeting
        }

        public override void SetDefaults()
        {
            projectile.netImportant = true; //For multiplayer use
            projectile.width = 82;
            projectile.height = 82;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.scale = 0.5f;
            projectile.minionSlots = 2;
            projectile.penetrate = -1;
            projectile.timeLeft = 18000;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            inertia = 30f;
            shoot = ProjectileID.HornetStinger;
            shootSpeed = 10f;
        }
        public override void CheckActive()
        {
            Player player = Main.player[projectile.owner];
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
            if (player.dead)
            {
                modPlayer.DQueen = false;
            }
            if (modPlayer.DQueen)
            { // Make sure you are resetting this bool in ModPlayer.ResetEffects. See ExamplePlayer.ResetEffects
                projectile.timeLeft = 2;
            }
        }
        public override void SelectFrame()
        {
        projectile.frameCounter++;
        if (projectile.frameCounter >= 8)
        {
        projectile.frameCounter = 0;
        projectile.frame = (projectile.frame + 1) % 3;
        }
        }
    }
}
