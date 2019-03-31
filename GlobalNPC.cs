using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Items.Weapons;

namespace CelestialGifts
{
    class WorldNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if(Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneDungeon)
            {
                if(Main.rand.NextFloat() < .0050)
                {
                    Item.NewItem(npc.getRect(), mod.ItemType<Eclipse_Core>());
                }
            }
        }
    }
}
