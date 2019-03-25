using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Items;
using CelestialGifts.Projectiles;

namespace CelestialGifts.Items
{
    public class Kings_Right : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("King's Right");
            Tooltip.SetDefault("Everything the sun touches is your domain");
        }
        public override void SetDefaults()
        {
            item.damage = 50;
            item.melee = true;
            item.width = 70;
            item.height = 70;
            item.scale = 0.7f;
            item.useTime = 60;
            item.useAnimation = 20;
            projOnSwing = true;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 21500;
            item.rare = 6;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType<Kings_Wave>();
            item.shootSpeed = 10f;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Lighting.AddLight(item.Center, 0.9f, 0.1f, 0.3f);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofMight, 20);
            recipe.AddIngredient(ItemID.SoulofFlight, 5);
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddIngredient(mod.ItemType<Princes_Rule>());
            recipe.AddIngredient(ItemID.GoldCrown);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofMight, 20);
            recipe.AddIngredient(ItemID.SoulofFlight, 5);
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddIngredient(mod.ItemType<Princes_Rule>());
            recipe.AddIngredient(ItemID.PlatinumCrown);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
