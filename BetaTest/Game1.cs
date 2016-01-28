using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BetaTest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //private int screenWidth;
        //private int screenHeight;

        private KeyboardState keyBoardState;

        private Texture2D vader;
        //private Rectangle position;
        private Vector2 position = new Vector2(0,0);
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //Размер экрана
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            //graphics.IsFullScreen = true;
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            vader = Content.Load<Texture2D>("vader");

            //screenWidth = GraphicsDevice.Viewport.Width;
            //screenHeight = GraphicsDevice.Viewport.Height;
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            keyBoardState = Keyboard.GetState();
            //Перемещение объекта
            if (keyBoardState.IsKeyDown(Keys.Up)) 
                position.Y -= 5;
            if (keyBoardState.IsKeyDown(Keys.Down))
                position.Y += 5;
            if (keyBoardState.IsKeyDown(Keys.Left))
                position.X -= 5;
            if (keyBoardState.IsKeyDown(Keys.Right))
                position.X += 5;
            //Рамки экрана
            if (position.X <= 0) 
                position.X = 0;
            if (position.Y <= 0)
                position.Y = 0;
            if (position.Y > graphics.PreferredBackBufferHeight -vader.Height)
                position.Y = graphics.PreferredBackBufferHeight - vader.Height;
            if (position.X > graphics.PreferredBackBufferWidth - vader.Width)
                position.X = graphics.PreferredBackBufferWidth - vader.Width;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(vader, position, Color.White);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
