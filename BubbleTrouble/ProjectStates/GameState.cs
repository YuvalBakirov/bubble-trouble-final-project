using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using OrganizeProject;

namespace BubbleTrouble.ProjectStates
{
    public class GameState : State
    {
        public static event HandleCollision Collision_Event = null;
        public static event HandleUpdate Update_event = null;
        public static event HandleCollisionball FireCollision_Event = null;
        public static event HandleCollisionBox BoxCollision_Event = null;
        public static event HandlePlayerCollision PlayerCollision_Event = null;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Drawable background;

        int lastBoxTime;
        int boxDelay = 10000;
        int startTime = S.time + 3000;
        int lastMinute = S.time + 60000;
        bool isYellowBalls = false;
        public static bool isBlackBall = false;
        public Camera cam;
        //Ball blackBall;


        public GameState(Game1 game) : base(S.cm, S.gd, game)
        {
            S.gameState = this;

            background = new Drawable(game.Content.Load<Texture2D>("Goblin/BackGround"), new Vector2(0, 0), null, Color.White, 0, Vector2.Zero, new Vector2(3f), SpriteEffects.None, 0);
            //TheDic.Init();
            S.supBox = new SurpriseBox[7];

            S.balls = new List<Ball>();
            S.balls1 = new List<Ball>();
            S.pointBalls = new List<Ball>();

            S.Create_Ground_Line(3f);

            lastBoxTime = 0;


            S.g = new GameObject(Heros.Goblin, new Vector2(2500, 200), Color.Red, 0, new Vector2(2f), 0, new UserKeys(Keys.Right, Keys.Left, Keys.Up, Keys.Down, Keys.LeftShift, Keys.Space));
            S.k = new GameObject(Heros.Man, new Vector2(2000, 200), Color.Blue, 0, new Vector2(2f), 0, new BotKeyboard());
            BotKeyboard botKey = (BotKeyboard)S.k.keyboard;
            botKey.InitBot(S.k);
            cam = new Camera(S.g);

            S.balls.Add(new Ball(new Vector2(700, 20), Color.Red, new Vector2(1f), 0, game.Content.Load<Texture2D>("Goblin/Ball2"), new Rectangle(800, 20, 100, 100), 50, 50));
            S.balls.Add(new Ball(new Vector2(600, 20), Color.Red, new Vector2(1f), 0, game.Content.Load<Texture2D>("Goblin/Ball2"), new Rectangle(700, 20, 100, 100), 50, 50));
            S.balls.Add(new Ball(new Vector2(500, 20), Color.Red, new Vector2(1f), 0, game.Content.Load<Texture2D>("Goblin/Ball2"), new Rectangle(600, 20, 100, 100), 50, 50));
            S.balls.Add(new Ball(new Vector2(400, 20), Color.Red, new Vector2(1f), 0, game.Content.Load<Texture2D>("Goblin/Ball2"), new Rectangle(500, 20, 100, 100), 50, 50));

            S.balls1.Add(new Ball(new Vector2(300, 20), Color.Blue, new Vector2(1f), 0, game.Content.Load<Texture2D>("Goblin/Ball2"), new Rectangle(400, 20, 100, 100), 50, 50));
            S.balls1.Add(new Ball(new Vector2(200, 20), Color.Blue, new Vector2(1f), 0, game.Content.Load<Texture2D>("Goblin/Ball2"), new Rectangle(300, 20, 100, 100), 50, 50));
            S.balls1.Add(new Ball(new Vector2(100, 20), Color.Blue, new Vector2(1f), 0, game.Content.Load<Texture2D>("Goblin/Ball2"), new Rectangle(200, 20, 100, 100), 50, 50));
            S.balls1.Add(new Ball(new Vector2(50, 20), Color.Blue, new Vector2(1f), 0, game.Content.Load<Texture2D>("Goblin/Ball2"), new Rectangle(100, 20, 100, 100), 50, 50));


            S.supBox[0] = new SurpriseBox(new Vector2(S.rnd.Next(0, (int)(850 * S.scale)), 0), Color.White, new Vector2(0.4f), 0, game.Content.Load<Texture2D>("SupriseBox/TwoArrows"), new Rectangle(200, 200, 40, 40), 0);
            S.supBox[1] = new SurpriseBox(new Vector2(S.rnd.Next(0, (int)(850 * S.scale)), 0), Color.White, new Vector2(0.4f), 0, game.Content.Load<Texture2D>("SupriseBox/MoreHealth"), new Rectangle(200, 200, 40, 40), 1);
            S.supBox[2] = new SurpriseBox(new Vector2(S.rnd.Next(0, (int)(850 * S.scale)), 0), Color.White, new Vector2(0.4f), 0, game.Content.Load<Texture2D>("SupriseBox/MorePoints"), new Rectangle(200, 200, 40, 40), 2);
            S.supBox[3] = new SurpriseBox(new Vector2(S.rnd.Next(0, (int)(850 * S.scale)), 0), Color.White, new Vector2(0.4f), 0, game.Content.Load<Texture2D>("SupriseBox/MoreTime"), new Rectangle(200, 200, 40, 40), 3);
            S.supBox[4] = new SurpriseBox(new Vector2(S.rnd.Next(0, (int)(850 * S.scale)), 0), Color.White, new Vector2(0.4f), 0, game.Content.Load<Texture2D>("SupriseBox/Freeze"), new Rectangle(200, 200, 40, 40), 4);
            S.supBox[5] = new SurpriseBox(new Vector2(S.rnd.Next(0, (int)(850 * S.scale)), 0), Color.White, new Vector2(0.4f), 0, game.Content.Load<Texture2D>("SupriseBox/LessHealth"), new Rectangle(200, 200, 40, 40), 5);
            S.supBox[6] = new SurpriseBox(new Vector2(S.rnd.Next(0, (int)(850 * S.scale)), 0), Color.White, new Vector2(0.4f), 0, game.Content.Load<Texture2D>("SupriseBox/LessPoints"), new Rectangle(200, 200, 40, 40), 6);


            S.supBox[0].isDraw = false;
            S.supBox[1].isDraw = false;
            S.supBox[2].isDraw = false;
            S.supBox[3].isDraw = false;
            S.supBox[4].isDraw = false;
            S.supBox[5].isDraw = false;
            S.supBox[6].isDraw = false;
        }



        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, cam.Mat);
            background.Draw();
            if (S.time >= 3000)
            {
                S.g.UpdateState();
                if (S.balls.Count != 0)
                    for (int i = 0; i < S.balls.Count; i++)
                    {
                        S.balls[i].UpdateBall();
                    }

                S.k.UpdateState();
                if (S.balls1.Count != 0)
                    for (int i = 0; i < S.balls1.Count; i++)
                    {
                        S.balls1[i].UpdateBall();
                    }

                if (S.pointBalls.Count != 0)
                    for (int i = 0; i < S.pointBalls.Count; i++)
                    {
                        S.pointBalls[i].UpdateBall();
                    }

                if (isBlackBall)
                {
                    S.blackBall.UpdateBall();
                }
            }

