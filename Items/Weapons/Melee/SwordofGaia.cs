using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Projectiles;
using CelestialGifts.Projectiles.WeapProj;

namespace CelestialGifts.Items.Weapons.Melee
{
    public class SwordofGaia : ModItem
    {
        int weaponSwingCount = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sword of Gaia");
            Tooltip.SetDefault("Made from the core of the Earth");
        }
        public override void SetDefaults()
        {
            item.damage = 100;
            item.shootSpeed = 10f;
            item.shoot = ProjectileID.TerraBeam;
            item.melee = true;
            item.width = 62;
            item.height = 62;
            item.scale = 1;
            item.useTime = 25;
            item.useAnimation = 20;
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
        {;
            if(weaponSwingCount >= 5)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.BoulderStaffOfEarth, (int)(damage * 1.5f), knockBack, Main.myPlayer);
                weaponSwingCount = 0;
            }
            else if(weaponSwingCount < 5)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY - 1f, ModContent.ProjectileType<RazorLeaf>(), (int)(damage * 0.9f), knockBack, Main.myPlayer);
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<RazorLeaf>(), (int)(damage * 0.9f), knockBack, Main.myPlayer);
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY + 1f, ModContent.ProjectileType<RazorLeaf>(), (int)(damage * 0.9f), knockBack, Main.myPlayer);
                weaponSwingCount += 1;
            }
            return false;
        }
    }
}
