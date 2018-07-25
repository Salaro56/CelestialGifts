using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts;
using System;

namespace CelestialGifts.Projectiles.Pets
{
    public class SolidRock : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rock Solid"); // Automatic from .lang files
            Main.projFrames[projectile.type] = 7;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.ZephyrFish);
            aiType = ProjectileID.ZephyrFish;
        }

        public override bool PreAI()
        {
            Player player = Main.player[projectile.owner];
            player.zephyrfish = false; // Relic from aiType
            return true;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
            if (player.dead)
            {
                modPlayer.SolidRock = false;
            }
            if (modPlayer.SolidRock)
            {
                projectile.timeLeft = 2;
            }
        }
    }
}