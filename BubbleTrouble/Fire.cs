using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using BubbleTrouble.ProjectStates;
using BubbleTrouble;
    
namespace BubbleTrouble
{
    class Fire : Drawable
    {
        Color BallColor;
        GameObject shooter;
        public float ccc;


        public Fire(Color ballColor, Texture2D texture, Vector2 position, Rectangle? sourceRectangle,
                        Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth, GameObject shooter)
            : base(texture, position, sourceRectangle, color, rotation, origin, new Vector2(5, 0), effects, layerDepth)
        {
            BallColor = ballColor;
            isDraw = false;
            ccc = 0;
            this.shooter = shooter;

            GameState.Update_event += Update;
            GameState.FireCollision_Event += CheckCollision;
        }

        public void CheckCollision(Ball ball)
        {
            Rectangle rec = new Rectangle((int)(Position.X - scale.X), (int)(Position.Y - scale.Y), (int)(Texture.Width * scale.X), (int)(Texture.Height * scale.Y));

            if (isDraw)
            {
                if (Position.Y - scale.Y <= 0)
                {
                    isDraw = false;
                    ccc = 0;
                    shooter.fireCount--;
                }
                if (rec.Intersects(ball.destinationRectangle) && isDraw)
                {
                    isDraw = false;
                    shooter.fireCount--;
                    ccc = 0;
                    if (ball.color == this.BallColor)
                    {
                        ball.isDraw = false;
                        if (ball.color == Color.Red)
                        {
                            S.balls.Remove(ball);
                            S.g.countPts += ball.points;
                            if ((int)(0.5 * ball.destinationRectangle.Width) > 5)
                            {
                                S.balls.Add(new Ball(ball.Position, BallColor, new Vector2(1f), 0, ball.Texture, new Rectangle((int)ball.destinationRectangle.X, (int)ball.destinationRectangle.Y, (int)(0.5 * ball.destinationRectangle.Height), (int)(0.5 * ball.destinationRectangle.Width)), 50, 50));
                                S.balls.Add(new Ball(ball.Position, BallColor, new Vector2(1f), 0, ball.Texture, new Rectangle((int)ball.destinationRectangle.X, (int)ball.destinationRectangle.Y, (int)(0.5 * ball.destinationRectangle.Height), (int)(0.5 * ball.destinationRectangle.Width)), new Vector2(5f, -10f), 50, 50));
                            }
                        }
                        else if (ball.color == Color.Blue)
                        {
                            S.balls1.Remove(ball);
                            S.k.countPts += ball.points;
                            if ((int)(0.5 * ball.destinationRectangle.Width) > 5)
                            {
                                S.balls1.Add(new Ball(ball.Position, BallColor, new Vector2(1f), 0, ball.Texture, new Rectangle((int)ball.destinationRectangle.X, (int)ball.destinationRectangle.Y, (int)(0.5 * ball.destinationRectangle.Height), (int)(0.5 * ball.destinationRectangle.Width)), 50, 50));
                                S.balls1.Add(new Ball(ball.Position, BallColor, new Vector2(1f), 0, ball.Texture, new Rectangle((int)ball.destinationRectangle.X, (int)ball.destinationRectangle.Y, (int)(0.5 * ball.destinationRectangle.Height), (int)(0.5 * ball.destinationRectangle.Width)), new Vector2(5f, -10f), 50, 50));
                            }
                        }


                    }
                    else if (ball.color == Color.Yellow)
                    {
                        ball.isDraw = false;
                        S.pointBalls.Remove(ball);
                        shooter.countPts += ball.points;

                        if ((int)(0.5 * ball.destinationRectangle.Width) > 5)
                        {
                            S.pointBalls.Add(new Ball(ball.Position, ball.color, new Vector2(1f), 0, ball.Texture, new Rectangle((int)ball.destinationRectangle.X, (int)ball.destinationRectangle.Y, (int)(0.5 * ball.destinationRectangle.Height), (int)(0.5 * ball.destinationRectangle.Width)), S.rnd.Next(0, 100), S.rnd.Next(0, 100)));
                            S.pointBalls.Add(new Ball(ball.Position, ball.color, new Vector2(1f), 0, ball.Texture, new Rectangle((int)ball.destinationRectangle.X, (int)ball.destinationRectangle.Y, (int)(0.5 * ball.destinationRectangle.Height), (int)(0.5 * ball.destinationRectangle.Width)), new Vector2(7f, -12f), S.rnd.Next(0, 100), S.rnd.Next(0, 100)));
                        }
                    }
                }
            }
        }

        public void Update()
        {
            if (isDraw)
            {
                scale = new Vector2(3, ccc += 10f);
            }
            else
            {
                ccc = 0;
            }
        }
    }
}
