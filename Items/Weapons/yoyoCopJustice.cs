using CelestialGifts.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Projectiles.WeapProj;

namespace CelestialGifts.Items.Weapons
{
    public class yoyoCopJustice : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Walk the dog of justice!");
            DisplayName.SetDefault("Yo-Yo Cop's Justice");
            // These are all related to gamepad controls and don't seem to affect anything else
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.useStyle = 5;
            item.width = 20;
            item.height = 20;
            item.useAnimation = 100;
            item.useTime = 100;
            item.shootSpeed = 20f;
            item.knockBack = 1.2f;
            item.damage = 200;
            item.rare = -12;

            item.melee = true;
            item.channel = true;
            item.noMelee = true;
            item.noUseGraphic = true;

            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(copper: 50);
            item.shoot = ModContent.ProjectileType<yoyoCopProjectile>();
        }
    }
}
