using Car_race_levan.Models;
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
        public bool IsDrifting;
        //private float wheelBase; // the distance between the two axes
        public Color[] SurfaceColor;

        private int screenWidth;
        private int ScreenHeight;
        public Input Input;

        public long LongColor;

        public System.Drawing.Color[,] ColorOfPixel { get; set; }

        public Car()
        {


            //_graphics = new GraphicsDeviceManager(this);

            //screenWidth =  GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            //ScreenHeight =  GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            // TODO: NO HARDCODING!!!!!
            screenWidth = 1024;
            ScreenHeight = 768;


            _carPosition = new Vector2(screenWidth / 2,
                                      ScreenHeight / 2
                                    );
            //_carPosition = new Vector2(GraphicsDevice.Viewport.Width / 2,
            //                           GraphicsDevice.Viewport.Height / 2);

            //Direction = new Vector2((float)Math.Cos(CarAngle), (float)Math.Sin(CarAngle));
            //CarTexture = _car;
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
            if (car.CarPosition.Y >= ScreenHeight)
            {
                car.CarSpeed = 0;
                car.CarSpeedBackwards = 0;
                _carPosition.Y = ScreenHeight - 2;

                CarPosition = car.CarPosition;
            }

        }

        /// <summary>
        /// The update(move logic) of the car
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carRectangle"></param>
        /// <param name="bg"></param>
        /// <param name="car"></param>
        public void IsOnRoad(Rectangle carRectangle, Texture2D bg, Car car)
        {
            int carPixels = screenWidth * ScreenHeight;
            Color[] myColors = new Color[carPixels];
            //car.CarTexture.GetData<Color>(0, carRectangle, myColors, 0, carPixels);
            car.CarTexture.GetData<Color>(myColors, 0, myColors.Length);

            foreach (Color aColor in myColors)
            {
                Console.WriteLine(aColor);
                if (aColor == Color.Black)
                {
                    Console.WriteLine(myColors.Length);
                    Console.WriteLine("COLOR BLACK");
                }
                else
                {
                    Console.WriteLine(myColors.Length);
                    Console.WriteLine("No Color");
                }
            }
        }

        /// <summary>
        /// Checks the given Texture2D pixel by pixel
        ///  and returns a List with the position and the color of every pixel
        /// </summary>
        /// <param name="track"></param>
        /// <returns>returns a List with the position and the color of every pixel</returns>
        //public Color[,] RoadPosition(Texture2D track)
        //{
        //    Color[] myColors = new Color[track.Width * track.Height];
        //    track.GetData(myColors);

        //    Color[,] colors2D = new Color[track.Width, track.Height];
        //    for (int x = 0; x < screenWidth; x++)
        //    {
        //        for (int y = 0; y < track.Height; y++)
        //        {
        //            colors2D[x, y] = myColors[x + y * track.Width];
        //        }
        //    }

        //    if (colors2D[707, 53] != Color.Transparent)
        //    {
        //        Console.WriteLine("asdflaksdjflkadsfjlkadsjflkads");
        //    }

        //    return colors2D;

        //}

        /// <summary>
        /// Creates two-dimensional  array  
        /// tha contains the color of every pixel from
        /// the given bitmap and assignt it to
        /// ColorOfPixel array
        /// </summary>
        /// <param name="trackBitmap"></param>
        /// <returns>assignt the array to ColorOfPixel </returns>
        public System.Drawing.Color[,] Pixels(System.Drawing.Bitmap bitmap)
        {
            List<System.Drawing.Color> myColors = new List<System.Drawing.Color>();
            // trackBitmap.GetData(myColors);

            System.Drawing.Color[,] colors2D = new System.Drawing.Color[screenWidth, ScreenHeight];
            Vector2[,] position = new Vector2[screenWidth, ScreenHeight];
            for (int i = 0; i < screenWidth; i++)
            {
                for (int h = 0; h < ScreenHeight; h++)
                {
                    //colors2D[i, h] = myColors[i + h * screenWidth];
                    System.Drawing.Color pixelColor = bitmap.GetPixel(i, h);
                    myColors.Add(pixelColor);
                    position[i, h] = position[i, h];
                    colors2D[i, h] = pixelColor;
                }
            }

            //if (colors2D[707, 53] != Color.Transparent)
            //{
            //    Console.WriteLine("asdflaksdjflkadsfjlkadsjflkads");
            //}

            Console.WriteLine(colors2D[707, 53]);
            Console.WriteLine("==================");
            Console.WriteLine();

            return ColorOfPixel = colors2D;
        }


        /// <summary>
        /// Checks if the car is on Road
        /// </summary>
        /// <param name="car">You car object </param>
        /// <returns>true or false</returns>
        public Boolean IsOnRoad(Car car)
        {
            
            float stringCarPositionX = float.Parse(car.CarPosition.X.ToString());
            float stringCarPositionY = float.Parse(car.CarPosition.Y.ToString());
            Console.WriteLine();
            if (ColorOfPixel[(int)stringCarPositionX, (int)stringCarPositionY] == System.Drawing.Color.FromArgb(255, 0, 0, 0))
            {
                return true;
            }

            return false;
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

            spriteBatch.Draw(car.CarTexture, CarPosition, null, Color.White, car.CarAngle, origin, 0.4f, SpriteEffects.None, 1f);

            //Rectangle carRectangle = new Rectangle((int)car.CarPosition.X, (int)car.CarPosition.Y, car.CarTexture.Width, car.CarTexture.Height);
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
