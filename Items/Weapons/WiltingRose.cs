using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CelestialGifts.Projectiles.WeapProj;

namespace CelestialGifts.Items.Weapons
{
    class WiltingRose : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blooming Spark");
            Tooltip.SetDefault("A weak wand that was made to resemble an ancient flower meant to hold the same power");
        }
        public override void SetDefaults()
        {
            item.damage = 10;
            item.knockBack = 1.2f;
            item.rare = -1;
            item.mana = 2;
            item.width = 32;
            item.height = 32;
            item.noMelee = true;
            item.useStyle = 1;
            item.useTime = 25;
            item.useAnimation = 25;
            item.UseSound = SoundID.Item20;
            item.autoReuse = false;
            item.shoot = ModContent.ProjectileType<WiltingFire>();
            item.shootSpeed = 5f;
            item.magic = true;
            item.crit = 5;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Acorn, 15);
            recipe.AddIngredient(ItemID.StrangePlant1);
        }

    }
}
