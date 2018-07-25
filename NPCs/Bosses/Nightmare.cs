using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Dusts;
using CelestialGifts.Projectiles;

namespace CelestialGifts.NPCs.Bosses
{
    class Nightmare : ModNPC
    {
        private Player player;

        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("Nightmare");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BloodCrawler];
        }

        public override void SetDefaults()
        {
            npc.CloneDefaults(NPCID.BloodCrawler);
            animationType = NPCID.BloodCrawler;
            aiType = NPCID.BloodCrawler;
            npc.lifeMax = 5000;
            npc.defense = 20;
            npc.damage = 60;
            npc.knockBackResist = 0f;
            npc.lavaImmune = true;
            npc.noGravity = false;
            npc.noTileCollide = false;
            npc.netAlways = true;
            npc.color = Color.Black;
            npc.scale = 5;
        }

        public override void AI()
        {
            Target();
            for (int i = 0; i < 1; i++)
            {
                int dust = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, mod.DustType<DreamDust>(), npc.velocity.X * 1.2f, npc.velocity.Y * 1.2f, 120, Color.Black);   //this make so when this projectile is active has dust around , change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true; //this make so the dust is effected by gravity
                Main.dust[dust].velocity *= 0.9f;
            }
        }

        private void Target()
        {
            player = Main.player[npc.target];
            //Attacking
            npc.ai[1] -= 1f; // Subtracts 1 from the ai.
            if (npc.ai[1] <= 0f)
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            int type = 472;
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
            npc.ai[1] = 200f;
        }
        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }


        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 2f;
            return null;
        }

    }
}
