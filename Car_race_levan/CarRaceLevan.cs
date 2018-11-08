using Car_race_levan.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
//using System.Drawing;
//using System.Windows.Media.Imaging;

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

        // Track
        Track easyTrack = new Track();
        Track greenBG = new Track();
        Track blackBG = new Track();
        Track testTrack = new Track();

        // Cars
        Car cabrio = new Car();
        Car blueCar = new Car();

        // KeyboardInteraction keyboardInteraction = new KeyboardInteraction();

        // === DEBUG == 
        public SpriteFont font;
        public string cabrioPosition;

        float timer = 3;         //Initialize a 10 second timer
        const float TIMER = 3;
        public Texture2D bmpTexture;

        //public Bitmap bitmap;


        public static System.Drawing.Image image; 
        public System.Drawing.Bitmap trackBitmap;


        

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

            // Cars star position
            cabrio.CarPosition = new Vector2(707 , 53);
            blueCar.CarPosition = new Vector2(707, 125);

            // Take the track_big_bmp file convertet it to bmp with screenWidht and screenHeight values 
            image = System.Drawing.Image.FromFile("C:\\MyDocs\\Projects\\Car_race_levan\\Car_race_levan\\Content\\track_big_bmp.bmp");
            // new trackBitmap object from Image
            trackBitmap = new System.Drawing.Bitmap(image, screenWidth, ScreenHeight);
            // call the function to take the list with colors of every pixel
            cabrio.Pixels(trackBitmap);



            MouseState mouseState = Mouse.GetState();
            String mousePosition = new Vector2(mouseState.X, mouseState.Y).ToString();

            this.IsMouseVisible = true;



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
            greenBG.TrackTexture = Content.Load<Texture2D>("greenBG");
            blackBG.TrackTexture = Content.Load<Texture2D>("blackBG");
            font = Content.Load<SpriteFont>("font");
            testTrack.TrackTexture = Content.LoadLocalized<Texture2D>("track_big_bmp");

            
            //bmpTexture = new Texture2D(1024.768);

            // 
          
            //cabrio.RoadPosition(bmpTexture);
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

            

           
            
            if(cabrio.IsOnRoad(cabrio, cabrio.CarRectangle) == true)
            {
                Console.WriteLine("ON ROAD");
            }
            else
            {
                Console.WriteLine("NOT ON ROAD");
            }




            if (cabrio.CarRectangle.Intersects(blueCar.CarRectangle))
            {
                cabrio.CarSpeed = 0;
                blueCar.CarSpeed = 0;
            }

            cabrio.Update(cabrio, 7, 3);
            blueCar.Update(blueCar, 7, 3);



            // DEBUG
            cabrioPosition = String.Format("Cabrio, Position {0}\n Angle {1} \n Direction {2}", cabrio.CarPosition, cabrio.CarAngle, cabrio.Direction);

            //cabrioPosition = (cabrio.CarPosition.ToString());

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


            //So try the below to automatically draw an image full screen.

            //SpriteBatch.Draw(background_texture, GraphicsDevice.Viewport.Bounds, Color.White);


            //==Tracks ==
            //blackBG.Draw(spriteBatch, Color.Transparent, blackBG, screenWidth, ScreenHeight);
           greenBG.Draw(spriteBatch, Color.White, greenBG,  screenWidth, ScreenHeight);
            //blackBG.Draw(spriteBatch, Color.Transparent, blackBG, screenWidth, ScreenHeight);

            easyTrack.Draw(spriteBatch, Color.White, easyTrack, screenWidth, ScreenHeight);

            easyTrack.Draw(spriteBatch, Color.White, testTrack, screenWidth, ScreenHeight);



            // == Cars ==

            cabrio.Draw(spriteBatch, cabrio);
            blueCar.Draw(spriteBatch, blueCar);


            // ==DEBUG==

            MouseState mouseState = Mouse.GetState();
            String mousePosition = new Vector2(mouseState.X, mouseState.Y).ToString();

            spriteBatch.DrawString(font, cabrioPosition, new Vector2(0, 0), Color.Red);
            spriteBatch.DrawString(font, mousePosition, new Vector2(0, 80), Color.Red);

            //cabrio.RoadPosition(easyTrack.TrackTexture);


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
