using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Projectiles;

namespace CelestialGifts.Items
{
    public class Princes_Rule : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Prince's Rule");
            Tooltip.SetDefault("The heir to the cosmos");
        }
        public override void SetDefaults()
        {
            item.damage = 30;
            item.melee = true;
            item.width = 10;
            item.height = 40;
            item.scale = 1;
            item.useTime = 40;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 10000;
            item.rare = 6;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 20);
            recipe.AddIngredient(ItemID.IronBroadsword);
            recipe.AddIngredient(ItemID.GoldCrown);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
