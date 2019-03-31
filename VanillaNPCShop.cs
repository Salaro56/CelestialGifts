using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CelestialGifts.Items.Weapons;
using CelestialGifts.Items.Pets;

namespace YourModName.NPCs
{
    public class VanillaNPCShop : GlobalNPC
    {
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            switch (type)
            {
                case NPCID.TravellingMerchant:  //change Dryad whith what NPC you want

                    if (Main.hardMode) //if it's hardmode the NPC will sell this
                    {
                        if(Main.rand.Next(5) == 0)
                        {
                            shop.item[nextSlot].SetDefaults(mod.ItemType<Blackheart>());
                            nextSlot++;
                        }
                        shop.item[nextSlot].SetDefaults(ItemID.CobaltShield);    //this is an example of how to add a terraria item
                        nextSlot++;
                        Mod CalamityMod = ModLoader.GetMod("CalamityMod");
                        if (CalamityMod != null)
                        {
                            if (Main.rand.Next(3) == 0)
                            {
                                shop.item[nextSlot].SetDefaults(CalamityMod.ItemType("AnarchyBlade"));
                                nextSlot++;
                                if (NPC.downedMoonlord)
                                {
                                    shop.item[nextSlot].SetDefaults(CalamityMod.ItemType("BarofLife"));
                                    nextSlot++;
                                }
                            }
                        }
                    }
                    else
                    {    //This make that the npc will always sell this
                        if(Main.rand.Next(10) == 0)
                        {
                            shop.item[nextSlot].SetDefaults(mod.ItemType<LokiEgg>());
                            nextSlot++;
                        }
                        else if(Main.rand.Next(10) == 1)
                        {
                            shop.item[nextSlot].SetDefaults(ItemID.GrapplingHook);     //this is an example of how to add a terraria item
                            nextSlot++;
                        }
                    }
                    if (Main.player[Main.myPlayer].ZoneJungle)//if the player is in jungle the npc will sell whis.  Change ZoneJungle with what zone you want: ZoneCorrupt for Corupption, ZoneCrimson for Crimson, ZoneDesert for Desert, ZoneDungeon for Dungeon, ZoneGlowshroom for Glowing Mushroom biome, ZoneHoly for The Hallow, ZoneJungle for Jungle, ZoneMeteor for Meteorite biome, ZoneSnow for Snow biome.
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.Abeemination); //this is an example of how to add a terraria item
                        nextSlot++;
                    }

                    break;
            }
            switch (type)
            {

            }
            switch (type)
            {
                case NPCID.Angler:
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.GoldenFishingRod);
                    }
                    else { }
                    break;
                     

            }           
        }
    }
}