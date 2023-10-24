using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BubbleTrouble
{
    public abstract class BaseKeys
    {
        public abstract Boolean RightPressed();
        public abstract Boolean LeftPressed();
        public abstract Boolean UpPressed();
        public abstract Boolean DownPressed();
        public abstract Boolean RightReleased();
        public abstract Boolean LeftReleased();
        public abstract Boolean UpReleased();
        public abstract Boolean DownReleased();
        public abstract Boolean ShiftPressed();
        public abstract Boolean SpacePressed();
    }

    public class UserKeys : BaseKeys
    {
        #region Data
        Keys right, left, up, down, run, fire;
        #endregion

        #region Ctors
        public UserKeys(Keys right, Keys left, Keys up, Keys down, Keys run, Keys fire)
        {
            this.right = right;
            this.left = left;
            this.up = up;
            this.down = down;
            this.run = run;
            this.fire = fire;
        }
        #endregion

        public override Boolean RightPressed()
        {
            return Keyboard.GetState().IsKeyDown(right);
        }
        public override Boolean LeftPressed()
        {
            return Keyboard.GetState().IsKeyDown(left);
        }
        public override Boolean UpPressed()
        {
            return Keyboard.GetState().IsKeyDown(up);
        }
        public override Boolean DownPressed()
        {
            return Keyboard.GetState().IsKeyDown(down);
        }
        public override Boolean RightReleased()
        {
            return Keyboard.GetState().IsKeyUp(right);
        }
        public override Boolean LeftReleased()
        {
            return Keyboard.GetState().IsKeyUp(left);
        }
        public override Boolean UpReleased()
        {
            return Keyboard.GetState().IsKeyUp(up);
        }
        public override Boolean DownReleased()
        {
            return Keyboard.GetState().IsKeyUp(down);
        }
        public override Boolean ShiftPressed()
        {
            return Keyboard.GetState().IsKeyDown(run);
        }
        public override Boolean SpacePressed()
        {
            return Keyboard.GetState().IsKeyDown(fire);
        }
    }
}
