using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Projectiles;

namespace CelestialGifts.Items.Weapons
{
    public class SwordofGaia : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sword of Gaia");
            Tooltip.SetDefault("Made from the core of the Earth");
        }
        public override void SetDefaults()
        {
            item.damage = 250;
            item.shoot = ProjectileID.TerraBeam;
            item.shootSpeed = 20f;
            item.melee = true;
            item.width = 62;
            item.height = 62;
            item.scale = 1;
            item.useTime = 40;
            item.useAnimation = 30;
            item.useStyle = 1;
            item.knockBack = 10;
            item.value = 10000;
            item.rare = 6;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 15);
            recipe.AddIngredient(ItemID.TerraBlade, 1);
            recipe.AddIngredient(ItemID.SoulofLight, 20);
            recipe.AddIngredient(ItemID.SoulofNight, 20);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }


        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 4 + Main.rand.Next(2); //This defines how many projectiles to shot. 4 + Main.rand.Next(2)= 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15)); // This defines the projectiles random spread . 30 degree spread.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }



    }
}
