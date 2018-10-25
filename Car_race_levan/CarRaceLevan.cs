using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Car_race_levan
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class CarRaceLevan : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D car;
        Vector2 carPosition;
        float carSpeed;

        public CarRaceLevan()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            // Initial position: Center
            carPosition = new Vector2(
                graphics.PreferredBackBufferWidth / 2,
                graphics.PreferredBackBufferHeight / 2
                );

            // The speed of the Car :)
            carSpeed = 300f;

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

            // TODO: use this.Content to load your game content here

            // Load the car <texture2D oder 3D> ("name_of_the_file")
            car = Content.Load<Texture2D>("auto_cabrio");
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

            // TODO: Add your update logic here

            // check if any key pressed 
            var kstate = Keyboard.GetState();

            // update the position whnen key pressed

            if (kstate.IsKeyDown(Keys.Up))
                carPosition.Y -= carSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Down))
                carPosition.Y += carSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Left))
                carPosition.X -= carSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (kstate.IsKeyDown(Keys.Right))
                carPosition.X += carSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //CarPosition.X = Math.Min(Math.Max(ballTexture.Width / 2, ballPosition.X), graphics.PreferredBackBufferWidth - ballTexture.Width / 2);
            //CarPosition.Y = Math.Min(Math.Max(ballTexture.Height / 2, ballPosition.Y), graphics.PreferredBackBufferHeight - ballTexture.Height / 2);

            // the division dependent on the scale of the DrawModel, wenn scale 1, then devide with 2
            carPosition.X = Math.Min(Math.Max(car.Width / 10, carPosition.X), graphics.PreferredBackBufferWidth - car.Width / 10);
            carPosition.Y = Math.Min(Math.Max(car.Height / 10, carPosition.Y), graphics.PreferredBackBufferHeight - car.Height / 10);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //Draw the car
            spriteBatch.Begin();

            Vector2 origin = new Vector2(car.Width / 2, car.Height / 2);

            spriteBatch.Draw(car, carPosition, null, Color.White, .0f, origin, 0.2f, SpriteEffects.None, 0f);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
