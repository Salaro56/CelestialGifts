using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CelestialGifts.Items.Drops
{
    class LurkingShadow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lurking Shadow");
            Tooltip.SetDefault("How are you even holding this?");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 5));
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.alpha = (int)0.7f;
        }
    }
}
