using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CelestialGifts.Projectiles.WeapProj;
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
            Tooltip.SetDefault("The blade seems to be perpetually bleeding..." +
                "\nBetter not to think about it.");
        }

        public override void SetDefaults()
        {
            item.damage = 68;
            item.melee = true;
            item.width = 50;
            item.height = 50;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 1;
            item.value = Item.buyPrice(0,50,0,0);
            item.rare = 6;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.scale = 1;
            item.shoot = ModContent.ProjectileType<BloodWave>();
            item.shootSpeed = 0.001f;
        }
    }
}
