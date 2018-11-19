﻿using Car_race_levan.Models;
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

        // Screen Parameters
        private int screenWidth;
        private int ScreenHeight;

        // Track
        Sprites.Track easyTrack = new Sprites.Track();
        Sprites.Track greenBG = new Sprites.Track();
        // Track DEBAG
        Sprites.Track blackBG = new Sprites.Track();
        Sprites.Track testTrackred = new Sprites.Track();

        // Cars
        Sprites.Car cabrio = new Sprites.Car();
        Sprites.Car blueCar = new Sprites.Car();

        // Checkpoints
        Sprites.Checkpoint checkpoint = new Sprites.Checkpoint();


        public SpriteFont font;



        // load the track image, make it a bmp image
        // with spesific width and height(ScreenWidth, ScreenHeight)
        // This trackBitmap will be used on the Pixels funktion.
        // Pixels funtkion will make a List with the colors
        // of every pixes in the trackBitmap img.
        public Texture2D bmpTexture;
        public static System.Drawing.Image image;
        public System.Drawing.Bitmap trackBitmap;


        // === DEBUG == 
        public string cabrioPosition;

        Texture2D pixel;


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
            screenWidth = graphics.PreferredBackBufferWidth = 1024;
            ScreenHeight = graphics.PreferredBackBufferHeight = 768;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            // Initialise the cars keys
            cabrio.Input = new Input() { Up = Keys.Up, Down = Keys.Down, Left = Keys.Left, Right = Keys.Right };
            blueCar.Input = new Input() { Up = Keys.W, Down = Keys.S, Left = Keys.A, Right = Keys.D };

            // Cars start position
            cabrio.CarPosition = new Vector2(707, 53);
            blueCar.CarPosition = new Vector2(707, 125);
            
            // Take the track_big_bmp file then convertet it to bmp with screenWidht and screenHeight values 
            image = System.Drawing.Image.FromFile("E:\\MyDocs\\Projects\\Car_race_levan\\Car_race_levan\\Content\\track_big_red.png");
            // new trackBitmap object from Image
            trackBitmap = new System.Drawing.Bitmap(image, screenWidth, ScreenHeight);

            // call the function to take the list with colors of every pixel
            cabrio.Pixels(trackBitmap);
            blueCar.Pixels(trackBitmap);


            // == DEBUG  Make mouse visible
            MouseState mouseState = Mouse.GetState();
            String mousePosition = new Vector2(mouseState.X, mouseState.Y).ToString();
            IsMouseVisible = true;


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

            // Cars
            cabrio.CarTexture = Content.Load<Texture2D>("cabrio");
            blueCar.CarTexture = Content.Load<Texture2D>("blue");

            //Tracks
            easyTrack.TrackTexture = Content.Load<Texture2D>("track_big");
            greenBG.TrackTexture = Content.Load<Texture2D>("greenBG");

            //Rest objects
            font = Content.Load<SpriteFont>("font");
            checkpoint.ChekpointTexture = Content.Load<Texture2D>("white_line");

            // === DEBUG ===
            testTrackred.TrackTexture = Content.LoadLocalized<Texture2D>("track_big_red");
            blackBG.TrackTexture = Content.Load<Texture2D>("blackBG");
            // create an outline
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.White }); // so that we can draw whatever color we want on top of it


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
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) { Exit(); }

            // CheckPoints
            cabrio.CheckpointCounter(cabrio);
            blueCar.CheckpointCounter(blueCar);
            // Check if on track
            cabrio.IsOnTrack(cabrio, cabrio.CarRectangle);
            blueCar.IsOnTrack(blueCar, blueCar.CarRectangle);

            // Create ("Update") the cars            
            cabrio.Update(cabrio, 7, 3);
            blueCar.Update(blueCar, 7, 3);

            if (cabrio.IsOnTrack(cabrio, cabrio.CarRectangle) == true)
            {
                Console.WriteLine("On ROAD");
            }
            else
            {
                Console.WriteLine("not on Road");
            }
            // === DEBUG ====
            cabrioPosition = String.Format("Cabrio, Position {0}\n Angle {1} \n Direction {2}", cabrio.CarPosition, cabrio.CarAngle, cabrio.Direction);

            


        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // DONE: Add your drawing code here

            spriteBatch.Begin();

            //So try the below to automatically draw an image full screen.
            //SpriteBatch.Draw(background_texture, GraphicsDevice.Viewport.Bounds, Color.White);


            //==Tracks ==
            greenBG.Draw(spriteBatch, Color.White, greenBG, screenWidth, ScreenHeight);
            easyTrack.Draw(spriteBatch, Color.White, easyTrack, screenWidth, ScreenHeight);
            // debug
            //testTrackred.Draw(spriteBatch, Color.White, testTrackred, screenWidth, ScreenHeight);

            // Checkpoints
            checkpoint.Draw(spriteBatch, Color.White, checkpoint, checkpoint.StartLineCheckpointRectangle);
            checkpoint.Draw(spriteBatch, Color.Green, checkpoint, checkpoint.FirstCheckpointRectangle);
            checkpoint.Draw(spriteBatch, Color.Green, checkpoint, checkpoint.SecondCheckpointRectangle);
            checkpoint.Draw(spriteBatch, Color.Green, checkpoint, checkpoint.ThirdCheckpointRectangle);
            checkpoint.Draw(spriteBatch, Color.Green, checkpoint, checkpoint.FourthCheckpointRectangle);
            checkpoint.Draw(spriteBatch, Color.Green, checkpoint, checkpoint.FifthCheckpointRectangle);


            // == Cars ==

            cabrio.Draw(spriteBatch, cabrio);
            blueCar.Draw(spriteBatch, blueCar);


            // ==DEBUG==

            

            Rectangle titleSafeRectangle = cabrio.CarRectangle;
            cabrio.DrawBorder(titleSafeRectangle, 3, Color.Red, spriteBatch, cabrio.CarTexture);

            spriteBatch.Draw(pixel, new Rectangle(cabrio.CarRectagleTest.Left, cabrio.CarRectagleTest.Top, 3, cabrio.CarRectagleTest.Height), Color.Black); // Left
            spriteBatch.Draw(pixel, new Rectangle(cabrio.CarRectagleTest.Right, cabrio.CarRectagleTest.Top, 3, cabrio.CarRectagleTest.Height), Color.Black); // Right
            spriteBatch.Draw(pixel, new Rectangle(cabrio.CarRectagleTest.Left, cabrio.CarRectagleTest.Top, cabrio.CarRectagleTest.Width, 3), Color.Black); // Top
            spriteBatch.Draw(pixel, new Rectangle(cabrio.CarRectagleTest.Left, cabrio.CarRectagleTest.Bottom, cabrio.CarRectagleTest.Width, 3), Color.Black); // Bottom

            MouseState mouseState = Mouse.GetState();
            String mousePosition = new Vector2(mouseState.X, mouseState.Y).ToString();

            spriteBatch.DrawString(font, cabrioPosition, new Vector2(0, 0), Color.Red);
            spriteBatch.DrawString(font, mousePosition, new Vector2(0, 80), Color.Red);

            spriteBatch.DrawString(font, String.Format("Cabrio on Chekpoint {0}", cabrio.OnCheckpoint.ToString()), new Vector2(0, 120), Color.Red);
            spriteBatch.DrawString(font, String.Format("Cabrio Round {0}", cabrio.Round.ToString()), new Vector2(0, 140), Color.Red);

            spriteBatch.DrawString(font, String.Format("Blue Car on Chekpoint {0}", blueCar.OnCheckpoint.ToString()), new Vector2(0, 180), Color.Red);
            spriteBatch.DrawString(font, String.Format("Blue Car Round {0}", blueCar.Round.ToString()), new Vector2(0, 200), Color.Red);

            spriteBatch.DrawString(font, String.Format("Cabrio Speed {0}", cabrio.CarSpeed.ToString()) , new Vector2(0, 240), Color.Red);


            // == end Debug ==

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
