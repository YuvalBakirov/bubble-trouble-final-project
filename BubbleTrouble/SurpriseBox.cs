using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;
using System.Collections.Generic;
using BubbleTrouble.ProjectStates;
using BubbleTrouble;

namespace OrganizeProject
{
    class SurpriseBox : Drawable
    {
        #region Data
        float gravitaion;
        Vector2 drc;
        int timeDisappearBox;
        public int numOfBox;
        #endregion

        #region Ctors
        public SurpriseBox(Vector2 position, Color color, Vector2 scale, float layerDepth, Texture2D Texture, Rectangle Rectangle, int numOfBox)
            : base(position, color, scale, layerDepth, Texture, Rectangle)
        {
            Position = position;
            gravitaion = 0.01f;
            drc = Vector2.Zero;
            this.numOfBox = numOfBox;
            timeDisappearBox = S.gameCDTimer - 5000;

            GameState.BoxCollision_Event += Collision;
        }
        #endregion

        public void UpdateBox()
        {
            Move();
            drc = Vector2.Zero;
        }
        private void Move()
        {
            if (isDraw)
            {
                Gravity();
            }
            Position += drc;
        }

        private void Gravity()
        {
            drc.Y += gravitaion;
            gravitaion += 0.01f;
            if (Position.Y + (Texture.Height * scale.Length()) >= S.ground[(int)Position.X])
            {
                gravitaion = 0;
                if ((timeDisappearBox - S.time) / 1000 == 5)
                    isDraw = false;
            }

        }

        public void Collision(GameObject obj)
        {
            if (obj.isDraw == true && isDraw)
            {
                Rectangle myRectangle = new Rectangle((int)Position.X, (int)Position.Y, (int)(Texture.Width * scale.Length()), (int)(Texture.Height * scale.Length()));
                Rectangle playerrec = new Rectangle((int)(obj.Position.X - obj.Origin.X), (int)(obj.Position.Y - obj.Origin.Y), obj.Anime.Recs[0].Width, obj.Anime.Recs[0].Height);

                if (myRectangle.Intersects(playerrec))
                {

                    isDraw = false;
                    gravitaion = 0;

                    if (numOfBox == 0)
                        obj.AddFire();
                    else if (numOfBox == 1)
                        obj.count1 += 50;
                    else if (numOfBox == 2)
                        obj.countPts += 50;
                    else if (numOfBox == 3)
                        S.gameCDTimer += 20000;
                    else if (numOfBox == 4)
                        obj.freezeTime = S.time + 5000;
                    else if (numOfBox == 5)
                        obj.count1 -= 50;
                    else if (numOfBox == 6)
                        obj.countPts -= 50;

                    obj.color = Color.Yellow;
                }
            }
        }
    }
}
