using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace CelestialGifts.Items.Weapons
{
    class NaturesWrath : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nature's Wrath");
            Tooltip.SetDefault("The journal mentioned something about this being made from the will of Terraria itself");
        }
        public override void SetDefaults()
        {
            item.ranged = true;
            item.damage = 20;
            item.noMelee = true;
            item.useAmmo = AmmoID.Arrow;
            item.shoot = AmmoID.Arrow;
            item.useTime = 20;
            item.useStyle = 5;
            item.useAnimation = 20;
            item.autoReuse = true;
            item.crit = 5;
            item.shootSpeed = 15f;
            item.width = 70;
            item.height = 70;
            item.UseSound = SoundID.Item5;
        }
    }
}
