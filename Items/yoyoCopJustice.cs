using CelestialGifts.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialGifts.Items
{
    public class yoyoCopJustice : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("One of the evolving items given by the four divine");
            DisplayName.SetDefault("Yo-Yo Cop's Justice");
            // These are all related to gamepad controls and don't seem to affect anything else
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.useStyle = 5;
            item.width = 86;
            item.height = 124;
            item.useAnimation = 100;
            item.useTime = 100;
            item.shootSpeed = 20f;
            item.knockBack = 2.5f;
            item.damage = 25;
            item.rare = 6;

            item.melee = true;
            item.channel = true;
            item.noMelee = true;
            item.noUseGraphic = true;

            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(platinum: 20);
            item.shoot = mod.ProjectileType<yoyoCopProjectile>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodYoyo, 2);
            recipe.AddIngredient(ItemID.StoneBlock, 20);
            recipe.AddIngredient(ItemID.Wood, 20);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
                
        }

    }
}
