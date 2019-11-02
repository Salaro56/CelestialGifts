using CelestialGifts.Projectiles.WeapProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialGifts.Items.Weapons
{
    class SilverMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silver Mirror");
            Tooltip.SetDefault("Banish the nightmares" + 
                "\nSomething seems like it's hiding in the mirror");
        }

        public override void SetDefaults()
        {
            item.damage = 55;
            item.magic = true;
            item.mana = 5;
            item.width = 30;
            item.height = 60;
            item.channel = true;
            item.noMelee = true;
            item.useTime = 15;
            item.useAnimation = 20;
            item.UseSound = SoundID.Item13;
            item.useStyle = 5;
            item.shoot = ModContent.ProjectileType<SilverArrow>();
            item.shootSpeed = 2f;
            item.value = Item.buyPrice(0, 5, 0, 0);
            item.scale = 0.7f;
        }
    }
}
