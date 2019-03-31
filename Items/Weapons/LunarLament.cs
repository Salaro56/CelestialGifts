using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Projectiles.WeapProj;

namespace CelestialGifts.Items.Weapons
{
    public class LunarLament : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lunar's Lament");
            Tooltip.SetDefault("The hidden tomes of the moons song");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 80;
            item.magic = true;
            item.width = 36;
            item.height = 36;
            item.mana = 15;
            item.noMelee = true;
            item.knockBack = 2;
            item.rare = 6;
            item.useTime = 25;
            item.useStyle = 5;
            item.useAnimation = 25;
            item.value = 100000;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shootSpeed = 6f;
            item.shoot = mod.ProjectileType<LostMoonPages>();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Hellstone, 15);
            recipe.AddIngredient(ItemID.Book);
            recipe.AddIngredient(mod.ItemType<LunarBlast>());
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 3 + Main.rand.Next(2); //This defines how many projectiles to shot. 4 + Main.rand.Next(2)= 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15)); // This defines the projectiles random spread . 30 degree spread.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }




    }
}