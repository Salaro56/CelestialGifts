using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace CelestialGifts.Buffs
{
    class DeQueenBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Mini Queen");
            Description.SetDefault("Will fight for you and her kingdom");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
            if (player.ownedProjectileCounts[ProjectileType<Projectiles.Minions.DeQueen>()] > 0)
            {
                modPlayer.DQueen = true;
            }
            if (!modPlayer.DQueen)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 18000;
            }
        }

    }
}
