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
    class MrSmileyBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Mr Smiley");
            Description.SetDefault("Hey kids! It's Mr Smiley! Don't look into his eyes!");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
            if (player.ownedProjectileCounts[ProjectileType<Projectiles.Minions.MrSmiley>()] > 0)
            {
                modPlayer.MrSmiles = true;
            }
            if (!modPlayer.MrSmiles)
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
