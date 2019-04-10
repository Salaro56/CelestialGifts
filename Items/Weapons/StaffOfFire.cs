using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CelestialGifts.Projectiles.WeapProj;
using Microsoft.Xna.Framework;

namespace CelestialGifts.Items.Weapons
{
    class StaffOfFire : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Staff of Fire");
            Tooltip.SetDefault("A staff made from ancient gems infused with the element of fire");
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.damage = 120;  //The damage stat for the Weapon.
            item.mana = 20;      //this defines how many mana this weapon use
            item.width = 100;
            item.height = 100;
            item.useTime = 25;   //How fast the Weapon is used.
            item.useAnimation = 25;    //How long the Weapon is used for.
            item.useStyle = 5;  //The way your Weapon will be used, 1 is the regular sword swing for example
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 2.5f;  //The knockback stat of your Weapon.
            item.value = Item.buyPrice(1, 0, 0, 0); //	How much the item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this item price is 10gold)
            item.rare = 8;   //The color the title of your Weapon when hovering over it ingame  
            item.UseSound = SoundID.Item44;   //The sound played when using your Weapon
            item.autoReuse = false;   //Weather your Weapon will be used again after use while holding down, if false you will need to click again after use to use it again.
            item.shoot = mod.ProjectileType<WhiteExplosion>();
            item.magic = true;    //This defines if it does Summon damage and if its effected by Summon increasing Armor/Accessories.
            item.sentry = true; //tells the game that this is a sentry
            item.maxStack = 1;
            item.shootSpeed = 0.001f;
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 SPos = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
            position = SPos;
            Main.PlaySound(2, (int)item.position.X, (int)item.position.Y, 14); //Bullet noise
            return true;
        }




    }
}
