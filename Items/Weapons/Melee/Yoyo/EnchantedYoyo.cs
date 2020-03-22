using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace CelestialGifts.Items.Weapons.Melee.Yoyo
{
    class EnchantedYoyo : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Magic Yo-Yo");
            DisplayName.SetDefault("Enchanted Yo-yo");
            // These are all related to gamepad controls and don't seem to affect anything else
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.useStyle = 5;
            item.width = 30;
            item.height = 30;
            item.useAnimation = 40;
            item.useTime = 40;
            item.shootSpeed = 15f;
            item.knockBack = 1f;
            item.damage = 16;
            item.rare = 3;

            item.melee = true;
            item.channel = true;
            item.noMelee = true;
            item.noUseGraphic = true;

            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(copper: 50);
            item.shoot = ModContent.ProjectileType<EnchantProj>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodYoyo);
            recipe.AddIngredient(ItemID.EnchantedSword);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodYoyo);
            recipe.AddIngredient(ItemID.Diamond, 8);
            recipe.AddIngredient(ItemID.Ruby, 8);
            recipe.AddIngredient(ItemID.Sapphire, 8);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    class EnchantProj : ModProjectile
    {

        int timer = 0;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 12f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 230f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 8f;
        }

        public override void SetDefaults()
        {
            projectile.extraUpdates = 1;
            projectile.width = 17;
            projectile.height = 17;
            projectile.aiStyle = 99;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.scale = 1;
        }
        public override void AI()
        {
            timer += 1;
            if (timer >= 60 && projectile.owner == Main.myPlayer)
            {
                timer = 0;
                projectile.netUpdate = true;
                for (int i = 0; i < 3; i++)
                {
                    // Calculate new speeds for other projectiles.
                    // Rebound at 40% to 70% speed, plus a random amount between -8 and 8
                    float speedX = -projectile.velocity.X * Main.rand.NextFloat(1f, 1.4f) + Main.rand.NextFloat(-8f, 8f);
                    float speedY = -projectile.velocity.Y * Main.rand.Next(40, 70) * 0.01f + Main.rand.Next(-20, 21) * 0.4f; // This is Vanilla code, a little more obscure.
                                                                                                                             // Spawn the Projectile.
                    Projectile.NewProjectile(projectile.position.X + speedX, projectile.position.Y + speedY, speedX * 1.3f, speedY, ProjectileID.EnchantedBeam, (int)(projectile.damage * 0.5), 0f, projectile.owner, 0f, 0f);
                }
            }
        }
        public override void PostAI()
        {
            if (Main.rand.Next(2) == 0)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 15);
                dust.noGravity = true;
                dust.scale = 1f;
                dust.alpha = 90;
            }
        }
    }
}
