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
    [AutoloadEquip(EquipType.Head)]
    class PoliceKep : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Police Cap");
            Tooltip.SetDefault("WEEWOOWEEWOOWEEWOO"
                + "\nPlus 15% Melee Damage");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 10000000;
            item.rare = -12;
            item.defense = 30;
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeDamage = 1.15f;
        }
    }
}
