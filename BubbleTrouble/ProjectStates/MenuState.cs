using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using System.ComponentModel;

namespace BubbleTrouble.ProjectStates
{
    public class MenuState : State
    {

        private List<Component> components;


        public MenuState(Game1 game) : base(S.cm, S.gd, game)
        {
            var buttonTexture = game.Content.Load<Texture2D>("Goblin/Button");
            var ExitbuttonTexture = game.Content.Load<Texture2D>("Goblin/ExitButton");
            var buttonFont = S.font;

            var newGameButton = new Button(buttonTexture)
            {
                Scale = 1f,
                Position = new Vector2(100, 590)

                //Text = "Start Game",
            };

            newGameButton.Click += NewGameButton_Click;

            var quitGameButton = new Button(ExitbuttonTexture)//, buttonFont)
            {
                Position = new Vector2(S.screenWidth / 2, 600),
                Scale = 1f
                //Text = "Quit Game",
            };

            quitGameButton.Click += QuitGameButton_Click;

            components = new List<Component>()
            {
                newGameButton,
                quitGameButton
            };


        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(game.Content.Load<Texture2D>("Goblin/Menu"), new Vector2(0, 0), Color.White);


            foreach (var component in components)
                component.Draw(gameTime, spriteBatch);


            spriteBatch.End();
            spriteBatch.Begin();
        }

        public void NewGameButton_Click(object sender, EventArgs e)
        {
            game.ChangeState(new GameState(game));
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in components)
                component.Update(gameTime);
        }

        public void QuitGameButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Exit");
            game.Exit();
        }
    }
}
