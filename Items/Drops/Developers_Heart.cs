using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CelestialGifts.Items.Drops
{
    public class Developers_Heart : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hopeful Heart");
            Tooltip.SetDefault("Even in the darkest of places, there's always a little bit of light");
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
