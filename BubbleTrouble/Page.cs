using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;
using System.Collections.Generic;
using BubbleTrouble.ProjectStates;

namespace BubbleTrouble
{
    public class Page
    {
        #region Data
        public Texture2D Tex { get; private set; }
        public List<Rectangle> Recs { get; private set; }
        public List<Vector2> Orgs { get; private set; }
        public Tempo Pace { get; private set; }
        #endregion

        #region Ctors
        public Page(Heros hero, States state)
        {
            Recs = new List<Rectangle>();
            Orgs = new List<Vector2>();
            Tex = S.cm.Load<Texture2D>(hero + "/" + state);
            Color[] c = new Color[Tex.Width];
            List<int> pos = new List<int>();

            Tex.GetData(0, 0, new Rectangle(0, Tex.Height - 1, Tex.Width, 1), c, 0, Tex.Width);
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] != c[1])
                    pos.Add(i);
            }
            for (int i = 0; i < pos.Count - 2; i += 2)
            {
                Recs.Add(new Rectangle(pos[i], 0, pos[i + 2] - pos[i], Tex.Height - 2));
            }
            for (int i = 0; i < pos.Count - 2; i += 2)
            {
                Orgs.Add(new Vector2(pos[i + 1] - pos[i], Tex.Height - 2));
            }
            Pace = FindTempo(state);

            // Make background color transparent
            MakeTransparent();
        }
        #endregion

        private Tempo FindTempo(States state)
        {
            switch (state)
            {
                case States.Stance:
                    return Tempo.Slow;
                case States.Walk:
                    return Tempo.Slow;
                case States.Fire:
                    return Tempo.Slow;
                default:
                    return Tempo.Slow;
            }
        }

        private void MakeTransparent()
        {
            Color[] allcolor = new Color[Tex.Width * Tex.Height];

            Tex.GetData<Color>(allcolor);
            for (int i = 1; i < allcolor.Length; i++)
            {
                if (allcolor[i] == allcolor[0])
                    allcolor[i] = Color.Transparent;
            }
            allcolor[0] = Color.Transparent;
            Tex.SetData<Color>(allcolor);
        }
    }
}