            S.supBox[0].Draw();
            S.supBox[1].Draw();
            S.supBox[2].Draw();
            S.supBox[3].Draw();
            S.supBox[4].Draw();
            S.supBox[5].Draw();
            S.supBox[6].Draw();



            spriteBatch.End();
            spriteBatch.Begin();
            spriteBatch.DrawString(S.font, "Health: " + S.g.count1, new Vector2(900, 5), Color.Brown);
            spriteBatch.DrawString(S.font, "Points: " + S.g.countPts, new Vector2(900, 25), Color.Brown);
            spriteBatch.DrawString(S.font, "Max Shots: " + S.g.maxFireCount, new Vector2(900, 45), Color.Brown);
            if (S.time > 3000)
                spriteBatch.DrawString(S.font, "" + (S.gameCDTimer - S.time) / 1000, new Vector2(480, 5), Color.Black);
            else
            {
                if (S.gameCDTimer - S.time >= 0)
                    spriteBatch.DrawString(S.font, "" + (startTime - S.time) / 1000, new Vector2(480, 15), Color.Black);

            }


            spriteBatch.DrawString(S.font, "Max Shots: " + S.k.maxFireCount, new Vector2(10, 45), Color.Blue);
            spriteBatch.DrawString(S.font, "Health: " + S.k.count1, new Vector2(10, 5), Color.Blue);
            spriteBatch.DrawString(S.font, "Points: " + S.k.countPts, new Vector2(10, 25), Color.Blue);
        }

        public void EndOfGame()
        {
            if (S.gameCDTimer - S.time <= 0)
            {
                if (S.g.countPts > S.k.countPts)
                    game.ChangeState(new EndState(game, this, 1));
                else if (S.g.countPts < S.k.countPts)
                    game.ChangeState(new EndState(game, this, 2));
                else
                    game.ChangeState(new EndState(game, this, 0));
            }

            if (S.g.count1 == 0)
                game.ChangeState(new EndState(game, this, 2));
            if (S.k.count1 == 0)
                game.ChangeState(new EndState(game, this, 1));
        }

        public override void PostUpdate(GameTime gameTime)
        {
        }

        public override void Update(GameTime gameTime)
        {
            cam.Update();
            S.time = (int)gameTime.TotalGameTime.TotalMilliseconds;

            if (S.time >= 3000)
            {
                if (S.time - lastBoxTime > boxDelay)
                {
                    S.i = S.rnd.Next(0, 7);
                    S.supBox[S.i].Position = new Vector2(S.rnd.Next(0, (int)(850 * S.scale)), 0);
                    S.supBox[S.i].isDraw = true;
                    lastBoxTime = S.time;

                }
                S.supBox[S.i].UpdateBox();
            }

            if ((S.gameCDTimer - S.time) / 1000 == 100 && isYellowBalls == false)
            {
                isYellowBalls = true;
                S.pointBalls.Add(new Ball(new Vector2(350, 20), Color.Yellow, new Vector2(1f), 0, game.Content.Load<Texture2D>("Goblin/Ball2"), new Rectangle(350, 20, 100, 100), new Vector2(-7f, -12f), S.rnd.Next(1, 100), S.rnd.Next(1, 100)));
                S.pointBalls.Add(new Ball(new Vector2(450, 20), Color.Yellow, new Vector2(1f), 0, game.Content.Load<Texture2D>("Goblin/Ball2"), new Rectangle(550, 20, 100, 100), new Vector2(-7f, -12f), S.rnd.Next(1, 100), S.rnd.Next(1, 100)));
            }



            if (((S.gameCDTimer - S.time) / 1000) % 30 == 0 && isBlackBall == false)
            {
                isBlackBall = true;
                S.blackBall = new Ball(new Vector2(0, S.ground[0] - 40), Color.Black, new Vector2(1f), 0, game.Content.Load<Texture2D>("Goblin/Ball2"), new Rectangle(0, S.ground[0] - 40, 30, 30), new Vector2(20f, 0f), 0, 50);
            }
            if (isBlackBall && S.blackBall.countHitsWall >= 2)
            {
                S.blackBall.countHitsWall = 0;
                S.blackBall.isDraw = false;
                isBlackBall = false;
            }




            if (PlayerCollision_Event != null)
            {
                PlayerCollision_Event(S.g);
                PlayerCollision_Event(S.k);
            }

            if (BoxCollision_Event != null)
            {
                BoxCollision_Event(S.g);
                BoxCollision_Event(S.k);
            }


            if (Collision_Event != null)
            {
                Collision_Event(S.g);
                Collision_Event(S.k);
            }

            if (Update_event != null)
            {
                Update_event();
            }

            if (FireCollision_Event != null)
            {
                for (int i = 0; i < S.balls.Count; i++)
                    FireCollision_Event(S.balls[i]);

                for (int i = 0; i < S.balls1.Count; i++)
                    FireCollision_Event(S.balls1[i]);

                for (int i = 0; i < S.pointBalls.Count; i++)
                    FireCollision_Event(S.pointBalls[i]);
            }

            EndOfGame();
        }



    }
}
