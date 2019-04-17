using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialGifts.Items.Weapons
{
    class Zombow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zombow");
            Tooltip.SetDefault("Is this two zombie arms slapped together? Interesting");
        }
        public override void SetDefaults()
        {
            item.ranged = true;
            item.damage = 16;
            item.noMelee = true;
            item.useAmmo = AmmoID.Arrow;
            item.shoot = AmmoID.Arrow;
            item.useTime = 25;
            item.useStyle = 5;
            item.useAnimation = 25;
            item.autoReuse = false;
            item.crit = 2;
            item.shootSpeed = 5f;
            item.width = 70;
            item.height = 70;
            item.UseSound = SoundID.Item5;
        }
    }
}
