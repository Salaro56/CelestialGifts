using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialGifts.Items.Weapons.Range
{
    class Rogue_Special : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rogue Special");
            Tooltip.SetDefault("Wait, what is this doing here?");
        }

        public override void SetDefaults()
        {
            //item stats
            item.ranged = true;
            item.damage = 12;
            item.knockBack = 0.3f;
            item.useTime = 15;
            item.useAnimation = 15;
            item.shootSpeed = 10f;
            //item configs
            item.width = 28;
            item.height = 24;
            item.maxStack = 1;
            item.autoReuse = false;
            item.noMelee = true;
            item.useStyle = 5;
            item.value = Item.buyPrice(0, 0, 50, 0);
            item.rare = 1;
            item.UseSound = SoundID.Item12;
            item.shoot = ModContent.ProjectileType<RogueBullet>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldCoin, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }    
    class RogueBullet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rogue Special");
        }
        public override void SetDefaults()
        {
            //projectile stats
            projectile.damage = 15;
            projectile.penetrate = 1;
            projectile.ranged = true;
            //projectile configs
            projectile.width = 20;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.aiStyle = 0;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation();
        }

        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(projectile.Center + new Vector2(10,10), Vector2.Zero, ModContent.ProjectileType<RogueCollide>(), projectile.damage, 0f, projectile.owner);
            Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
        }
    }

    class RogueCollide : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rogue Special");
            Main.projFrames[projectile.type] = 6;
        }
        public override void SetDefaults()
        {
            //stats
            projectile.damage = 15;
            projectile.penetrate = -1;
            projectile.ranged = true;
            //configs
            projectile.width = 26;
            projectile.height = 26;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.aiStyle = 0;
            projectile.timeLeft = 6;
            projectile.scale = 1.5f;
        }

        public override void AI()
        {
            if (++projectile.frameCounter >= 1)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 6)
                {
                    projectile.frame = 0;
                }
            }
        }
    }

}
