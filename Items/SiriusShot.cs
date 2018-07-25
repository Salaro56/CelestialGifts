using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Projectiles;

namespace CelestialGifts.Items
{

    public class SiriusShot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sirius Shot");
            Tooltip.SetDefault("Light of the Divines");

        }

        public override void SetDefaults()
        {
            item.damage = 500;
            item.ranged = true;
            item.width = 36;
            item.height = 10;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 1f;
            item.value = 10000;
            item.rare = 6;
            item.ammo = mod.ItemType("SiriusShot");
            item.shoot = mod.ProjectileType<siriusShot>();
            item.scale = 0.5f;

        }


    }





}