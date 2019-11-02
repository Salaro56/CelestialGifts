using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace CelestialGifts.Projectiles.Minions
{
    public abstract class GroundMelee : MinionAI
    {
        protected float idleAccel = 0.05f;
        protected float spacingMult = 1f;
        protected float viewDist = 400f;
        protected float chaseDist = 200f;
        protected float chaseAccel = 6f;
        protected float inertia = 40f;

        public virtual void CreateDust()
        {
        }
        public virtual void SelectFrame()
        {
        }

        public override void Behavior()
        {
            Player player = Main.player[projectile.owner];
            float spacing = (float)(projectile.width * spacingMult);
            //sets position of other minions
            for (int k = 0; k < 1000; k++)
            {
                Projectile otherProj = Main.projectile[k];
                if (k != projectile.whoAmI && otherProj.active && otherProj.owner == projectile.owner && otherProj.type == projectile.type && Math.Abs(projectile.position.X - otherProj.position.X) + Math.Abs(projectile.position.Y - otherProj.position.Y) < spacing)
                {
                    if (projectile.position.X < Main.projectile[k].position.X)
                    {
                        projectile.velocity.X -= idleAccel;
                    }
                    else
                    {
                        projectile.velocity.X += idleAccel;
                    }
                    if (projectile.position.Y < Main.projectile[k].position.Y)
                    {
                        projectile.velocity.Y -= idleAccel;
                    }
                    else
                    {
                        projectile.velocity.Y += idleAccel;
                    }
                }
            }
            Vector2 targetPos = projectile.position;
            float targetDist = viewDist;
            bool target = false;
            projectile.tileCollide = true;
        }
    }
}
