using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CelestialGifts.Items
{
    public class Developers_Heart : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Developer's Heart");
            Tooltip.SetDefault("It's a little broken but it's still good");
        }
        public override void SetDefaults()
        {
            item.height = 20;
            item.width = 20;
            item.noMelee = true;
            item.maxStack = 1;
            item.useStyle = 5;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }
    }
}
