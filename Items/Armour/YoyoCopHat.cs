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
    class YoyoCopHat : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yoyo Cop Cap");
            Tooltip.SetDefault("Shades to block out the CRIME!");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(0,0,0,12);
            item.rare = -12;
            item.defense = 34;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<YoyoCopChestpiece>() && legs.type == ModContent.ItemType<YoyoCopLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.allDamage *= 1.30f;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawAltHair = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.allDamage *= 1.15f;
        }
    }
}
