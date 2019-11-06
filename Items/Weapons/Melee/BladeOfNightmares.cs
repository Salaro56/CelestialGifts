using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CelestialGifts.Items.Drops;

namespace CelestialGifts.Items.Weapons.Melee
{
    class BladeOfNightmares : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blade of Nightmares");
            Tooltip.SetDefault("It feels like it's shifting in your hands, it scares you. " +
                "\nCauses enemies to run in fear after being struck");
        }

        public override void SetDefaults()
        {
            //weapon configs
            item.width = 85;
            item.height = 85;
            item.useStyle = 1;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.scale = 0.7f;
            //weapon stats
            item.melee = true;
            item.damage = 70;
            item.useTime = 30;
            item.useAnimation = 30;
            item.knockBack = 2;
            item.value = Item.buyPrice(0, 4, 0, 0);
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if(Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.Confused, 60);
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<LurkingShadow>(), 12);
            recipe.AddIngredient(ModContent.ItemType<NightmareEssence>(), 10);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
