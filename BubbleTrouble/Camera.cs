using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace BubbleTrouble
{
    public class Camera
    {
        public Matrix Mat { get; private set; }
        public Matrix ScaleMatrix { get; private set; }
        MouseState currentMouse;
        MouseState previousMouse;

        int xTrans = S.screenWidth / 2;
        int yTrans = S.screenHeight / 2;

        int xCenter;
        int yCenter;

        float lerp = 0.93f;

        float scale;
        IFocus focus;
        Vector2 position;
        public Camera(IFocus focus)
        {
            this.focus = focus;
            position = Vector2.Zero;

            previousMouse = Mouse.GetState();
            scale = 1f;
        }

        public void Update()
        {
            xCenter = (int)(xTrans / scale);
            yCenter = (int)(yTrans / scale);

            currentMouse = Mouse.GetState();

            if (currentMouse.ScrollWheelValue - previousMouse.ScrollWheelValue > 0)
            {
                scale += 0.1f;
                lerp = 1f;
            }
            else if (currentMouse.ScrollWheelValue - previousMouse.ScrollWheelValue < 0)
            {
                scale -= 0.1f;
                lerp = 1f;
            }
            else
                lerp = 0.93f;

            if (scale < 0.4f)
                scale = 0.4f;

            ScaleMatrix = Matrix.Lerp(ScaleMatrix, Matrix.CreateScale(scale), 0.09f);

            previousMouse = currentMouse;


            //Mat = Matrix.CreateTranslation(new Vector3(-position, 0)) * Matrix.CreateScale(0.8f) *
            //      Matrix.CreateTranslation(new Vector3(new Vector2(300, 480), 0));
            //position = Vector2.Lerp(focus.Position + Vector2.UnitY * 40f, position, 0.93f);

            Mat = Matrix.CreateTranslation(new Vector3(-position, 0)) * ScaleMatrix * Matrix.CreateRotationZ(0) *
                  Matrix.CreateTranslation(new Vector3(new Vector2(xTrans, yTrans), 0));
            position = Vector2.Lerp(focus.Position + Vector2.UnitY * 40f, position, lerp);


            if (position.X - xCenter < 0)
                position = new Vector2(xCenter, position.Y);
            if (position.Y - yCenter < 0)
                position = new Vector2(position.X, yCenter);

            if (position.X + xCenter > S.screenWidth * 3)
                position = new Vector2(S.screenWidth * 3 - xCenter, position.Y);
            if (position.Y + yCenter > (S.screenHeight - 30) * 3)
                position = new Vector2(position.X, (S.screenHeight - 30) * 3 - yCenter);
        }
    }
}

//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using System;

//namespace OrganizeProject
//{
//    public class Camera
//    {
//        public Matrix Mat { get; private set; }
//        public Matrix ScaleMatrix { get; private set; }
//        MouseState currentMouse;
//        MouseState previousMouse;

//        int xTrans = 300;//S.screenWidth / 2;
//        int yTrans = 480;//S.screenHeight / 2;

//        int xCenter;
//        int yCenter;

//        float lerp = 0.93f;

//        float scale;
//        IFocus focus;
//        public Vector2 position;
//        public Camera(IFocus focus)
//        {
//            this.focus = focus;
//            position = Vector2.Zero;
//            previousMouse = Mouse.GetState();
//            scale = 0.8f;
//        }

//        public void Update()
//        {
//            xCenter = (int)(xTrans / scale);
//            yCenter = (int)(yTrans / scale);
//            currentMouse = Mouse.GetState();

//            if (currentMouse.ScrollWheelValue - previousMouse.ScrollWheelValue > 0)
//            {
//                scale += 0.1f;
//                lerp = 1f;
//            }
//            else if (currentMouse.ScrollWheelValue - previousMouse.ScrollWheelValue < 0)
//            {
//                scale -= 0.1f;
//                lerp = 1f;
//            }
//            else
//                lerp = 0.93f;

//            //if (scale < 1)
//            //    scale = 1;

//            ScaleMatrix = Matrix.Lerp(ScaleMatrix, Matrix.CreateScale(scale), 0.09f);

//            previousMouse = currentMouse;

//            //Mat = Matrix.CreateTranslation(new Vector3(-position, 0)) * Matrix.CreateScale(0.8f) *
//            //  Matrix.CreateTranslation(new Vector3(new Vector2(300, 480), 0));

//            Mat = Matrix.CreateTranslation(new Vector3(-position, 0)) * ScaleMatrix * Matrix.CreateRotationZ(0) *
//                  Matrix.CreateTranslation(new Vector3(new Vector2(xTrans, yTrans), 0));
//            position = Vector2.Lerp(focus.Position + Vector2.UnitY * 40f, position, lerp);

//            if (position.X - xCenter < 0)
//                position = new Vector2(xCenter, position.Y);
//            if (position.Y - yCenter < 0)
//                position = new Vector2(position.X, yCenter);

//            if (position.X + xCenter > S.screenWidth)
//                position = new Vector2(S.screenWidth - xCenter, position.Y);
//            if (position.Y + yCenter > S.screenHeight)
//                position = new Vector2(position.X, S.screenHeight - yCenter);
//        }
//    }
//}

//    using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using System;

//namespace OrganizeProject
//{
//    public class Camera
//    {
//        public Matrix Mat { get; private set; }
//        IFocus focus;
//        Vector2 position;
//        public Camera(IFocus focus)
//        {
//            this.focus = focus;
//            position = Vector2.Zero;
//        }

//        public void Update()
//        {
//            Mat = Matrix.CreateTranslation(new Vector3(-position, 0)) * Matrix.CreateScale(0.8f) *
//                  Matrix.CreateTranslation(new Vector3(new Vector2(300, 480), 0));
//            position = Vector2.Lerp(focus.Position + Vector2.UnitY * 40f, position, 0.93f);
//        }
//    }
//}

