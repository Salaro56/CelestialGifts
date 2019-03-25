using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Projectiles.WeapProj;

namespace CelestialGifts.Items
{
    public class Divine_Domain : ModItem
    {
        private Vector2 position;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Divine's Domain");
            Tooltip.SetDefault("The power of the divine at your finger tips");
        }
        public override void SetDefaults()
        {
            item.damage = 120;
            item.melee = true;
            item.width = 100;
            item.height = 100;
            item.scale = 0.8f;
            item.useTime = 90;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 10000;
            item.rare = 6;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType<HolyFire>();
            item.shootSpeed = 7f;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), 20, hitbox.Height, DustID.Silver, item.velocity.X * 0.25f, item.velocity.Y * 0.25f, 0, default(Color), 1f);
                Main.dust[dust].noGravity = true;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 15);
            recipe.AddIngredient(ItemID.AngelWings);
            recipe.AddIngredient(mod.ItemType<Kings_Right>());
            recipe.AddIngredient(ItemID.GoldCrown);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 15);
            recipe.AddIngredient(ItemID.AngelWings);
            recipe.AddIngredient(mod.ItemType<Kings_Right>());
            recipe.AddIngredient(ItemID.PlatinumCrown);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
