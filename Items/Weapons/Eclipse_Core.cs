using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Projectiles.WeapProj;
using CelestialGifts.Items.Ammo;

namespace CelestialGifts.Items.Weapons
{
    public class Eclipse_Core : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eclipse Core");
            Tooltip.SetDefault("A gun, made from the condensded star energy in living beings");
        }



        public override void SetDefaults()
        {
            item.damage = 25;
            item.ranged = true;
            item.width = 50;
            item.height = 31;
            item.maxStack = 1;
            item.useTime = 20;
            item.useAnimation = 20;
            item.knockBack = 1f;
            item.noMelee = true;
            item.useStyle = 5;
            item.value = 100000;
            item.rare = 8;
            item.shootSpeed = 15f;
            item.autoReuse = true;
            item.useAmmo = mod.ItemType<Energy_Clip>();
            item.UseSound = SoundID.Item12;
            item.shoot = 10;
        }

        public override void AddRecipes() //Adding recipes
        {

        }
    }
}
