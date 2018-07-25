using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Projectiles;

namespace CelestialGifts.Items
{
    public class Heavenly_Body : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Heavenly Body");
            Tooltip.SetDefault(" 'It's a space needle' ");
        }
        public override void SetDefaults()
        {
            item.damage = 700;
            item.width = 100;
            item.height = 100;
            item.scale = 1;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 3;
            item.knockBack = 5f;
            item.value = Item.buyPrice(10, 0, 0, 0);
            item.rare = 12;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.scale = 1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddIngredient(ItemID.FragmentSolar, 15);
            recipe.AddIngredient(mod.ItemType<One_Above_All>());
            recipe.AddIngredient(mod.ItemType<SwordoftheDivine>());
            recipe.AddIngredient(ItemID.GoldCrown);
            recipe.AddIngredient(ItemID.TrueExcalibur);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
