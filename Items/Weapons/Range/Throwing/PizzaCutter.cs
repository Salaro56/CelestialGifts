using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace CelestialGifts.Items.Weapons.Range.Throwing
{
    class PizzaCutter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pizza Cutter");
            Tooltip.SetDefault("The pen is mightier than the sword, the pizza cutter is mightier than the pen.");
        }

        public override void SetDefaults()
        {
            //stats
            item.damage = 23;
            item.knockBack = 1.1f;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 1;
            item.rare = 2;
            item.shoot = ModContent.ProjectileType<PizzaBlade>();
            item.shootSpeed = 13f;
            //configs
            item.width = 31;
            item.height = 32;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = false;
            item.consumable = false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.EnchantedBoomerang);
            recipe.AddIngredient(ItemID.EnchantedSword);
            recipe.AddRecipeGroup("IronBar", 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    class PizzaBlade : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pizza Cutter");
        }
        public override void SetDefaults()
        {
            projectile.damage = 23;
            projectile.width = 18;
            projectile.height = 40;
            projectile.penetrate = -1;
            projectile.aiStyle = 3;
            projectile.thrown = true;
            projectile.friendly = true;
            aiType = ProjectileID.Bananarang;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {                                                           // sound that the projectile make when hiting the terrain
            {
                Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            }
            return false;
        }
    }
}
