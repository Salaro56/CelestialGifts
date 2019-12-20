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
    [AutoloadEquip(EquipType.Legs)]
    class YoyoCopLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yoyo Cop Leggings");
            Tooltip.SetDefault("Helps you run towards CRIME!"
                + "\nPlus 20% Move Speed");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(0, 0, 0, 12);
            item.rare = -12;
            item.defense = 34;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed *= 1.2f;
        }
    }
}
