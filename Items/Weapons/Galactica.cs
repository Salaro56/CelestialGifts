using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Projectiles.WeapProj;

namespace CelestialGifts.Items.Weapons
{
    public class Galactica : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Celestial Embrace");
            Tooltip.SetDefault("Supreme power of the stars");
        }
        public override void SetDefaults()
        {
            item.damage = 130;
            item.melee = true;
            item.width = 90;
            item.height = 90;
            item.scale = 1f;
            item.useTime = 100;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 10000;
            item.rare = 6;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Judgement>();
            item.shootSpeed = 5f;
            item.crit = 5;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentSolar, 25);
            recipe.AddIngredient(ModContent.ItemType<Divine_Domain>());
            recipe.AddIngredient(ItemID.GoldCrown);
            recipe.AddIngredient(ItemID.TrueExcalibur);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
