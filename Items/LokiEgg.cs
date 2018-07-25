using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialGifts.Items
{
    public class LokiEgg : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Loki the Bunny");
            Tooltip.SetDefault("The Developer's Pet Bunny");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Bunny);
            item.shoot = mod.ProjectileType("Loki");
            item.buffType = mod.BuffType("LokiBuff");
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FuzzyCarrot, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
    }
}