using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts;
using System;


namespace CelestialGifts.Projectiles.Pets
{
    public class Loki : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Loki the Bunny"); // Automatic from .lang files
            Main.projFrames[projectile.type] = 8;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Bunny);
            aiType = ProjectileID.Bunny;
            projectile.height = 36;
        }

        public override bool PreAI()
        {
            Player player = Main.player[projectile.owner];
            player.bunny = false; // Relic from aiType
            return true;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
            if (player.dead)
            {
                modPlayer.Loki = false;
            }
            if (modPlayer.Loki)
            {
                projectile.timeLeft = 2;
            }
        }

    }
}