using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Projectiles;

namespace CelestialGifts.Items
{
    public class Princes_Rule : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prince's Rule");
            Tooltip.SetDefault("The heir to the cosmos");
        }
        public override void SetDefaults()
        {
            item.damage = 30;
            item.melee = true;
            item.width = 50;
            item.height = 50;
            item.scale = 0.5f;
            item.useTime = 40;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 5000;
            item.rare = 6;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }


        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if(Main.rand.NextBool(3))
                {
                    int dust = Dust.NewDust(new Vector2(hitbox.X,hitbox.Y), 20,hitbox.Height, DustID.Fire, item.velocity.X * 0.25f, item.velocity.Y * 0.25f, 0, default(Color), 2f);
                    Main.dust[dust].noGravity = true;
                }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 120);
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddIngredient(ItemID.GoldBroadsword);
            recipe.AddIngredient(ItemID.GoldCrown);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
