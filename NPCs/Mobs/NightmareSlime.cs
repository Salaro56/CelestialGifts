using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Dusts;
using CelestialGifts.Items.BossSummons;
using CelestialGifts.Items.Drops;

namespace CelestialGifts.NPCs.Mobs
{
    public class NightmareSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nightmare Slime");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime];
        }

        public override void SetDefaults()
        {
            npc.width = 32;
            npc.height = 30;
            npc.damage = 20;
            npc.defense = 10;
            npc.lifeMax = 500;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 60f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 1;
            aiType = NPCID.CorruptSlime;
            animationType = NPCID.CorruptSlime;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.hardMode == true)
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.05f;
            }
            return 0f;
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
            if (Main.rand.Next(1000) == 0)
                Item.NewItem(npc.getRect(), mod.ItemType<Emptiness>());
            if (Main.rand.Next(20) == 0)
                Item.NewItem(npc.getRect(), mod.ItemType<NightmareEssence>());
        }
    }
}
