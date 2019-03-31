using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Dusts;
using Microsoft.Xna.Framework;
using CelestialGifts.Items.BossSummons;
using CelestialGifts.Items.Drops;
using System;
using CelestialGifts.Projectiles.HostileProj;

namespace CelestialGifts.NPCs.Mobs
{
    public class NightmareSpawn : ModNPC
    {
        private Player player;
        private float speed;
        const int COOLDOWN = 60;
        int remaining_cooldown = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nightmare Spawn");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Demon];
        }

        public override void SetDefaults()
        {
            npc.width = 32;
            npc.height = 40;
            npc.damage = 40;
            npc.defense = 16;
            npc.lifeMax = 400;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 100f;
            npc.knockBackResist = 1f;
            aiType = NPCID.Harpy;
            animationType = NPCID.Harpy;
            npc.noGravity = true;
        }

        public override void AI()
        {
            Target();
        }

        private void Target()
        {
            player = Main.player[npc.target];

            Move(new Vector2(0, -100f)); // Calls the Move Method
            //Attacking
            npc.ai[1] -= 1f; // Subtracts 1 from the ai.
            if (npc.ai[1] <= 0f)
            {
                Shoot();
            }
        }
        private void Move(Vector2 offset)
        {
            speed = 10f; // Sets the max speed of the npc.
            Vector2 moveTo = player.Center + offset * 2; // Gets the point that the npc will be moving to.
            Vector2 move = moveTo - npc.Center;
            float magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            float turnResistance = 10f; // The larget the number the slower the npc will turn.
            move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
            magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            npc.velocity = move;
        }
        private void Shoot()
        {
            int type = mod.ProjectileType<NightmareNeedle>();
            Vector2 velocity = player.Center - npc.Center; // Get the distance between target and npc.
            float magnitude = Magnitude(velocity);
            if (magnitude > 0)
            {
                velocity *= 5f / magnitude;
            }
            else
            {
                velocity = new Vector2(0f, 5f);
            }
            Projectile.NewProjectile(npc.Center, velocity, type, npc.damage = 10, 0.5f);
            npc.ai[1] = 200f;
        }
        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.hardMode == true)
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.05f;
            }
            return 0f;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter -= 0.9f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
            npc.spriteDirection = npc.direction;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 20; i++) //this i a for loop tham make the dust spawn , the higher is the value the more dust will spawn
            {
                int dust = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, mod.DustType<DreamDust>(), npc.velocity.X * 1.2f, npc.velocity.Y * 1.2f, 120, default(Color), 2.50f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                Main.dust[dust].velocity *= 1f;
            }
        }


        public override void NPCLoot()
        {
            if (Main.rand.Next(1000) == 0)
                Item.NewItem(npc.getRect(), mod.ItemType<Emptiness>());
            if (Main.rand.Next(20) == 0)
                Item.NewItem(npc.getRect(), mod.ItemType<NightmareEssence>());
        }
    }
}
