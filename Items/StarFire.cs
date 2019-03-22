using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Projectiles;

namespace CelestialGifts.Items
{
    public class StarFire : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Fire");
            Tooltip.SetDefault("The power of stars in your fingertips. One of the divine evolving weapons");
        }



        public override void SetDefaults()
        {
            item.damage = 8;
            item.ranged = true;
            item.width = 150;
            item.height = 70;
            item.maxStack = 1;
            item.useTime = 5;
            item.useAnimation = 5;
            item.knockBack = 1f;
            item.noMelee = true;
            item.useStyle = 5;
            item.value = 10000;
            item.rare = 6;
            item.shootSpeed = 20f;
            item.autoReuse = true;
            item.useAmmo = mod.ItemType<Starshot>();
            item.UseSound = SoundID.Item11;
            item.shoot = 10;
            item.scale = 0.5f;
        }

        public override void AddRecipes() //Adding recipes
        {
            ModRecipe recipe = new ModRecipe(mod); //Creating a new recipe to be added to 
            recipe.AddIngredient(ItemID.StarCannon);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this); //Set the result of the recipe to this item (this refers to the class itself)
            recipe.AddRecipe(); //Add this recipe
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) //This lets you modify the firing of the item
        {
            /*Code is made by berberborscing*/
            int spread = 10;//The angle of random spread.
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



