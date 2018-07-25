using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CelestialGifts.Projectiles;
using CelestialGifts.Items;
using CelestialGifts.Items.BossSummons;

namespace CelestialGifts.NPCs.Mobs
{
    public class Shadow : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
        }

        public override void SetDefaults()
        {
            npc.width = 64;
            npc.height = 64;
            npc.damage = 15;
            npc.defense = 4;
            npc.lifeMax = 50;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 60f;
            npc.knockBackResist = 1f;
            npc.aiStyle = 3;
            aiType = NPCID.Zombie;
            animationType = NPCID.Zombie;
            npc.noGravity = false;
            npc.stepSpeed = 10f;
        }


        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNightMonster.Chance * 1f;
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
                Main.dust[dust].velocity *= 0.5f;
            }
        }

        public override void NPCLoot()
        {
            if (Main.rand.Next(50) == 0)
                Item.NewItem(npc.getRect(), mod.ItemType<TierOneRift>());
        }
    }
}