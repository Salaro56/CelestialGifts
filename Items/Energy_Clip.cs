using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Projectiles;

namespace CelestialGifts.Items
{

    public class Energy_Clip : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Energy Clip");
            Tooltip.SetDefault("A gun clip filled with condensed plasma for your shooting pleasure");

        }

        public override void SetDefaults()
        {
            item.damage = 50;
            item.ranged = true;
            item.width = 15;
            item.height = 15;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 1f;
            item.value = 50;
            item.rare = 2;
            item.shoot = mod.ProjectileType<Energy_Shot>();
            item.ammo = mod.ItemType("Energy_Clip");

        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar);
            recipe.AddIngredient(ItemID.MusketBall, 10);
            recipe.SetResult(this, 10);
            recipe.AddRecipe();

        }




    }





}