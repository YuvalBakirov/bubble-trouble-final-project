using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace BubbleTrouble
{
    public class Button : Component
    {
        private MouseState currentMouse;

        private SpriteFont font;

        private bool isHovering;

        private MouseState previousMouse;

        private Texture2D texture;

        public event EventHandler Click;

        public bool Clicked { get; set; }

        public Color PenColor { get; set; }

        public Vector2 Position { get; set; }

        public float Scale { get; set; }

        public Color color { get; set; }

        public string Text { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X - texture.Width / 2 * (int)Scale, (int)Position.Y - texture.Height / 2 * (int)Scale, texture.Width * (int)Scale, texture.Height * (int)Scale);
            }
        }


        public Button(Texture2D texture)
        {
            this.texture = texture;
            PenColor = Color.Black;
        }

        public Button(Texture2D texture, SpriteFont font)
        {
            this.texture = texture;
            this.font = font;
            PenColor = Color.Black;
        }

        public Button(Button button)
        {
            this.texture = button.texture;
            this.Position = button.Position;
            this.Scale = button.Scale;
            this.Text = button.Text;
            this.font = button.font;
            this.PenColor = button.PenColor;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Draws the rectangle
            spriteBatch.Draw(texture, Position, null, color, 0, new Vector2(texture.Width / 2, texture.Height / 2), Scale, SpriteEffects.None, 0);
        }

        public override void Update(GameTime gameTime)
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);

            if (!Clicked)
            {
                isHovering = false;
                color = Color.White;

                if (mouseRectangle.Intersects(Rectangle))
                {
                    isHovering = true;
                    color = Color.Gray;

                    if (currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed)
                        Click?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}
