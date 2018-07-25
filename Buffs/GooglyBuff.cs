using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CelestialGifts.Buffs
{
    public class GooglyBuff : ModBuff
    {
        public override void SetDefaults()
        {
            // DisplayName and Description are automatically set from the .lang files, but below is how it is done normally.
            // DisplayName.SetDefault("Paper Airplane");
            // Description.SetDefault("\"Let this pet be an example to you!\"");
            DisplayName.SetDefault("Look, it's a rock!");
            Description.SetDefault("Man.. What a SOLID rock");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<MyPlayer>(mod).SolidRock = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("SolidRock")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("SolidRock"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}