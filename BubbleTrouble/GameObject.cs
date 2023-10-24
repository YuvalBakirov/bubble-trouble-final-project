using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;
using System.Collections.Generic;
using BubbleTrouble.ProjectStates;
using BubbleTrouble;
using System.Xml.Linq;

namespace BubbleTrouble
{
    public class GameObject : Animation
    {
        #region Data
        public Heros hero;
        public BaseKeys keyboard;
        Vector2 drc;
        float gravitaion;
        Fire fire;
        Texture2D pointTex;
        public Color ballColor;
        public int count1, countPts;
        public bool isHit;
        public int lastHitTime;
        public int hitDelay = 1000;

        public int fireCount;
        public int maxFireCount;
        public int freezeTime;
        int shootDelay = 500;
        int lastShotTime;

        float velocityX;
        float velocityY;

        float accelerationY;

        float jumpVelocity;
        List<Fire> playerShots;

        //public int redTime;

        #endregion

        #region Ctors
        public GameObject(Heros hero, Vector2 position, Color color, float rotation, Vector2 scale, float layerDepth, BaseKeys keyboard)
            : base(hero, States.Stance, position, rotation, scale, layerDepth)
        {
            this.hero = hero;
            this.keyboard = keyboard;
            Position = position;

            gravitaion = 0.5f;

            ballColor = color;

            pointTex = new Texture2D(S.gd, 1, 1);
            pointTex.SetData(new Color[] { Color.White });
            fire = new Fire(ballColor, pointTex, position, null, Color.Black, MathHelper.Lerp(0, 0.01f * (float)S.rnd.NextDouble(), 1f), new Vector2(0.5f, 1), new Vector2(1f), SpriteEffects.None, 1, this);
            fire.isDraw = false;
            playerShots = new List<BubbleTrouble.Fire>();
            playerShots.Add(fire);
            count1 = 1000;
            countPts = 0;
            fireCount = 0;
            maxFireCount = 1;
            freezeTime = 0;
            lastShotTime = 0;

            drc = new Vector2(1, 1);
            accelerationY = 0.16f;
            velocityX = 0;
            velocityY = 0;
            jumpVelocity = -5f;

            GameState.PlayerCollision_Event += PlayerCollision;

        }
        #endregion

        public void UpdateState()
        {
            if (S.time - lastHitTime > 1000)
                this.color = Color.White;


            if (freezeTime == 0)
            {
                Input();
                Move();

            }
            else
            {
                if (freezeTime == S.time)
                    freezeTime = 0;
            }

            base.Update();

            for (int i = 0; i < playerShots.Count; i++)
            {
                if (playerShots[i].isDraw)
                    playerShots[i].Draw();
            }
        }

