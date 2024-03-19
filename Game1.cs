using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Making_More_Classes
{
  
    public class Game1 : Game
    {

        Random generator;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        List<Texture2D> booTextures;
        Texture2D hauntedBackgroundTexture;

        MouseState mouseState;


        List<Ghost> ghosts;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            generator = new Random();
            booTextures = new List<Texture2D>();
            ghosts = new List<Ghost>();
            base.Initialize();
            for (int i = 0; i < 20; i++)
                ghosts.Add(new Ghost(booTextures, new Rectangle(generator.Next(500), generator.Next(500), 40, 40)));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            hauntedBackgroundTexture = Content.Load<Texture2D>("Images/haunted background");
            booTextures.Add(Content.Load<Texture2D>("Images/boo-stopped"));
            for (int i = 1; i <= 8; i++)
                booTextures.Add(Content.Load<Texture2D>("Images/boo-move-" + i));

        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            // TODO: Add your update logic here
            foreach (Ghost ghost in ghosts)
                ghost.Update(gameTime, mouseState);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(hauntedBackgroundTexture, new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), Color.White);
            foreach (Ghost ghost in ghosts)
                ghost.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}