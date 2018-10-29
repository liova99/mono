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
        // GraphicsDeviceManager graphics;

        //SpriteBatch spriteBatch;

        
        SpriteBatch spriteBatch;
        GraphicsDeviceManager graphics;


        Car cabrio = new Car();
        Vector2 cabrioPosition;

        Car blueCar = new Car();
        Vector2 blueCarPosition;

        




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
            cabrioPosition = cabrio.CarPosition;
            blueCarPosition = blueCar.CarPosition;


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

            cabrio.CarTexture = Content.Load<Texture2D>("auto_cabrio");
            blueCar.CarTexture = Content.Load<Texture2D>("auto_blue");

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
            {
                cabrio.MoveForward();
                cabrioPosition = cabrio.CarPosition;
            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                cabrio.MoveBackwards();
                cabrioPosition = cabrio.CarPosition;

            }

            if (kstate.IsKeyDown(Keys.Left))
            {
                cabrio.CarAngle -= cabrio.CarRotationSpeed; //carAnlge * (float)gameTime.ElapsedGameTime.TotalSeconds / 1;
            }


            if (kstate.IsKeyDown(Keys.Right))
            {
                cabrio.CarAngle += cabrio.CarRotationSpeed;
            }

            cabrio.DefineBorders();

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

            // == Cabrio==
            Vector2 cabrioOrigin = new Vector2(cabrio.CarTexture.Width / 2, cabrio.CarTexture.Height / 2);

            spriteBatch.Draw(cabrio.CarTexture, cabrioPosition, null, Color.White, cabrio.CarAngle, cabrioOrigin, 0.2f, SpriteEffects.None, 0f);



            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
