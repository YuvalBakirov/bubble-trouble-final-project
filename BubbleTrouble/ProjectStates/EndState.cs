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
    public class EndState : State
    {
        private List<Component> components;
        private GameState gameState;
        private bool isTie = false;
        private int numOfTeamWon;

        public EndState(Game1 game, GameState gameState, int numOfTeamWon) : base(S.cm, S.gd, game)
        {
            if (numOfTeamWon == 0)
                isTie = true;
            else
                this.numOfTeamWon = numOfTeamWon - 1;

            this.gameState = gameState;

            var buttonTexture = game.Content.Load<Texture2D>("Goblin/Button");
            var ExitbuttonTexture = game.Content.Load<Texture2D>("Goblin/ExitButton");

            var buttonFont = S.font;


            var newGameButton = new Button(buttonTexture)
            {
                Scale = 1f,
                Position = new Vector2(S.screenWidth / 2, 500)
                //Text = "Start Game",
            };

            newGameButton.Click += NewGameButton_Click;

            var quitGameButton = new Button(ExitbuttonTexture)
            {
                Position = new Vector2(S.screenWidth - 100, 600),
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

            
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, gameState.cam.Mat);

            gameState.background.Draw();

            spriteBatch.End();
            spriteBatch.Begin();

            if (isTie)
            {
                Texture2D tieTexture = game.Content.Load<Texture2D>("Goblin/Tie"); // Dictionaries.TextureDictionary[FolderTextures.Graphics]["Tie"];
                spriteBatch.Draw(tieTexture, new Vector2(S.screenWidth / 2 - tieTexture.Width / 2, 50), Color.White);
            }
            else
            {
                if (numOfTeamWon == 0)
                {
                    Texture2D wonTexture = game.Content.Load<Texture2D>("Goblin/Win"); // Dictionaries.TextureDictionary[FolderTextures.Graphics][General.teamColorString[numOfTeamWon] + "Won"];
                    spriteBatch.Draw(wonTexture, new Vector2(S.screenWidth / 2 - wonTexture.Width / 2, 50), Color.White);
                }
                else
                {
                    Texture2D loseTexture = game.Content.Load<Texture2D>("Goblin/Lose"); // Dictionaries.TextureDictionary[FolderTextures.Graphics][General.teamColorString[numOfTeamWon] + "Won"];
                    spriteBatch.Draw(loseTexture, new Vector2(S.screenWidth / 2 - loseTexture.Width / 2, 50), Color.White);
                }
            }
        }

        public void NewGameButton_Click(object sender, EventArgs e)
        {
            game.ChangeState(new MenuState(game));
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
