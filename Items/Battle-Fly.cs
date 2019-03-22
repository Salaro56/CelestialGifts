using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts;
using CelestialGifts.Projectiles.WeapProj;

namespace CelestialGifts.Items
{
    class Battle_Fly : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Battle-Fly");
            Tooltip.SetDefault("FIGHT WITH THE POWER OF BUTTERFLIES!");
        }

        public override void SetDefaults()
        {

            item.damage = 50;
            item.thrown = true;
            item.noMelee = true;
            item.width = 50;
            item.height = 50;
            item.useTime = 40;
            item.useAnimation = 30;
            item.useStyle = 1;
            item.knockBack = 6f;
            item.value = 1000000;
            item.rare = 4;
            item.reuseDelay = 40;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType<Battlefly_proj>();
            item.shootSpeed = 10f;
            item.useTurn = true;
            item.consumable = false;
            item.maxStack = 1;
            item.noUseGraphic = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 20);
            recipe.AddIngredient(ItemID.MonarchButterfly, 10);
            recipe.AddIngredient(ItemID.JuliaButterfly, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
