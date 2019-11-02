using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CelestialGifts.NPCs.Bosses;
using CelestialGifts.Items.Drops;

namespace CelestialGifts.Items.BossSummons
{
    class TierOneRift : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Strange Mirror");
            Tooltip.SetDefault("It feels like you're looking into nothing" +
                "\nSummons Fear");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.buyPrice(0, 0, 0, 0);
            item.rare = -11;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;

        }

        public override bool CanUseItem(Player player)
        {
            bool alreadySpawned = NPC.AnyNPCs(mod.NPCType("Pain"));
            bool isHardmode = Main.hardMode;
            return !alreadySpawned && isHardmode;
        }
        public override bool UseItem(Player player)
        {
            // NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType<Fear>()); // Spawn the boss within a range of the player. 
            NPC.NewNPC((int)player.position.X + 100, (int)player.position.Y, ModContent.NPCType<Fear>());
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);

            return true;
        }
        public override void AddRecipes() //Adding recipes
        {
            ModRecipe recipe = new ModRecipe(mod); //Creating a new recipe to be added to 
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddIngredient(ModContent.GetInstance<NightmareEssence>(), 10);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this); //Set the result of the recipe to this item (this refers to the class itself)
            recipe.AddRecipe(); //Add this recipe
        }


    }
}
