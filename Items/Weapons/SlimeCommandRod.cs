using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using CelestialGifts.Projectiles.Minions;
using CelestialGifts.Buffs;

namespace CelestialGifts.Items.Weapons
{
    class SlimeCommandRod : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("ATTENTION! "
                + "\nCall more powerful slimes to your command.");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.buyPrice(0, 0, 25, 0);
            item.rare = 2;
            item.summon = true;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 5;
            item.damage = 20;
            item.noMelee = true;
            item.knockBack = 3;
            item.mana = 10;
            item.UseSound = SoundID.Item44;
            item.shoot = ProjectileType<LesserSlime>();
            item.shootSpeed = 10f;
            item.buffType = BuffType<LesserSlimeBuff>();
            item.buffTime = 3600;
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
                player.MinionNPCTargetAim();
            }
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SlimeStaff);
            recipe.AddIngredient(ItemID.GoldCrown);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}