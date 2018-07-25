using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialGifts.Items
{
    public class GlitteringGem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glittering Gem");
            Tooltip.SetDefault("What's this..?");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Bunny);
            item.shoot = mod.ProjectileType("SolidRock");
            item.buffType = mod.BuffType("GooglyBuff");
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 999);
            recipe.AddIngredient(ItemID.StoneBlock, 999);
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