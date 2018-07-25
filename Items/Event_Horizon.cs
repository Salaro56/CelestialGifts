using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Projectiles;

namespace CelestialGifts.Items
{
    public class Event_Horizon : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Event Horizon");
            Tooltip.SetDefault("Leading technology mixed with divine energy to create a deadly killing machine");
        }



        public override void SetDefaults()
        {
            item.damage = 150;
            item.ranged = true;
            item.width = 100;
            item.height = 41;
            item.maxStack = 1;
            item.useTime = 4;
            item.useAnimation = 12;
            item.knockBack = 1f;
            item.noMelee = true;
            item.useStyle = 5;
            item.value = Item.buyPrice(0, 30, 0 , 0);
            item.rare = 8;
            item.shootSpeed = 30f;
            item.autoReuse = true;
            item.UseSound = SoundID.Item12;
            item.shoot = mod.ProjectileType<Nebula>();
        }

        public override void AddRecipes() //Adding recipes
        {
            ModRecipe recipe = new ModRecipe(mod); //Creating a new recipe to be added to 
            recipe.AddIngredient(mod.ItemType<Eclipse_Core>());
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddIngredient(ItemID.HallowedBar, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this); //Set the result of the recipe to this item (this refers to the class itself)
            recipe.AddRecipe(); //Add this recipe
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) //This lets you modify the firing of the item
        {
            /*Code is made by berberborscing*/
            int spread = 5;//The angle of random spread.
            float spreadMult = 0.1f; //Multiplier for bullet spread, set it higher and it will make for some outrageous spread.
            for (int i = 0; i < 1; i++)
            {
                float vX = speedX + (float)Main.rand.Next(-spread, spread + 1) * spreadMult;
                float vY = speedY + (float)Main.rand.Next(-spread, spread + 1) * spreadMult;
                Projectile.NewProjectile(position.X, position.Y, vX, vY, type, damage, knockBack, Main.myPlayer);
            }
            return false; //Makes sure to not spawn the original projectile
        }



    }



}