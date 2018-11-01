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
        KeyboardState previousState;



        Track track = new Track();

        // KeyboardInteraction keyboardInteraction = new KeyboardInteraction();


        // === Carbrio properties == 
        Car cabrio = new Car();
        Vector2 cabrioPosition;
        float maxCabrioSpeed;
        float maxcabrioSpeedBackwards;

        // === Blue Car properties == 
        Car blueCar = new Car();
        Vector2 blueCarPosition;
        float maxBlueCarSpeed;
        float maxBlueCarSpeedBackwards;
        


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

            // get which key was pressed last time
            previousState = Keyboard.GetState();

            //graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            //graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //graphics.IsFullScreen = true;

            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;

            // graphics.ToggleFullScreen(); 
            graphics.ApplyChanges();


            // ==== Cabrio Initialize====
            cabrioPosition = cabrio.CarPosition;
            maxCabrioSpeed = 12f;
            maxcabrioSpeedBackwards = 5f;

            // ==== BlueCar Initialize====
            blueCarPosition = blueCar.CarPosition;
            maxBlueCarSpeed = 15f;
            maxBlueCarSpeedBackwards = 5f;

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
            track.trackTexture = Content.Load<Texture2D>("track_big");

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
                cabrio.MoveForward(cabrio.CarSpeed);
                cabrioPosition = cabrio.CarPosition;
                if (cabrio.CarSpeed <= maxCabrioSpeed)
                {
                    cabrio.CarSpeed += 0.1f;
                }


            }
            // slide the car a litel bit forward, if stop pushing the forward button
            if (kstate.IsKeyUp(Keys.Up) & cabrio.CarSpeed > 0) // previousState.IsKeyDown(Keys.Up)
            {
                cabrio.SlideForward(cabrio.CarSpeed);
                cabrioPosition = cabrio.CarPosition;
                cabrio.CarSpeed -= 0.1f;

            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                // break the car to still 
                if (cabrio.CarSpeed > 0)
                {
                    cabrio.CarSpeed -= 0.2f;
                }
                // then go backwards, speed add up 0.1 (pixel) until max speed 
                else if (cabrio.CarSpeedBackwards < maxcabrioSpeedBackwards)
                {
                    cabrio.CarSpeedBackwards += 0.1f;

                }

                cabrio.MoveBackwards(cabrio.CarSpeedBackwards);
                cabrioPosition = cabrio.CarPosition;
            }
            // slide the car a litel bit Backwards, if stop pushing the Backwards button
            if (kstate.IsKeyUp(Keys.Down) & cabrio.CarSpeedBackwards > 0)
            {
                cabrio.SlideBackwards(cabrio.CarSpeedBackwards);
                cabrioPosition = cabrio.CarPosition;
                cabrio.CarSpeedBackwards -= 0.1f;
            }

            if (kstate.IsKeyDown(Keys.Left))
            {
                if (cabrio.CarSpeed > 0)
                {
                    cabrio.CarAngle -= cabrio.CarRotationSpeed; //carAnlge * (float)gameTime.ElapsedGameTime.TotalSeconds / 1;
                }
            }
            
            if (kstate.IsKeyDown(Keys.Right))
            {
                if (cabrio.CarSpeed > 0)
                {
                    cabrio.CarAngle += cabrio.CarRotationSpeed;
                }
            }
            
            if (kstate.IsKeyDown(Keys.W))
            {

                blueCar.MoveForward(blueCar.CarSpeed);
                blueCarPosition = blueCar.CarPosition;
                if (blueCar.CarSpeed <= maxBlueCarSpeed)
                {
                    blueCar.CarSpeed += 0.15f;
                }

            }
            // slide the car a litel bit, if stop pushing the forward button
            if (kstate.IsKeyUp(Keys.W) & blueCar.CarSpeed > 0)
            {
                blueCar.SlideForward(blueCar.CarSpeed);
                blueCarPosition = blueCar.CarPosition;
                blueCar.CarSpeed -= 0.1f;
            }

            if (kstate.IsKeyDown(Keys.S))
            {
                // break the car to still 
                if(blueCar.CarSpeed > 0 )
                {
                    blueCar.CarSpeed -= 0.2f;
                }
                // then go backwards, speed add up 0.1 (pixel) until max speed 
                else if (blueCar.CarSpeedBackwards < maxBlueCarSpeedBackwards)
                {
                    blueCar.CarSpeedBackwards += 0.1f;
             
                }

                blueCar.MoveBackwards(blueCar.CarSpeedBackwards);
                blueCarPosition = blueCar.CarPosition;
            }

            // slide the car a litel bit Backwards, if stop pushing the Backwards button
            if (kstate.IsKeyUp(Keys.S) & blueCar.CarSpeedBackwards > 0)
            {
                blueCar.SlideBackwards(blueCar.CarSpeedBackwards);
                blueCarPosition = blueCar.CarPosition;
                blueCar.CarSpeedBackwards -= 0.1f;
            }

            if (kstate.IsKeyDown(Keys.A))
            {
                if (blueCar.CarSpeed > 0)
                {
                    blueCar.CarAngle -= blueCar.CarRotationSpeed; //carAnlge * (float)gameTime.ElapsedGameTime.TotalSeconds / 1;

                }
            }


            if (kstate.IsKeyDown(Keys.D))
            {
                if (blueCar.CarSpeed > 0)
                {
                    blueCar.CarAngle += blueCar.CarRotationSpeed;

                }
            }


            blueCar.DefineBorders();
            cabrio.DefineBorders();

            //keyboardInteraction.PressedKey();

            Console.WriteLine(cabrio.CarSpeed);
            Console.WriteLine(blueCar.CarSpeedBackwards);

            base.Update(gameTime);

            previousState = kstate;
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

            //==Track Big ==
            //Vector2 trackOrigin = new Vector2(track.trackTexture.Width / 2, track.trackTexture.Height / 2);
            Rectangle mainFrame = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            spriteBatch.Draw(track.trackTexture, mainFrame, Color.White);


            // == Cabrio==
            Vector2 cabrioOrigin = new Vector2(cabrio.CarTexture.Width / 2, cabrio.CarTexture.Height / 2);

            spriteBatch.Draw(cabrio.CarTexture, cabrioPosition, null, Color.White, cabrio.CarAngle, cabrioOrigin, 0.6f, SpriteEffects.None, 0f);

            // == Blue Car==
            Vector2 blueCarOrigin = new Vector2(blueCar.CarTexture.Width / 2, blueCar.CarTexture.Height / 2);

            spriteBatch.Draw(blueCar.CarTexture, blueCarPosition, null, Color.White, blueCar.CarAngle, blueCarOrigin, 0.6f, SpriteEffects.None, 0f);



            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
