using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using BubbleTrouble.ProjectStates;
using BubbleTrouble;
using OrganizeProject;

namespace BubbleTrouble
{
    public interface IFocus
    {
        Vector2 Position { get; }
    }
    public delegate void HandleCollision(GameObject obj);
    public delegate void HandleCollisionball(Ball obj);
    public delegate void HandleUpdate();
    public delegate void HandleCollisionBox(GameObject obj);
    public delegate void HandlePlayerCollision(GameObject obj);


    public enum Heros { Goblin, Man }
    public enum States { Walk, Fire, Stance }
    public enum Tempo { Slow = 7, Medium = 5, High = 2 }

    static class S
    {
        #region Data
        public static SpriteBatch sb;
        public static GraphicsDeviceManager gp;
        public static ContentManager cm;
        public static int[] ground;

        public static int screenWidth;
        public static int screenHeight;

        public static GraphicsDevice gd;
        public static Random rnd = new Random();

        public static List<Ball> balls, balls1, pointBalls;

        public static GameObject g, k;

        public static SurpriseBox[] supBox;

        public static SpriteFont font;


        public static int i;

        public static int time = 0;

        public static float scale;

        public static int gameCDTimer = S.time + 125000;

        public static int winner = 0;

        public static GameState gameState;

        public static Ball blackBall;

        #endregion

        public static void Create_Ground_Line(float scale)
        {
            S.scale = scale;
            Texture2D floor = cm.Load<Texture2D>("Goblin/BackGround_Floor");
            ground = new int[(int)(floor.Width * scale)];
            Color[] color = new Color[floor.Width * floor.Height];
            floor.GetData<Color>(color);
            for (int i = 0; i < floor.Height; i++)
            {
                for (int j = 0; j < floor.Width; j++)
                {
                    if (color[floor.Width * i + j] != Color.White && color[floor.Width * (i - 1) + j] == Color.White)
                    {
                        for (int k = 0; k < scale; k++)
                        {
                            ground[(int)(j * scale) + k] = (int)(i * scale);
                        }
                    }
                }
            }
        }
    }
}
