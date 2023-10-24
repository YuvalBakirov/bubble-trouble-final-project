using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using BubbleTrouble.ProjectStates;
namespace BubbleTrouble
{

    class BotKeyboard : BaseKeys    
    {
        public GameObject bot;
        Vector2 direction;
        Ball target;
        float tagetDist;
        bool isShot;
        int shootDelay = 1500;
        int shootTime = 0;
        int findTargetTime = 0;
        int findDelay = 5000;
        bool isJump;


        public void InitBot(GameObject bot)
        {
            direction = Vector2.Zero;
            this.bot = bot;
            this.target = null;
            this.tagetDist = 0;
            isShot = false;

            GameState.Update_event += Update;
        }

        public BotKeyboard() : base()
        {
        }

        public override Boolean RightPressed()
        {
            return (direction.X > 0);
        }
        public override Boolean LeftPressed()
        {
            return (direction.X < 0);
        }
        public override Boolean UpPressed()
        {
            if (isJump)
            {
                isJump = false;
                return true;
            }
            return false;

        }
        public override Boolean DownPressed()
        {

            return false;
        }
        public override Boolean RightReleased()
        {
            return false;
        }
        public override Boolean LeftReleased()
        {
            return false;
        }
        public override Boolean UpReleased()
        {
            return false;
        }
        public override Boolean DownReleased()
        {
            return false;
        }
        public override Boolean ShiftPressed()
        {
            return true;
        }
        public override Boolean SpacePressed()
        {
            return isShot;
        }
        public void Update()
        {
            if (GameState.isBlackBall)
            {
                if (S.blackBall.destinationRectangle.X < bot.Position.X && S.blackBall.velocity.X > 0)
                {
                    if (bot.Position.X - S.blackBall.destinationRectangle.X <= 350)
                        isJump = true;
                }
                if (S.blackBall.destinationRectangle.X > bot.Position.X && S.blackBall.velocity.X < 0)
                {
                    if (S.blackBall.destinationRectangle.X - bot.Position.X <= 350)
                        isJump = true;
                }
            }


            if (S.time - findTargetTime >= findDelay)
            {
                findClosestBall();
                findTargetTime = S.time;
            }
            if (isShot)
            {
                isShot = false;
                //shootTime = S.time;
            }
            else if (target != null)
            {
                if (bot.Position.X > target.destinationRectangle.X && target.velocity.X > 0)
                {
                    direction.X = -1;
                    if (tagetDist <= 500f)
                        direction.X = 1;

                    if (tagetDist <= 300f)
                    {
                        direction.X = 0;
                        direction.Y = 0;
                        isShot = true;
                        shootTime = S.time;
                    }
                }
                else if (bot.Position.X < target.destinationRectangle.X && target.velocity.X < 0)
                {
                    direction.X = 1;
                    if (tagetDist <= 500f)
                        direction.X = -1;

                    if (tagetDist <= 300f)
                    {
                        direction.X = 0;
                        direction.Y = 0;
                        isShot = true;
                        shootTime = S.time;
                    }
                }
                if (bot.Position.X < target.destinationRectangle.X && target.velocity.X > 0)
                {
                    direction.X = 1;
                }
                if (bot.Position.X > target.destinationRectangle.X && target.velocity.X < 0)
                {
                    direction.X = -1;
                }
            }
        }

        public void findClosestBall()
        {

            float minDist = float.MaxValue;
            float currDist;
            for (int i = 0; i < S.balls1.Count; i++)
            {

                currDist = Math.Abs(bot.Position.X - S.balls1[i].destinationRectangle.X);

                if (minDist > currDist)
                {
                    minDist = currDist;
                    target = S.balls1[i];
                    tagetDist = minDist;
                }
            }

            for (int i = 0; i < S.pointBalls.Count; i++)
            {
                currDist = Math.Abs(bot.Position.X - S.pointBalls[i].destinationRectangle.X);
                if (minDist > currDist)
                {
                    minDist = currDist;
                    target = S.pointBalls[i];
                    tagetDist = minDist;
                }
            }
        }
    }
}
