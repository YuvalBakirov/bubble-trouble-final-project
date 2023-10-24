using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using BubbleTrouble.ProjectStates;
using System.Drawing;

namespace BubbleTrouble
{
    public class Ball : Drawable
    {
        #region Data
        float gravitaion;
        public Vector2 velocity;
        public int points, health;
        Microsoft.Xna.Framework.Color uniqueColor;
        public int countHitsWall = 0;
        #endregion

        #region Ctors
        public Ball(Vector2 position, Microsoft.Xna.Framework.Color color, Vector2 scale, float layerDepth, Texture2D Texture, Microsoft.Xna.Framework.Rectangle Rectangle, int points, int health)
            : base(position, color, scale, layerDepth, Texture, Rectangle)
        {
            Position = position;
            gravitaion = 0.5f;
            velocity.X = -5f;
            velocity.Y = -10f;
            this.points = points;
            this.health = health;
            this.uniqueColor = color;
            countHitsWall = 0;

            GameState.Collision_Event += Collision;
        }
        public Ball(Vector2 position, Microsoft.Xna.Framework.Color color, Vector2 scale, float layerDepth, Texture2D Texture, Microsoft.Xna.Framework.Rectangle Rectangle, Vector2 velocity, int points, int health)
            : base(position, color, scale, layerDepth, Texture, Rectangle)
        {
            Position = position;
            gravitaion = 0.5f;
            this.velocity.X = velocity.X;
            this.velocity.Y = velocity.Y;
            this.points = points;
            this.health = health;
            this.uniqueColor = color;
            countHitsWall = 0;

            GameState.Collision_Event += Collision;
        }
        #endregion

        public void UpdateBall()
        {
            Update();
        }


        public void Update()
        {
            Microsoft.Xna.Framework.Rectangle myRectangle = destinationRectangle;
            myRectangle.X = myRectangle.X + (int)velocity.X;
            myRectangle.Y = myRectangle.Y + (int)velocity.Y;
            destinationRectangle = myRectangle;

            if (myRectangle.X <= 0)
            {
                velocity.X = -velocity.X;
                myRectangle.X = 0;
                countHitsWall++;
            }

            if (myRectangle.X + myRectangle.Width >= S.screenWidth * S.scale)
            {
                velocity.X = -velocity.X;
                myRectangle.X = S.screenWidth - myRectangle.Width;
                countHitsWall++;
            }

            if (myRectangle.Y <= 0)
            {
                velocity.Y = -velocity.Y;
                myRectangle.Y = 0;
            }
            if (myRectangle.Y + myRectangle.Height >= S.ground[myRectangle.X])
            {
                velocity.Y = -velocity.Y;
                myRectangle.Y = S.ground[myRectangle.X] - myRectangle.Height;
            }


            Draw();
        }
        public void Collision(GameObject obj)
        {
            if (obj.isDraw == true && isDraw)
            {
                Texture2D myTex = Texture;
                Microsoft.Xna.Framework.Rectangle myRectangle = destinationRectangle;
                Microsoft.Xna.Framework.Rectangle playerrec = new Microsoft.Xna.Framework.Rectangle((int)(obj.Position.X - obj.Origin.X), (int)(obj.Position.Y - obj.Origin.Y), obj.Anime.Recs[0].Width, obj.Anime.Recs[0].Height);
                if (myRectangle.Intersects(playerrec) && S.time - obj.lastHitTime >= obj.hitDelay)
                {
                    if (destinationRectangle.X + destinationRectangle.Width / 2 * scale.Length() <= obj.Position.X - obj.Origin.X)
                    {
                        velocity.X = -Math.Abs(velocity.X);
                    }
                    else if (destinationRectangle.X >= obj.Position.X + obj.Origin.X)
                    {
                        velocity.X = Math.Abs(velocity.X);
                    }
                    else
                        velocity.Y = -Math.Abs(velocity.Y);
                    obj.lastHitTime = S.time;


                    if (obj.ballColor == color || uniqueColor == Microsoft.Xna.Framework.Color.Yellow || uniqueColor == Microsoft.Xna.Framework.Color.Black)
                    {
                        if (obj.count1 - this.health > 0)
                            obj.count1 -= this.health;
                        else
                            obj.count1 = 0;

                        obj.color = Microsoft.Xna.Framework.Color.Red;
                    }
                }
            }
        }



        public override void Draw()
        {
            if (isDraw)
                S.sb.Draw(Texture, destinationRectangle, color);
            //base.Draw();
        }
    }
}
