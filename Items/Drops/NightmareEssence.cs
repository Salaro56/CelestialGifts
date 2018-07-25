using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialGifts.Items.Drops
{
    public class NightmareEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essence of Nightmares");
            Tooltip.SetDefault("Just holding it sends shivers down your spine");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 4));
        }
        public override void SetDefaults()
        {
            item.width = 5;
            item.height = 5;
            item.value = 10000;
            item.rare = 6;
            item.maxStack = 999;
            ItemID.Sets.ItemNoGravity[item.type] = true;  //this make that the item will float in air
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}