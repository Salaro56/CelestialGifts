using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace CelestialGifts.Items.Weapons.Range
{
    class BassCannon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bass Cannon");
            Tooltip.SetDefault("This isn't what I thought it would be... " +
                "\nUses Bass as ammo");
        }

        public override void SetDefaults()
        {
            //stats
            item.damage = 26;
            item.knockBack = 1.2f;
            item.shoot = ProjectileType<BassProj>();
            item.crit = 13;
            item.useTime = 13;
            item.useAnimation = 13;
            item.shootSpeed = 17f;
            //configs
            item.ranged = true;
            item.autoReuse = false;
            item.useAmmo = ItemID.Bass;
            item.noMelee = true;
            item.useStyle = 5;
            item.UseSound = SoundID.DD2_BetsyFireballImpact;
            item.width = 50;
            item.height = 50;
        }
    }

    public class BassProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bass Cannon");
        }
        public override void SetDefaults()
        {
            projectile.damage = 26;
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.width = 18;
            projectile.height = 31;
            projectile.aiStyle = 1;
            projectile.tileCollide = true;
            projectile.penetrate = 1;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;

            for(int i = 0; i < 4; i++)
            {
                Dust.NewDust(projectile.Center, 1, 1, DustID.Fire, projectile.velocity.X, projectile.velocity.Y);
            }
        }

        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Smoke, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, default(Color), 2f);
            }
            for (int i = 0; i < 100; i++)
            {
                Dust.NewDust(projectile.position, 20, 20, DustID.Blood, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.7f, 0, default(Color), 0.7f);
            }
        }
    }

    public class BassAmmo : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if(item.type == ItemID.Bass)
            {
                item.ammo = ItemID.Bass;
                item.shoot = ProjectileType<BassProj>();
                item.consumable = true;
            }
        }
    }
}
