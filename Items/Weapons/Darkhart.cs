using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialGifts.Items.Weapons
{
    class Blackheart : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blackhart");
            Tooltip.SetDefault("MUDAMUDAMUDAMDUAMUDAMUDAMUDAMUDAMUDAMUDAMUDAMUDAMUDA");
        }

        public override void SetDefaults()
        {
            item.damage = 50;
            item.melee = true;
            item.width = 40;
            item.height = 80;
            item.useTime = 5;
            item.useAnimation = 5;
            item.useStyle = 1;
            item.knockBack = 1;
            item.value = 1000000;
            item.rare = 6;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.scale = 2;  
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Ichor, 60);
        }

    }
}
