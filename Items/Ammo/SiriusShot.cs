using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Projectiles.WeapProj;

namespace CelestialGifts.Items.Ammo
{

    public class SiriusShot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Piercing Light");
            Tooltip.SetDefault("Light of the Divines");

        }

        public override void SetDefaults()
        {
            item.damage = 200;
            item.ranged = true;
            item.width = 36;
            item.height = 10;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 1f;
            item.value = 10000;
            item.rare = 6;
            item.ammo = AmmoID.Arrow;
            item.shoot = mod.ProjectileType<siriusShot>();
            item.scale = 0.5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentSolar, 5);
            recipe.AddIngredient(ItemID.FragmentVortex, 5);
            recipe.AddIngredient(ItemID.FragmentNebula, 5);
            recipe.AddIngredient(ItemID.FragmentStardust, 5);
        }

    }





}