using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using BubbleTrouble;

namespace BubbleTrouble
{
    static class TheDic
    {
        public static Dictionary<Heros, Dictionary<States, Page>> Big =
            new Dictionary<Heros, Dictionary<States, Page>>();

        public static void Init()
        {
            foreach (Heros hero in Enum.GetValues(typeof(Heros)))
            {
                Dictionary<States, Page> heroDic = new Dictionary<States, Page>();
                foreach (States state in Enum.GetValues(typeof(States)))
                {
                    if (File.Exists(Directory.GetCurrentDirectory() + "/Content/" + hero + "/" + state + ".xnb"))
                    {
                        heroDic.Add(state, new Page(hero, state));
                    }
                }
                Big.Add(hero, heroDic);
            }

        }

    }
}
