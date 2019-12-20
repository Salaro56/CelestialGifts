using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CelestialGifts.Items.Armour
{
    [AutoloadEquip(EquipType.Body)]
    class YoyoCopChestpiece : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Yoyo Cop Chestpiece");
            Tooltip.SetDefault("Protects against CRIME!"
                + "\nIncreases maximum life by 40");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(0, 0, 0, 12);
            item.rare = -12;
            item.defense = 40;
        }
        public override void UpdateEquip(Player player)
        {
            player.statLifeMax2 += 40;
        }
    }
}
