using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CelestialGifts.Items.BossSummons;
using CelestialGifts.Items.Drops;
using CelestialGifts.NPCs.Mobs;
using CelestialGifts.Projectiles.HostileProj;
using CelestialGifts.Dusts;
using CelestialGifts.NPCs.Bosses.NightmareWorm;

namespace CelestialGifts.NPCs.Bosses
{
    [AutoloadBossHead]
    public class Fear : ModNPC
    {
        private Player player;
        private float speed;
        private bool spawn = true;
        public bool alive = true;
        private bool phaseOne = true;
        private bool phaseTwo = true;
        private bool phaseThree = true;
        private bool faceTarget;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fear - The Riftwalker");
            Main.npcFrameCount[npc.type] = 6;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 10000; // The Max HP the boss has on Normal
            npc.damage = 70; // The base damage value the boss has on Normal
            npc.defense = 40; // The base defense on Normal
            npc.knockBackResist = 0f; // No knockback
            npc.width = 100;
            npc.height = 100;
            npc.scale = 2f;
            npc.value = Item.buyPrice(0,10, 30, 0);
            npc.npcSlots = 5f; // The higher the number, the more NPC slots this NPC takes.
            npc.boss = true; // Is a boss
            npc.lavaImmune = true; // Not hurt by lava
            npc.noGravity = true; // Not affected by gravity
            npc.noTileCollide = true; // Will not collide with the tiles. 
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            music = MusicID.Boss5;
            npc.value = Item.buyPrice(0, 20, 15, 0);
        }


        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
            npc.defense = (npc.defense + numPlayers);
        }


        public override void AI()
        {

            BossFight();
            Target();
            SpawnNPC();
            for (int i = 0; i < 1; i++)
            {
                int dust = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width + 200 & - 200, npc.height, mod.DustType<NightDust>(), npc.velocity.X * 3f, npc.velocity.Y * 3f, 120, Color.Black);   //this make so when this projectile is active has dust around , change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = false; //this make so the dust is effected by gravity
                Main.dust[dust].velocity *= 2f;
            }

        }

        private void BossFight()
        {

            //stage one
            if (NPC.AnyNPCs(mod.NPCType("Nightmare")) || NPC.AnyNPCs(mod.NPCType<NightmareHead>()))
            {

                npc.dontTakeDamage = true;

            }
            else
            {
                npc.dontTakeDamage = false;

                if (npc.life <= 9000 && phaseOne == true)
                {
                    spawn = true;
                    phaseOne = false;
                    npc.defense = 80;
                }
                else if (npc.life <= 6000 && phaseTwo == true)
                {
                    spawn = true;
                    phaseTwo = false;
                    npc.defense = 90;
                }
                else if (npc.life <= 2000 && phaseThree == true)
                {
                    spawn = true;
                    phaseThree = false;
                    npc.defense = 100;
                    npc.damage = 120;
                }
                else if (npc.life > 500)
                {
                    npc.defense = 20;
                    npc.damage = 30;
                    music = MusicID.RainSoundEffect;
                }
            }
        }


        private void Target()
        {
            npc.TargetClosest(faceTarget);
            player = Main.player[npc.target]; // This will get the player target.
            //Attacking
            npc.ai[1] -= 1f; // Subtracts 1 from the ai.
            if (npc.ai[1] <= 0f)
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            int type = mod.ProjectileType<NightmareNeedle>();
            Vector2 velocity = player.Center - npc.Center; // Get the distance between target and npc.
            float magnitude = Magnitude(velocity);
            if (magnitude > 0)
            {
                velocity *= 50f / magnitude;
            }
            else
            {
                velocity = new Vector2(0f, 5f);
            }
            Projectile.NewProjectile(npc.Center, velocity, type, npc.damage = 20, 0.5f);
            npc.ai[1] = 100f;
        }


        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1;
            npc.frameCounter %= 100;
            int frame = (int)(npc.frameCounter / 6);
            if (frame >= Main.npcFrameCount[npc.type]) frame = 0;
            npc.frame.Y = frame * frameHeight;
        }

        private void SpawnNPC()
        {
            if (spawn == true)
            {
                NPC.NewNPC((int)npc.position.X + Main.rand.Next(500), (int)npc.position.Y, mod.NPCType<Nightmare>());
                NPC.NewNPC((int)npc.position.X + Main.rand.Next(500), (int)npc.position.Y, mod.NPCType<Nightmare>());
                NPC.NewNPC((int)npc.position.X + Main.rand.Next(500), (int)npc.position.Y, mod.NPCType<NightmareHead>());

                if (npc.life <= 9000)
                {
                    NPC.NewNPC((int)npc.position.X + Main.rand.Next(500), (int)npc.position.Y, mod.NPCType<Nightmare>());
                    NPC.NewNPC((int)npc.position.X + Main.rand.Next(500), (int)npc.position.Y, mod.NPCType<Nightmare>());
                    NPC.NewNPC((int)npc.position.X + Main.rand.Next(500), (int)npc.position.Y, mod.NPCType<NightmareHead>());
                    NPC.NewNPC((int)npc.position.X + Main.rand.Next(500), (int)npc.position.Y, mod.NPCType<NightmareHead>());
                }
                else if (npc.life <= 6000)
                {
                    NPC.NewNPC((int)npc.position.X + Main.rand.Next(500), (int)npc.position.Y, mod.NPCType<Nightmare>());
                    NPC.NewNPC((int)npc.position.X + Main.rand.Next(500), (int)npc.position.Y, mod.NPCType<NightmareHead>());
                }
            }           
            spawn = false;
        }

        public override void NPCLoot()
        {
            if (Main.expertMode)
            {
                npc.DropBossBags();
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType<TierOneRift>());
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType<NightmareEssence>(), 5);
            }
            else
            {
                if (Main.rand.Next(3) == 0) // For items that you want to have a chance to drop 
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Blackheart"));
                }
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Essence of Nightmares"), 5); // For Items that you want to always drop
            }
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }

    }
}