using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace CelestialGifts.NPCs.Town_NPCs
{
    class AngelFairy : ModNPC
    {

        public static bool angels = true;
        public static bool demons = false;

        public override string Texture { get { return "Terraria/NPC_" + NPCID.Pixie; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Angel Fairy");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Pixie];
        }
        public override void SetDefaults()
        {
            npc.width = 20;
            npc.height = 20;
            npc.homeless = true;
            npc.townNPC = true;
            npc.lifeMax = 100;
            npc.defense = 10;
            npc.color = Color.Blue;
            npc.noGravity = false;
            animationType = NPCID.Pixie;
            npc.friendly = true;
            npc.HitSound = SoundID.NPCHit49;
            npc.DeathSound = SoundID.NPCDeath19;
            npc.aiStyle = 7;
        }

        public override string GetChat()
        {
            if(WillsWorld.WillsWorld.questsLeft == 10)
            {
                return "Hi there, I'm in need of your help.";
            }
            else if(WillsWorld.WillsWorld.questsLeft == 9)
            {
                return "So how about it?";
            }
            else if(WillsWorld.WillsWorld.questsLeft == 8)
            {
                return "Can you help?";
            }
            else
            {
                return "Pick your side yet?";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            if (WillsWorld.WillsWorld.questsLeft == 10)
            {
                button = "Help with what?";
                button2 = "";
            }
            else if (WillsWorld.WillsWorld.questsLeft == 9)
            {
                button = "How can I help?";
                button2 = "";
            }
            else if (WillsWorld.WillsWorld.questsLeft == 8)
            {
                button = "So how do I pick?";
            }
            else if (WillsWorld.WillsWorld.questsLeft == 7)
            {
                if(angels == true)
                {
                    button = "Give Angel Wing";
                }
                else if(demons == true)
                {
                    button = "Give Demon Wing";
                }
                button2 = "Cycle Option";
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                if (WillsWorld.WillsWorld.questsLeft == 10)
                {
                    Main.npcChatText = Main.worldName + " is in danger, the angels and demons of this world are after an ancient artifact that resides here. And they don't care who's killed in their path to get it";
                    WillsWorld.WillsWorld.questsLeft--;
                }
                else if (WillsWorld.WillsWorld.questsLeft == 9)
                {
                    Main.npcChatText = "While you could simply just fight off both sides that would surely mean your demise. Maybe you could pick a side? Help one out and surely you could get in with them";
                    WillsWorld.WillsWorld.questsLeft--;
                }
                else if (WillsWorld.WillsWorld.questsLeft == 8)
                {
                    Main.npcChatCornerItem = ItemID.AngelWings;
                    Main.npcChatText = "You either need to bring me the wing of either an Angel or Demon so I know who you wish to fight against";
                    WillsWorld.WillsWorld.questsLeft--;
                    angels = true;
                }
            }
            else
            {
                if (WillsWorld.WillsWorld.questsLeft == 7 && angels == true)
                {
                    angels = false;
                    demons = true;
                    Main.npcChatCornerItem = ItemID.DemonWings;
                }
                else if (WillsWorld.WillsWorld.questsLeft == 7 && demons == true)
                {
                    angels = true;
                    demons = false;
                    Main.npcChatCornerItem = ItemID.AngelWings;
                }
            }
        }
    }
}
