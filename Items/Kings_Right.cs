using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Projectiles;

namespace CelestialGifts.Items
{
    public class Kings_Right : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The King's Right");
            Tooltip.SetDefault("The sky is yours");
        }
        public override void SetDefaults()
        {
            item.damage = 80;
            item.melee = true;
            item.width = 10;
            item.height = 70;
            item.scale = 1;
            item.useTime = 30;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 10000;
            item.rare = 6;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType<Kings_Wave>();
            item.shootSpeed = 50f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 20);
            recipe.AddIngredient(mod.ItemType<Princes_Rule>());
            recipe.AddIngredient(ItemID.GoldCrown);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
