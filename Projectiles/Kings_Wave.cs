using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using CelestialGifts.Dusts;
using Microsoft.Xna.Framework.Graphics;

namespace CelestialGifts.Projectiles
{
    public class Kings_Wave : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The King's Force");
        }

        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
            projectile.aiStyle = 18;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 3;
            projectile.damage = 80;
            projectile.scale = 2;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, projectile.Center, 62);    //this make so when this projectile disappear will make this sound. you can find all the sound ID here: https://github.com/bluemagic123/tModLoader/wiki/Vanilla-Sound-IDs

            for (int i = 0; i < 20; i++) //this i a for loop tham make the dust spawn , the higher is the value the more dust will spawn
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType<EtherealFlame>(), projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 120, default(Color), 2.50f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                Main.dust[dust].velocity *= 1.5f;
            }
        }
    }
}