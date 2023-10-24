using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;
using System.Collections.Generic;
using BubbleTrouble.ProjectStates;

namespace BubbleTrouble
{
    public class Animation : Drawable
    {
        #region Data
        public Page Anime { get; set; }
        public int CurrentIndex { get; set; }
        public int CurrentFrame { get; set; }
        #endregion

        #region Ctors
        public Animation(Heros hero, States state, Vector2 position, Color color, float rotation, Vector2 scale, SpriteEffects effects, float layerDepth) :
                        base(position, color, rotation, scale, effects, layerDepth)
        {
            Anime = TheDic.Big[hero][state];
            CurrentIndex = 0;
            CurrentFrame = 0;
            Texture = Anime.Tex;
        }
        public Animation(Heros hero, States state, Vector2 position, Color color, float rotation, Vector2 scale, float layerDepth) :
                        base(color, rotation, scale, layerDepth)
        {
            Anime = TheDic.Big[hero][state];
            CurrentIndex = 0;
            CurrentFrame = 0;
            Texture = Anime.Tex;
        }

        public Animation(Heros hero, States state, Vector2 position, float rotation, Vector2 scale, float layerDepth) :
                        base(Color.White, rotation, scale, layerDepth)
        {
            Anime = TheDic.Big[hero][state];
            CurrentIndex = 0;
            CurrentFrame = 0;
            Texture = Anime.Tex;
        }
        #endregion

        public void Update()
        {
            Texture = Anime.Tex;
            SourceRectangle = Anime.Recs[CurrentIndex];
            if (Effects == SpriteEffects.FlipHorizontally)
                Origin = new Vector2(SourceRectangle.Value.Width - Anime.Orgs[CurrentIndex].X, Anime.Orgs[CurrentIndex].Y);
            else
                Origin = Anime.Orgs[CurrentIndex];
            if ((int)Anime.Pace < CurrentFrame++)
            {
                CurrentFrame = 0;
                CurrentIndex++;
                CurrentIndex %= Anime.Recs.Count;
            }

            base.Draw();
        }
    }
}
