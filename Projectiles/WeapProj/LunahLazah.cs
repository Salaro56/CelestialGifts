using CelestialGifts.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialGifts.Projectiles.WeapProj
{

    public class LunahLazah : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = ("Lunah Lazah SON!");
            projectile.width = 10;
            projectile.height = 6;
            projectile.timeLeft = 200;
            projectile.penetrate = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.aiStyle = 5;
        }

        public override void AI()
        {
            projectile.light = 0.9f;
            projectile.alpha = 128;
            projectile.rotation += (float)projectile.direction * 0.8f;
            int DustID = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 4, projectile.height + 4, ModContent.DustType<EtherealFlame>(), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default(Color), 0.75f); //Spawns dust
            Main.dust[DustID].noGravity = true; //Makes dust not fall
            if (projectile.timeLeft % 15 == 0)
            {
                ;
            }


        }


        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            Player owner = Main.player[projectile.owner];
            int rand = Main.rand.Next(2); //Generates an integer from 0 to 1
            if (rand == 0)
            {
                n.AddBuff(24, 180); //On Fire! debuff for 3 seconds
            }
            else if (rand == 1)
            {
                owner.statLife += 5; //Gives 5 Health
                owner.HealEffect(5, true); //Shows you have healed by 5 health
            }
        }
        public override void Kill(int timeLeft)
        {
            int rand = Main.rand.Next(5); //Generates integers from 0 to 4
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, 10, (int) projectile.knockBack, Main.myPlayer);

        }

    }
}