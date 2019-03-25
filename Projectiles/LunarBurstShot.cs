using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Dusts;

namespace CelestialGifts.Projectiles
{
   
    public class LunarBurstShot : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = ("LunarBurstShot");
            projectile.width = 36;
            projectile.height = 36;
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
            int DustID = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 4, projectile.height + 4, 36, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default(Color), 0.75f); //Spawns dust
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
                owner.statLife += 8; //Gives 5 Health
                owner.HealEffect(5, true); //Shows you have healed by 5 health
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, projectile.Center, 62);    //this make so when this projectile disappear will make this sound. you can find all the sound ID here: https://github.com/bluemagic123/tModLoader/wiki/Vanilla-Sound-IDs
            projectile.netUpdate = true;

            for (int i = 0; i < 20; i++) //this i a for loop tham make the dust spawn , the higher is the value the more dust will spawn
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType<EtherealFlame>(), projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 120, default(Color), 2.50f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                Main.dust[dust].velocity *= 1.5f;
            }
            projectile.type = 12;
        }

        }
    }