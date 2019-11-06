using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Projectiles;
using CelestialGifts.Projectiles.WeapProj;

namespace CelestialGifts.Items.Ammo
{

    public class ChloroClip : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chloro Clip");
            Tooltip.SetDefault("A strange green energy emits from this energy clip");

        }

        public override void SetDefaults()
        {
            item.damage = 30;
            item.ranged = true;
            item.width = 15;
            item.height = 15;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 1f;
            item.value = 50;
            item.rare = 2;
            item.shoot = ModContent.ProjectileType<Nebula>();
            item.ammo = mod.ItemType("Energy_Clip");

        }


        public override void AddRecipes()
        {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<Energy_Clip>());
                recipe.AddIngredient(ItemID.ChlorophyteBullet, 5);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(this, 15);
                recipe.AddRecipe();
        }




    }





}