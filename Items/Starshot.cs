using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Projectiles;

namespace CelestialGifts.Items
{

    public class Starshot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Starshot");
            Tooltip.SetDefault("A bullet made from the core of a star");

        }

        public override void SetDefaults()
        {
            item.damage = 10;
            item.ranged = true;
            item.width = 100;
            item.height = 90;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 1f;
            item.value = 50;
            item.rare = 2;
            item.shoot = mod.ProjectileType<starshot>();
            item.ammo = mod.ItemType("Starshot");
            item.scale = 0.4f;

        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();

        }
   



    }





}