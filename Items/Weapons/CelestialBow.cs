using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Projectiles.WeapProj;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CelestialGifts.Items.Weapons
{
    public class CelestialBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Celestial Bow");
            Tooltip.SetDefault("Strange... A bow made of pure light. The journal didn't mention anything about this");
        }
        public override void SetDefaults()
        {
            item.damage = 200;
            item.ranged = true;
            item.width = 100;
            item.height = 100;
            item.noMelee = true;
            item.maxStack = 1;
            item.useTime = 20;
            item.useAnimation = 20;
            item.knockBack = 2f;
            item.useStyle = 5;
            item.value = 100000000;
            item.rare = 10;
            item.shootSpeed = 25f;
            item.autoReuse = true;
            item.UseSound = SoundID.Item5;
            item.useAmmo = AmmoID.Arrow;
            item.shoot = ModContent.ProjectileType<PiercingLight>();
        }
    }
}
