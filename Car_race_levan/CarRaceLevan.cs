using Car_race_levan.Models;
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

        SpriteBatch spriteBatch;
        GraphicsDeviceManager graphics;
        //KeyboardState previousState;

        // Screen Parameters
        private int screenWidth;
        private int ScreenHeight;

        Track easyTrack = new Track();
        Car cabrio = new Car();
        Car blueCar = new Car();

        // KeyboardInteraction keyboardInteraction = new KeyboardInteraction();


        // === Blue Car properties == 
        //Car blueCar = new Car();
        //Vector2 blueCarPosition;
        //float maxBlueCarSpeed;
        //float maxBlueCarSpeedBackwards;




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

            // TODO: Add your initialization logic 

            // ======= Graphic settings ===============
            //graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            //graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //
            //screenWidth = graphics.PreferredBackBufferWidth;
            //ScreenHeight = graphics.PreferredBackBufferHeight;
            //graphics.PreferredBackBufferWidth = GraphicsDevice.Viewport.Width;
            //graphics.PreferredBackBufferHeight = GraphicsDevice.Viewport.Height; 

            screenWidth = graphics.PreferredBackBufferWidth = 1024;
            ScreenHeight = graphics.PreferredBackBufferHeight = 768;

           //graphics.IsFullScreen = true;
            //graphics.ToggleFullScreen(); 
            graphics.ApplyChanges();

            // Initialise the cars keys
            cabrio.Input = new Input() { Up = Keys.Up, Down = Keys.Down, Left = Keys.Left, Right = Keys.Right };
            blueCar.Input = new Input() { Up = Keys.W, Down = Keys.S, Left = Keys.A, Right = Keys.D };


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
            cabrio.CarTexture = Content.Load<Texture2D>("cabrio");
            blueCar.CarTexture = Content.Load<Texture2D>("blue");
            easyTrack.TrackTexture = Content.Load<Texture2D>("track_big");

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
            // Exit if escape key will pressed 
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)){ Exit(); }

            Rectangle carRectangle = new Rectangle((int)cabrio.CarPosition.X, (int)cabrio.CarPosition.Y, cabrio.CarTexture.Width /5, cabrio.CarTexture.Height/2);
            Rectangle carRectangle2 = new Rectangle((int)blueCar.CarPosition.X, (int)blueCar.CarPosition.Y, blueCar.CarTexture.Width/5, blueCar.CarTexture.Height/2);

            if (carRectangle.Intersects(carRectangle2))
            {
                cabrio.CarSpeed = 0;
                blueCar.CarSpeed = 0;
            }
            cabrio.Update(cabrio, 7, 3);
            blueCar.Update(blueCar, 7, 3);
            

           

            // DEBUG
            Console.WriteLine("Cabrio, Position {0}, Angle {1} Direction {2}", cabrio.CarPosition, cabrio.CarAngle, cabrio.Direction);
            //Console.WriteLine("Blue, Position {0}, Angle {1}, direction {2}" , blueCar.CarPosition, blueCar.CarAngle, blueCar.Direction);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            //==Tracks ==

            easyTrack.Draw(spriteBatch, easyTrack, screenWidth, ScreenHeight);


            // == Cars ==

            cabrio.Draw(spriteBatch, cabrio);

            

            blueCar.Draw(spriteBatch, blueCar);


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
