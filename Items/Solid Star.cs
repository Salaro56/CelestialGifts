using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Projectiles;
using Microsoft.Xna.Framework;

namespace CelestialGifts.Items
{
    public class Solid_Star : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solid Star");
            Tooltip.SetDefault("Heaven's piercing light. A gift from Solid");
        }

        public override void SetDefaults()
        {
            item.damage = 700;
            item.ranged = true;
            item.width = 100;
            item.height = 100;
            item.noMelee = true;
            item.maxStack = 1;
            item.useTime = 20;
            item.useAnimation = 20;
            item.knockBack = 2f;
            item.useStyle = 5;
            item.value = 100000000;
            item.rare = 10;
            item.shootSpeed = 50f;
            item.autoReuse = true;
            item.UseSound = SoundID.Item5;
            item.useAmmo = mod.ItemType<SiriusShot>();
            item.shoot = mod.ProjectileType<siriusShot>();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddIngredient(mod.ItemType<Eclipse_Core>());
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddIngredient(ItemID.FragmentVortex, 15);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
