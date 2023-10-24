using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace BubbleTrouble
{
    public class Drawable : IFocus
    {
        #region Data
        public Texture2D Texture { get; set; }
        public Rectangle? SourceRectangle { get; set; }
        public Rectangle destinationRectangle { get; set; }
        public Vector2 Origin { get; set; }
        public SpriteEffects Effects { get; set; }
        public Vector2 Position { get; set; }
        public Color color { get; set; }
        public float rotation { get; set; }
        public Vector2 scale { get; set; }
        public float layerDepth { get; set; }

        public bool isDraw { get; set; }

        public SpriteFont font { get; set; }
        public string text { get; set; }

        #endregion

        #region Ctors
        public Drawable(Vector2 position, Color color, float rotation, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            this.Position = position;
            this.color = color;
            this.rotation = rotation;
            this.scale = scale;
            this.Effects = effects;
            this.layerDepth = layerDepth;
            isDraw = true;
        }

        public Drawable(Texture2D texture, Vector2 position, Rectangle? sourceRectangle,
                        Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            Texture = texture;
            this.Position = position;
            SourceRectangle = sourceRectangle;
            this.color = color;
            this.rotation = rotation;
            Origin = origin;
            this.scale = scale;
            this.Effects = effects;
            isDraw = true;
            this.layerDepth = layerDepth;

        }

        public Drawable(Color color, float rotation, Vector2 scale, float layerDepth)
        {
            this.color = color;
            this.rotation = rotation;
            this.scale = scale;
            this.layerDepth = layerDepth;
            isDraw = true;

        }

        public Drawable(Vector2 position, Color color, Vector2 scale, float layerDepth, Texture2D texture, Rectangle destinationRectangle)
        {
            this.Position = position;
            this.color = color;
            this.scale = scale;
            this.layerDepth = layerDepth;
            this.Texture = texture;
            this.destinationRectangle = destinationRectangle;
            isDraw = true;
        }

        public Drawable(Vector2 position, Color color)
        {
            this.Position = position;
            this.color = color;

            isDraw = true;
        }

        public Drawable(Vector2 position, Color color, SpriteFont font)
        {
            Position = position;
            this.color = color;
            this.font = font;
            this.text = text;
        }
        #endregion

        public virtual void Draw()
        {
            if (isDraw && Texture != null)
            {
                S.sb.Draw(
                        Texture, Position, SourceRectangle,
                        color, rotation, Origin,
                        scale, Effects, layerDepth);
            }
        }
    }
}
