using Terraria;
using Terraria.ModLoader;

namespace CelestialGifts.Buffs
{
    public class LokiBuff : ModBuff
    {

        public override void SetDefaults()
        {
            // DisplayName and Description are automatically set from the .lang files, but below is how it is done normally.
            // DisplayName.SetDefault("Paper Airplane");
            // Description.SetDefault("\"Let this pet be an example to you!\"");
            DisplayName.SetDefault("Loki The Bunny");
            Description.SetDefault("The Developer's pet bunny");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<MyPlayer>().Loki = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("Loki")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("Loki"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}