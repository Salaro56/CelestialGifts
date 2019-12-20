using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using CelestialGifts.Dusts;
using CelestialGifts.Projectiles.HostileProj;

namespace CelestialGifts.NPCs.Mobs
{
    class Angel : ModNPC
    {
        private bool faceTarget;
        private Player player;
        private float shotTimer;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Angel");
            Main.npcFrameCount[npc.type] = 6;
        }

        public override void SetDefaults()
        {
            //npc stats
            npc.lifeMax = 200;
            npc.defense = 15;
            npc.damage = 20;
            //sprite related stuff
            npc.width = 150;
            npc.height = 165;
            //npc ai stuff
            npc.aiStyle = 14;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 70;
            npc.noGravity = true;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if(spawnInfo.player.ZoneSkyHeight)
            {
                return SpawnCondition.Sky.Chance * 0.25f;
            }
            return 0f;
        }

        public override void AI()
        {
            Target();
            npc.spriteDirection = npc.direction;
            Lighting.AddLight(npc.position, 255, 255, 255);

            shotTimer -= 1f; // Subtracts 1 from the ai.
            if (shotTimer <= 0f)
            {
                Shoot();
            }
        }

        private void Target()
        {
            npc.TargetClosest(faceTarget);
            player = Main.player[npc.target]; // This will get the player target.
        }

        public void Shoot()
        {
            int type = ModContent.ProjectileType<CrownOfThorns>();
            Vector2 velocity = player.Center - npc.Center; // Get the distance between target and npc.
            float magnitude = Magnitude(velocity);
            if (magnitude > 0)
            {
                velocity *= 10f / magnitude;
            }
            else
            {
                velocity = new Vector2(0f, 5f);
            }
            Projectile.NewProjectile(npc.Center, new Vector2(velocity.X, velocity.Y), type, 20, 2f);
            shotTimer = 200f;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1;
            npc.frameCounter %= 100;
            int frame = (int)(npc.frameCounter / 6);
            if (frame >= Main.npcFrameCount[npc.type]) frame = 0;
            npc.frame.Y = frame * frameHeight;
        }

        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for(int i = 0; i < 10; i++)
            {
                int dust = Dust.NewDust(new Vector2(npc.Center.X - 50, npc.Center.Y - 42), 75, 82, DustID.Blood, npc.velocity.X, npc.velocity.Y, 70, default(Color), 2f);
                Main.dust[dust].noGravity = true;
            }
            if(npc.life <= 0)
            {
                for (int i = 0; i < 50; i++)
                {
                    int dust = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), 150, 165, ModContent.DustType<HolyLight>(), npc.velocity.X, npc.velocity.Y, 20, default(Color), 4f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 2f;
                }
            }
        }
    }
}