        private void Input()
        {
            if (keyboard.LeftPressed())
            {
                if (keyboard.ShiftPressed())
                {
                    if ((Anime != TheDic.Big[hero][States.Walk] || Effects == SpriteEffects.None))
                    {
                        CurrentIndex = 0;
                        CurrentFrame = 0;
                        Effects = SpriteEffects.FlipHorizontally;
                    }
                    velocityX = -6;
                    Anime = TheDic.Big[hero][States.Walk];


                    if (keyboard.UpPressed() && Position.Y == S.ground[(int)Position.X])
                    {
                        velocityY = jumpVelocity;
                    }
                }
                else
                {
                    if ((Anime != TheDic.Big[hero][States.Walk] || Effects == SpriteEffects.None))
                    {
                        CurrentIndex = 0;
                        CurrentFrame = 0;
                        Effects = SpriteEffects.FlipHorizontally;
                    }
                    velocityX = -5;
                    Anime = TheDic.Big[hero][States.Walk];

                    if (keyboard.UpPressed() && Position.Y == S.ground[(int)Position.X])
                    {
                        velocityY = jumpVelocity;
                    }
                }
            }
            else if (keyboard.RightPressed())
            {
                if (keyboard.ShiftPressed())
                {
                    if ((Anime != TheDic.Big[hero][States.Walk] || Effects == SpriteEffects.FlipHorizontally))
                    {
                        CurrentIndex = 0;
                        CurrentFrame = 0;
                        Effects = SpriteEffects.None;
                    }
                    velocityX = 6;
                    Anime = TheDic.Big[hero][States.Walk];

                    if (keyboard.UpPressed() && Position.Y == S.ground[(int)Position.X])
                    {
                        velocityY = jumpVelocity;
                    }
                }
                else
                {
                    if ((Anime != TheDic.Big[hero][States.Walk] || Effects == SpriteEffects.FlipHorizontally))
                    {
                        CurrentIndex = 0;
                        CurrentFrame = 0;
                        Effects = SpriteEffects.None;
                    }
                    velocityX = 5;
                    Anime = TheDic.Big[hero][States.Walk];

                    if (keyboard.UpPressed() && Position.Y == S.ground[(int)Position.X])
                    {
                        velocityY = jumpVelocity;
                    }
                }
            }
            else if (((keyboard.SpacePressed()) && Anime != TheDic.Big[hero][States.Fire]) && S.time - lastShotTime > shootDelay)
            {
                lastShotTime = S.time;
                CurrentIndex = 0;
                CurrentFrame = 0;
                Anime = TheDic.Big[hero][States.Fire];
                Effects = SpriteEffects.None;
                if (Position.Y == S.ground[(int)Position.X] && fireCount < maxFireCount && playerShots[fireCount].isDraw == false)
                {
                    playerShots[fireCount].Position = Position;
                    playerShots[fireCount].isDraw = true;
                    playerShots[fireCount].ccc = 0;
                    fireCount++;
                }

                if (keyboard.UpPressed() && Position.Y == S.ground[(int)Position.X])
                {
                    velocityY = jumpVelocity;
                }
            }
            else if (keyboard.UpPressed() && Position.Y == S.ground[(int)Position.X])
            {
                velocityY = jumpVelocity;
            }
            else if (Anime != TheDic.Big[hero][States.Stance])
            {
                Anime = TheDic.Big[hero][States.Stance];
                CurrentIndex = 0;
                CurrentFrame = 0;
            }
            Vector2 pos = Position;

            if (Position.X + 5 * velocityX >= S.screenWidth * S.scale)
                pos.X = S.screenWidth * S.scale - 5 * velocityX;

            if (Position.X + 5 * velocityX <= 0)
                pos.X = -5 * velocityX;

            Position = pos;

        }

        private void Move()
        {
            Gravity();

            Position += new Vector2(drc.X * velocityX, drc.Y * velocityY);
            velocityX = 0;

        }



        private void Gravity()
        {
            if (this.Position.Y + velocityY < S.ground[(int)Position.X])
            {
                velocityY += accelerationY;
            }
            else
            {
                Position = new Vector2(Position.X, S.ground[(int)Position.X]);
                velocityY = 0;
            }
        }

        public void AddFire()
        {
            Fire fire2 = new Fire(ballColor, pointTex, Position, null, Color.Black, MathHelper.Lerp(0, 0.01f * (float)S.rnd.NextDouble(), 1f), new Vector2(0.5f, 1), new Vector2(1f), SpriteEffects.None, 1, this);
            fire2.isDraw = false;
            playerShots.Add(fire2);
            if (maxFireCount < 3)
                maxFireCount++;
        }

        public void PlayerCollision(GameObject obj)
        {
            Rectangle myRectangle = destinationRectangle;
            destinationRectangle = myRectangle;
            if (myRectangle.Intersects(obj.destinationRectangle))
            {
                if (myRectangle.X + myRectangle.Width >= obj.Position.X)
                {
                    myRectangle.X = (int)obj.Position.X + myRectangle.Width;
                }

                if (myRectangle.X + myRectangle.Width <= obj.Position.X)
                {
                    myRectangle.X = (int)obj.Position.X - myRectangle.Width;
                }
            }

        }
    }
}

