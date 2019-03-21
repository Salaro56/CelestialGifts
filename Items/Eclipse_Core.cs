using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Projectiles;

namespace CelestialGifts.Items
{
    public class Eclipse_Core : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eclipse Core");
            Tooltip.SetDefault("The first of condensed energy weapons");
        }



        public override void SetDefaults()
        {
            item.damage = 35;
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
            item.shootSpeed = 30f;
            item.autoReuse = true;
            item.useAmmo = mod.ItemType<Energy_Clip>();
            item.UseSound = SoundID.Item12;
            item.shoot = 10;
        }

        public override void AddRecipes() //Adding recipes
        {
            ModRecipe recipe = new ModRecipe(mod); //Creating a new recipe to be added to 
            recipe.AddIngredient(mod.ItemType<StarFire>());
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddIngredient(ItemID.HellstoneBar, 15);
            recipe.AddIngredient(ItemID.Emerald, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this); //Set the result of the recipe to this item (this refers to the class itself)
            recipe.AddRecipe(); //Add this recipe
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) //This lets you modify the firing of the item
        {
            /*Code is made by berberborscing*/
            int spread = 5;//The angle of random spread.
            float spreadMult = 0.1f; //Multiplier for bullet spread, set it higher and it will make for some outrageous spread.
            for (int i = 0; i < 3; i++)
            {
                float vX = speedX + (float)Main.rand.Next(-spread, spread + 1) * spreadMult;
                float vY = speedY + (float)Main.rand.Next(-spread, spread + 1) * spreadMult;
                Projectile.NewProjectile(position.X, position.Y, vX, vY, type, damage, knockBack, Main.myPlayer);
            }
            return false; //Makes sure to not spawn the original projectile
        }



    }



}
