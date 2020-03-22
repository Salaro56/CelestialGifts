using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace CelestialGifts.Items.Weapons.Magic
{
    class Sals_Book : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sal's Book of Spells");
            Tooltip.SetDefault("Sal was a wise and powerful wizard but he sometimes got bored in his methods. " +
                "\nHe made several tomes of random magical effects, let's hope it doesn't blow up on you");
        }

        public override void SetDefaults()
        {
            //item stats
            item.magic = true;
            item.damage = 5;
            item.mana = 10;
            item.shoot = ProjectileID.WaterBolt;
            item.shootSpeed = 2f;
            //item configs
            item.width = 32;
            item.height = 32;
        }
    }
}
