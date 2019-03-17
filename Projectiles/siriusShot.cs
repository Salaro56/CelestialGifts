using CelestialGifts.Projectiles.WeapProj;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialGifts.Projectiles
{
    public class siriusShot : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "SiriusShot";
            projectile.width = 20;
            projectile.height = 20;
            projectile.timeLeft = 200;
            projectile.penetrate = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.ranged = true;
            projectile.aiStyle = 1;
            projectile.scale = 0.5f;
        }

        public override void AI()
        {
            Player owner = Main.player[projectile.owner]; //Makes a player variable of owner set as the player using the projectile
            projectile.light = 0.9f; //Lights up the whole room
            int DustID = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 4, projectile.height + 4, 36, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default(Color), 0.75f); //Spawns dust
            Main.dust[DustID].noGravity = true; //Makes dust not fall
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
                owner.statLife += 10; //Gives 5 Health
                owner.HealEffect(5, true); //Shows you have healed by 5 health
            }
        }
        public override void Kill(int timeLeft)
        {
            int DustID = Dust.NewDust(new Vector2(projectile.position.X * 5, projectile.position.Y * 5), projectile.width + 4, projectile.height + 2, 36, projectile.velocity.X * 2f, projectile.velocity.Y * 2f, 120, default(Color), 3f);
            int rand = Main.rand.Next(5); //Generates integers from 0 to 4
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y - 20f, 0, 0, mod.ProjectileType<WhiteExplosion>(), (int)(projectile.damage * 1.5), projectile.knockBack, Main.myPlayer); // 296 is the explosion from the Inferno Fork
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14); //Bullet noise
        }




    }
}
