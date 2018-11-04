﻿using Car_race_levan.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Car_race_levan
{
    public class Car : Game
    {
        // Almost everything is private for education purpose
        private GraphicsDeviceManager _graphics;
        private Texture2D _car;
        private Vector2 _carPosition;
        private Vector2 _direction;
        private float _carSpeed;
        private float _maxCarSpeed;
        private float _carSpeedBackwards;
        private float _carAngle;
        private float _carRotationSpeed;
        private Rectangle _carReckangle;
        public bool IsDrifting;
        private float wheelBase; // the distance between the two axes

        private int screenWidth;
        private int ScreenHeigh;
        public Input Input;

        public Car()
        {


            //_graphics = new GraphicsDeviceManager(this);

            //screenWidth =  GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            //ScreenHeigh =  GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            // TODO: NO HARDCODING!!!!!
            screenWidth = 1024;
            ScreenHeigh = 768;


            _carPosition = new Vector2(1024 / 2,
                                      768 / 2
                                    );
            //_carPosition = new Vector2(GraphicsDevice.Viewport.Width / 2,
            //                           GraphicsDevice.Viewport.Height / 2);

            //Direction = new Vector2((float)Math.Cos(CarAngle), (float)Math.Sin(CarAngle));
            //CarTexture = _car;
            //_carReckangle = new Rectangle((int)CarPosition.X, (int)CarPosition.Y, CarTexture.Width /5, CarTexture.Height/2);

            _carSpeed = 0f;
            _maxCarSpeed = 0f;
            _carSpeedBackwards = 0f;
            _carAngle = 0.00f;
            _carRotationSpeed = 0.05f;
            IsDrifting = false;
        }

        // == Methods ===========================

        /// <summary>
        /// Direction of which the car must to move
        /// </summary>
        /// <returns>Direction </returns>
        public Vector2 CarDirection()
        {
                return Direction = new Vector2((float)Math.Cos(CarAngle), (float)Math.Sin(CarAngle));

        }

        public void SetCarRotationSpeed()
        {

        }

        /// <summary>
        /// Move the car 'x' pixels forwards.
        /// So x is the carSpeed
        /// </summary>
        /// <returns>New car Position</returns>
        public void MoveForward(float carSpeed)
        {
            CarDirection();
            CarPosition -= Direction * carSpeed;

        }
        /// <summary>
        /// Slide the car forward
        /// if the button will be released.
        /// The speed of the car  will be reduced in the Move() function
        /// </summary>
        /// <param name="carSpeed"></param>
        public void SlideForward(float carSpeed)
        {

            CarDirection();
            CarPosition -= Direction * carSpeed;
        }


        /// <summary>
        /// Move the car x pixels backwards.
        /// </summary>
        /// <returns>New car Position</returns>
        public void MoveBackwards(float carSpeedBackwards)
        {
            CarDirection();
            CarPosition += Direction * carSpeedBackwards;

        }
        /// <summary>
        /// slide the car a litel bit Backwards,
        /// if the button will be released.
        /// The speed of the car  will be reduced in the Move() function
        /// </summary>
        /// <param name="carSpeedBackwards"></param>
        public void SlideBackwards(float carSpeedBackwards)
        {
            CarDirection();
            CarPosition += Direction * carSpeedBackwards;
        }






        // TODO: maby DefineBordes  method don't belong to the car Class?? 
        // TODO: maby delete it?
        /// <summary>
        /// Define the borders, otherwise the car 
        /// will be go outside of our screen
        /// </summary>
        public void DefineBorders(Car car)
        {
            // ========= The MonoGame Way =================
            //_carPosition.X = Math.Min(Math.Max(CarTexture.Width / 3, _carPosition.X), _graphics.PreferredBackBufferWidth - CarTexture.Width / 3);
            //_carPosition.Y = Math.Min(Math.Max(CarTexture.Height / 3, _carPosition.Y), _graphics.PreferredBackBufferHeight - CarTexture.Height / 3);

            //Console.WriteLine("CarTexture.Width: {0} \n, _carPosition.X: {1} \n graphics.PreferredBackBufferWidth: {2} \n positionX: {3}",
            //    CarTexture.Width, _carPosition.X, _graphics.PreferredBackBufferWidth, _carPosition.X);


            //=========My way============

            if (car.CarPosition.X <= 0)
            {
                car.CarSpeed = 0;
                car.CarSpeedBackwards = 0;
                //car.MoveBackwards(5);
                _carPosition.X = 3;


                //cabrio.CarSpeed = -Math.Max((cabrio.CarSpeed * 0.3f), 1);
                //cabrio.CarSpeedBackwards = -Math.Max((cabrio.CarSpeedBackwards * 0.3f), 1);

                CarPosition = car.CarPosition;
                //cabrio.CarSpeed = cabrio.CarSpeed - 2;// - (cabrio.CarSpeed + Math.Max((cabrio.CarSpeed * 0.3f),1));

            }

            if (car.CarPosition.Y <= 0)
            {
                car.CarSpeed = 0;
                car.CarSpeedBackwards = 0;
                _carPosition.Y = 3;

                CarPosition = car.CarPosition;
            }



            if (car.CarPosition.X >= screenWidth)
            {
                car.CarSpeed = 0;
                car.CarSpeedBackwards = 0;
                _carPosition.X = screenWidth - 2;

                CarPosition = car.CarPosition;
            }
            if (car.CarPosition.Y >= ScreenHeigh)
            {
                car.CarSpeed = 0;
                car.CarSpeedBackwards = 0;
                _carPosition.Y = ScreenHeigh - 2;

                CarPosition = car.CarPosition;
            }

        }

        /// <summary>
        /// Keine Ahnung man... 
        /// </summary>
        /// <param name="car">Das Auto!!</param>
        /// <param name="maxCarSpeed">max speed of the car</param>
        public void Update(Car car, float maxCarSpeed, float maxSpeedBackwards)
        {
            Move(car, maxCarSpeed, maxSpeedBackwards);
            DefineBorders(car);

        }

        public void Move(Car car, float maxCarSpeed, float maxSpeedBackwards)
        {
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Input.Up))
            {
                car.MoveForward(car.CarSpeed);

                if (car.CarSpeed <= maxCarSpeed)
                {
                    car.CarSpeed += 0.1f;
                }
                CarPosition = car.CarPosition;
            }
            // slide the car a litel bit forward, if stop pushing the forward button
            if (kstate.IsKeyUp(Input.Up) & car.CarSpeed > 0) // previousState.IsKeyDown(Keys.Up)
            {
                car.SlideForward(car.CarSpeed);
                CarPosition = car.CarPosition;
                car.CarSpeed -= 0.1f;

            }
            if (kstate.IsKeyDown(Input.Down))
            {
                // break the car to still 
                if (car.CarSpeed > 0)
                {
                    car.CarSpeed -= 0.2f;
                }
                // then go backwards, speed add up 0.1 (pixel) until max speed 
                else if (car.CarSpeedBackwards < maxSpeedBackwards)
                {
                    car.CarSpeedBackwards += 0.1f;

                }

                car.MoveBackwards(car.CarSpeedBackwards);
                CarPosition = car.CarPosition;
            }
            // slide the car a litel bit Backwards, if stop pushing the Backwards button
            if (kstate.IsKeyUp(Input.Down) & car.CarSpeedBackwards > 0)
            {
                car.SlideBackwards(car.CarSpeedBackwards);
                CarPosition = car.CarPosition;
                car.CarSpeedBackwards -= 0.1f;
            }
            //Turn left or right only if speed > 0
            if (kstate.IsKeyDown(Input.Left) & (car.CarSpeedBackwards > 0 || car.CarSpeed > 0))
            {
                car.CarSpeed -= 0.05f;
                car.CarAngle -= car.CarRotationSpeed; //carAnlge * (float)gameTime.ElapsedGameTime.TotalSeconds / 1;
            }

            if (kstate.IsKeyDown(Input.Right) & (car.CarSpeedBackwards > 0 || car.CarSpeed > 0))
            {

                car.CarSpeed -= 0.05f;
                car.CarAngle += car.CarRotationSpeed;
            }

            // Drifting
            //if(kstate.IsKeyDown(Input.Left) & kstate.IsKeyDown(Input.Up) & car.CarSpeed > 3)
            //{
            //    float driftCarAngle = car.CarAngle + 1;
            //    car.CarAngle += 1; 
            //    car.CarSpeed -= 0.01f;
            //    CarPosition = car.CarPosition;
            //    car.CarAngle -= 1;

            //}

        }


        // TODO: add default position for the cars
        // ex. cabrio at start position 1 
        /// <summary>
        /// Draw the Textur of your car,
        /// initialize the default position
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="car"></param>
        public void Draw(SpriteBatch spriteBatch, Car car)
        {
            Vector2 origin = new Vector2(car.CarTexture.Width / 2, car.CarTexture.Height / 2);
            // Vector2 origin = new Vector2(car.CarTexture.Width / 15, car.CarTexture.Height / 15); 

            //spriteBatch.Draw(car.CarTexture, CarPosition, null, Color.White, car.CarAngle, origin, 0.4f, SpriteEffects.None, 0f);
            // Rectangle carRectangle = new Rectangle((int)car.CarPosition.X, (int)car.CarPosition.Y, car.CarTexture.Width, car.CarTexture.Height);
            Rectangle carRectangle = new Rectangle(0,0, car.CarTexture.Width, car.CarTexture.Height);
                       

            spriteBatch.Draw(car.CarTexture, CarPosition, carRectangle, Color.White, car.CarAngle, origin, 0.4f, SpriteEffects.None, 0f);

            
            
        }


        // == END Methods ===========================



        // ===== geters and seters ==========

        public Texture2D CarTexture
        {
            get => _car;
            set
            {
                _car = value;
            }
        }

        public Vector2 CarPosition
        {
            get => _carPosition;
            set
            {
                _carPosition = value;
            }
        }

        public float CarSpeed
        {
            get => _carSpeed;
            set
            {
                _carSpeed = value;
            }
        }

        public float MaxCarSpeed
        {
            get => _maxCarSpeed;
            set
            {
                _maxCarSpeed = value;
            }
        }

        public float CarSpeedBackwards
        {
            get => _carSpeedBackwards;
            set
            {
                _carSpeedBackwards = value;
            }


        }

        public float CarAngle
        {
            get => _carAngle;
            set
            {
                _carAngle = value;
            }
        }

        public float CarRotationSpeed
        {
            get => _carRotationSpeed;
            set
            {
                _carRotationSpeed = value;
            }
        }

        public Vector2 Direction
        {
            get => _direction;
            set
            {
                _direction = value;
            }
        }

        // ===== END geters and seters ==========











    }


}
