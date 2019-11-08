using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialGifts.Items.Weapons
{
    public class Heavenly_Body : ModItem
    {
        int currentMode = 1;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Heavenly Body");
            Tooltip.SetDefault(" 'It's a space needle' ");
        }
        public override void SetDefaults()
        {
            if(currentMode == 1)
            {
                SolarMode();
            }
            else if(currentMode == 2)
            {
                VortexMode();
            }
            else if(currentMode == 3)
            {
                NebulaMode();
            }
            else if(currentMode == 4)
            {
                StardustMode();
            }
            else
            {
                currentMode = 1;
            }
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return player.altFunctionUse != 2;
        }

        public override bool UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                currentMode += 1;
            }
            return base.UseItem(player);
        }


        public void SolarMode()
        {
            item.damage = 250;
            item.width = 100;
            item.height = 100;
            item.scale = 1;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 3;
            item.knockBack = 5f;
            item.value = Item.buyPrice(10, 0, 0, 0);
            item.rare = 12;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.scale = 0.5f;
            item.useTurn = true;
        }

        public void VortexMode()
        {
            item.damage = 200;
            item.width = 100;
            item.height = 100;
            item.scale = 1;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 3;
            item.knockBack = 5f;
            item.value = Item.buyPrice(10, 0, 0, 0);
            item.rare = 12;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.scale = 0.5f;
            item.useTurn = true;
        }

        public void NebulaMode()
        {
            item.damage = 200;
            item.width = 100;
            item.height = 100;
            item.scale = 1;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.knockBack = 5f;
            item.value = Item.buyPrice(10, 0, 0, 0);
            item.rare = 12;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.scale = 0.5f;
            item.useTurn = true;
        }

        public void StardustMode()
        {
            item.damage = 150;
            item.width = 100;
            item.height = 100;
            item.scale = 1;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 3;
            item.knockBack = 5f;
            item.value = Item.buyPrice(10, 0, 0, 0);
            item.rare = 12;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.scale = 1f;
            item.useTurn = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddIngredient(ItemID.FragmentSolar, 15);
            recipe.AddIngredient(ItemID.FragmentNebula, 15);
            recipe.AddIngredient(ItemID.FragmentVortex, 15);
            recipe.AddIngredient(ItemID.FragmentStardust, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
