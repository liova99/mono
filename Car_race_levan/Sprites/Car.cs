using Car_race_levan.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO add the right namespace (sprites)
namespace Car_race_levan.Sprites
{
    public class Car : Game
    {
        // Almost everything is private for education purpose
        private GraphicsDeviceManager _graphics; // i will need it if i make posible change screen resolution
        private Texture2D _car;
        private Vector2 _carPosition;
        private Vector2 _direction;
        private float _carSpeed;
        private float _maxCarSpeed;
        private float _carSpeedBackwards;
        private float _carAngle;
        private float _carRotationSpeed = 0.05f;
        public KeyboardState previusKeyboardState { get; set; }

        private int screenWidth = 1024;
        private int ScreenHeight = 768;
        public Input Input; // Keyboard Input


        // ==== CheckPonitsCounter=====
        Checkpoint checkpoint = new Checkpoint();
        private int _onCheckpoint;
        private int _round = -1;

        private bool _onStartCheckpoint = false;
        private bool _onFirstCheckpoint = false;
        private bool _onSecondCheckpoint = false;
        private bool _onThirdCheckpoint = false;
        private bool _onFourthCheckpoint = false;
        private bool _onFifthCheckpoint = true;
        // ==== End CheckPonitsCounter=====

        // ==== Drifting==============================
        // TODO: maby Pivate?
        private bool _isDriftigLeft = false;

        private bool _isDriftingRight = false;

        public bool PreviusLeftDriftingState = false;
        public bool PreviusRightDriftingState = false;

        public float Driftangle = 0;
        // ==== End Drifting =========================

        //=====Check if Car on Road========================
        public System.Drawing.Color[,] ColorOfPixel { get; set; }

        public Rectangle CarRectangle;

        public System.Drawing.Color leftForwardCorner { get; set; }
        public System.Drawing.Color rightForwardCorner { get; set; }
        public System.Drawing.Color leftBackCorner { get; set; }
        public System.Drawing.Color rightBackCorner { get; set; }
        // ======= End Chek if Car on Road===============

        //===== DEBUG ===== 
        public Rectangle CarRectagleTest;



        public Car(int maxS)
        {
            //_graphics = new GraphicsDeviceManager(this);
            //screenWidth =  GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            //ScreenHeight =  GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            _maxCarSpeed = maxS;
            


        }

        // == Methods ===========================

        /// <summary>
        /// Direction of which the car must to move.
        /// If the car is Drifting, the direction will be changed 
        /// so the car will be slide to the left or right.
        /// </summary>
        /// <returns>Direction of the car</returns>
        public void CarDirection()
        {
            var kstate = Keyboard.GetState();

            if (IsDriftingLeft)
            {
                Direction = new Vector2((float)Math.Cos(CarAngle + Driftangle), (float)Math.Sin(CarAngle + Driftangle));
            }
            else if (IsDriftingRight)
            {
                Direction = new Vector2((float)Math.Cos(CarAngle - Driftangle), (float)Math.Sin(CarAngle - Driftangle));
            }
            else if(PreviusLeftDriftingState)
            {
                Direction = new Vector2((float)Math.Cos(CarAngle + Driftangle), (float)Math.Sin(CarAngle + Driftangle));
            }
            else if (PreviusRightDriftingState)
            {
                Direction = new Vector2((float)Math.Cos(CarAngle - Driftangle), (float)Math.Sin(CarAngle - Driftangle));
            }
            else
            {
                Direction = new Vector2((float)Math.Cos(CarAngle), (float)Math.Sin(CarAngle));
            }
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
        //public void SlideForward(float carSpeed)
        //{
        //    CarDirection();
        //    CarPosition -= Direction * carSpeed;
        //}


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
        //public void SlideBackwards(float carSpeedBackwards)
        //{
        //    CarDirection();
        //    CarPosition += Direction * carSpeedBackwards;
        //}


        // TODO: maby DefineBordes  method don't belong to the car Class?? 
        // TODO: maby delete it?
        // TODO: maby not...
        /// <summary>
        /// Define the borders, otherwise the car 
        /// will be go outside of our (your) screen
        /// </summary>
        public void DefineBorders()
        {
            // ========= The MonoGame Way =================
            //_carPosition.X = Math.Min(Math.Max(CarTexture.Width / 3, _carPosition.X), _graphics.PreferredBackBufferWidth - CarTexture.Width / 3);
            //_carPosition.Y = Math.Min(Math.Max(CarTexture.Height / 3, _carPosition.Y), _graphics.PreferredBackBufferHeight - CarTexture.Height / 3);

            //Console.WriteLine("CarTexture.Width: {0} \n, _carPosition.X: {1} \n graphics.PreferredBackBufferWidth: {2} \n positionX: {3}",
            //    CarTexture.Width, _carPosition.X, _graphics.PreferredBackBufferWidth, _carPosition.X);


            //=========My way============

            if (CarPosition.X <= 0)
            {
                CarSpeed = 0;
                CarSpeedBackwards = 0;
                //car.MoveBackwards(5);
                _carPosition.X = 3;

                //cabrio.CarSpeed = -Math.Max((cabrio.CarSpeed * 0.3f), 1);
                //cabrio.CarSpeedBackwards = -Math.Max((cabrio.CarSpeedBackwards * 0.3f), 1);

                
                //cabrio.CarSpeed = cabrio.CarSpeed - 2;// - (cabrio.CarSpeed + Math.Max((cabrio.CarSpeed * 0.3f),1));

            }

            if (CarPosition.Y <= 0)
            {
                CarSpeed = 0;
                CarSpeedBackwards = 0;
                _carPosition.Y = 3;
            }


            if (CarPosition.X >= screenWidth)
            {
                CarSpeed = 0;
                CarSpeedBackwards = 0;
                _carPosition.X = screenWidth - 2;
                
            }
            if (CarPosition.Y >= ScreenHeight)
            {
                CarSpeed = 0;
                CarSpeedBackwards = 0;
                _carPosition.Y = ScreenHeight - 2;
            }

        }


        /// <summary>
        /// The update (move logic) of the car and
        /// call the DefineBordes funtion
        /// </summary>
        /// <param name="car">The Car Object</param>
        /// <param name="maxCarSpeed">Max speed of the car</param>
        /// <param name="maxSpeedBackwards">Max backwards speed of the car</param>
        public void Update(float maxCarSpeed, float maxSpeedBackwards)
        {
            Move(maxCarSpeed, maxSpeedBackwards);
            DefineBorders();
        }
        /// <summary>
        /// Move the car by the press of Keys 
        /// </summary>
        /// <param name="car"> Your Car object</param>
        /// <param name="maxCarSpeed">Max Speed of the car</param>
        /// <param name="maxSpeedBackwards">Max speed car can go backwards</param>
        public void Move(float maxCarSpeed, float maxSpeedBackwards)
        {

            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Input.Up))
            {

                MoveForward(CarSpeed);

                if (CarSpeed <= _maxCarSpeed)
                {
                    CarSpeed += 0.1f;
                }
                else
                {
                    CarSpeed = _maxCarSpeed;
                }
            }
            // slide the car a litel bit forward, if stop pushing the forward button
            if (kstate.IsKeyUp(Input.Up) && CarSpeed > 0) // previousState.IsKeyDown(Keys.Up)
            {
                MoveForward(CarSpeed);
                CarSpeed -= 0.1f;

            }
            if (kstate.IsKeyDown(Input.Down))
            {
                //IsDrifting = false;
                // break the car to still 
                if (CarSpeed > 0)
                {
                    CarSpeed -= 0.2f;
                }
                // then go backwards, speed add up 0.1 (pixel) until max speed 
                else if (CarSpeedBackwards < maxSpeedBackwards)
                {
                    CarSpeedBackwards += 0.1f;
                }

                MoveBackwards(CarSpeedBackwards);
            }
            // slide the car a litel bit Backwards, if stop pushing the Backwards button
            if (kstate.IsKeyUp(Input.Down) & CarSpeedBackwards > 0)
            {
                MoveBackwards(CarSpeedBackwards);
                
                CarSpeedBackwards -= 0.1f;
            }

            // Update: if the car turns it will drifting and go slower,
            // there is no reason to make it more slower
            // Note: Turn left or right only if speed > 0
            if (kstate.IsKeyDown(Input.Left) && (CarSpeedBackwards > 0 || CarSpeed > 0))
            {
                //MakeTheCarSlower(car,5f);
                CarAngle -= CarRotationSpeed; //carAnlge * (float)gameTime.ElapsedGameTime.TotalSeconds / 1;
            }

            if (kstate.IsKeyDown(Input.Right) && (CarSpeedBackwards > 0 || CarSpeed > 0))
            {
                //MakeTheCarSlower(car,5f);
                CarAngle += CarRotationSpeed;
            }

            // === Drifting ========================================
            // TODO: make drifring realistic
            // the speed must be > x (4)
            // the left or right buttun must be pressed
            // the down key must not be pressed
            // the previus pressed key must be not other than the curent, tha means
            // if you drift to the left and then press the right button the Driftangle must be initialised to default (Driftangle = 0)
            if (CarSpeed > 4 & kstate.IsKeyDown(Input.Left) & !kstate.IsKeyDown(Input.Down) & !previusKeyboardState.IsKeyDown(Input.Right) )
            {
                IsDriftingLeft = true;
            }
            else if (CarSpeed > 4 & kstate.IsKeyDown(Input.Right) & !kstate.IsKeyDown(Input.Down) & !previusKeyboardState.IsKeyDown(Input.Left))
            {
                IsDriftingRight = true;
            }

            else
            {
                if (IsDriftingLeft)
                {
                    PreviusLeftDriftingState = true;
                    PreviusRightDriftingState = false;

                    IsDriftingLeft = false;
                }
                else if (IsDriftingRight)
                {
                    PreviusRightDriftingState = true;
                    PreviusLeftDriftingState = false;
                    IsDriftingRight = false;
                }
                else
                {
                    IsDriftingLeft = false;
                    IsDriftingRight = false;
                }
                
               if(Driftangle > 0)
                {
                    Driftangle -= 0.03f;
                }
                
            }

            if (IsDriftingLeft == true || IsDriftingRight == true) 
            {
                if (Driftangle < 0.8)
                {
                    Driftangle += 0.03f;
                }

                CarSpeed -= 0.15f;
                //CarPosition -= Direction * 15f;
            }

            // ===== End Drifting ====================================================

            previusKeyboardState = Keyboard.GetState();

        }

        /// <summary>
        /// Creates two-dimensional  array  
        /// that contains the color of every pixel from
        /// the given bitmap and assignt it to
        /// ColorOfPixel array
        /// </summary>
        /// <param name="trackBitmap"></param>
        /// <returns>assignt the array to ColorOfPixel </returns>
        public void Pixels(System.Drawing.Bitmap bitmap)
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

            ColorOfPixel = colors2D;
        }


        /// <summary>
        /// Checks if the car is on Track. More info in Comments
        /// </summary>
        /// <param name="car">You car object </param>
        /// <returns>true or false</returns>
        public Boolean IsOnTrack(Car car, Rectangle carRectangle)
        {
            /* The position of the car is calculate from the center of the car.
             * I create a rectangle, so the 0,0 punk (left top corner) of the rectangle is
             * the center of the car but we want that the 0,0 punk ist the top left corner
             * of the rectangle. So i create the:
             *      HorizontallyTopCornerX/Y (if the car goes left or right)
             *      VerticalTopCornerX/Y (if the car goes up or down)
             * Now we must canculate the Position of every of the 4 angles of the rectangle  
             * we make this in the Else If statements.
             * Then compare the positon of every angle with the ColorOfPixel[]. (see Pixels() method)
             * If on the position of one of the angles ex. {x=158, y=500} there is not Red pixel, return false. 
            */

            // position of the top left corner of the rectangle
            // if the car go left or rigth
            // *-------| << that is our car
            // |-------|
            int HorizontallyTopCornerX = (int)car.CarPosition.X - (carRectangle.Width / 2);
            int HorizontallyTopCornerY = (int)car.CarPosition.Y - (carRectangle.Height / 2);

            // position of the top left corner of the rectangle
            // if the car goes up or down
            // *----|
            // |    | << that is our car
            // |    |
            // |----|
            int VerticalTopCornerX = (int)car.CarPosition.X - (carRectangle.Height / 2);
            int VerticalTopCornerΥ = (int)car.CarPosition.Y - (carRectangle.Width / 2);


            // we know the rectangle Width, Height and the position of the top left corner
            // We use this to canculate the 3 other angles. That's not rocket science. 
            try
            {
                // If the Car goes up or down:
                if (car.Direction.Y < -0.5 || car.Direction.Y > 0.5) 
                {
                    leftForwardCorner = ColorOfPixel[VerticalTopCornerX, VerticalTopCornerΥ];
                    rightForwardCorner = ColorOfPixel[(VerticalTopCornerX + carRectangle.Height), VerticalTopCornerΥ];
                    leftBackCorner = ColorOfPixel[VerticalTopCornerX, (VerticalTopCornerΥ + carRectangle.Width)];
                    rightBackCorner = ColorOfPixel[(VerticalTopCornerX + carRectangle.Height), (VerticalTopCornerΥ + carRectangle.Height)];
                }
                // If the car goes right or left
                else if (car.Direction.X < -0.5 || car.Direction.X > -0.5) 
                {
                    leftForwardCorner = ColorOfPixel[HorizontallyTopCornerX, HorizontallyTopCornerY + carRectangle.Height];
                    rightForwardCorner = ColorOfPixel[HorizontallyTopCornerX, HorizontallyTopCornerY];
                    leftBackCorner = ColorOfPixel[HorizontallyTopCornerX + car.CarRectangle.Width, HorizontallyTopCornerY + carRectangle.Height];
                    rightBackCorner = ColorOfPixel[HorizontallyTopCornerX + car.CarRectangle.Width, HorizontallyTopCornerY];
                }

                // if the car is on track, return true
                if (leftForwardCorner == System.Drawing.Color.FromArgb(255, 255, 0, 0) &
                       rightForwardCorner == System.Drawing.Color.FromArgb(255, 255, 0, 0) &
                       leftBackCorner == System.Drawing.Color.FromArgb(255, 255, 0, 0) &
                       rightBackCorner == System.Drawing.Color.FromArgb(255, 255, 0, 0)
                       
                    )
                {
                    return true;
                }

            }
            catch
            {
                Console.WriteLine("CATCH NOT ON ROAD");
                
            }

            MakeTheCarSlower(car, 1, 1 );
            return false;
        }

        // TODO: backwards too!
        /// <summary>
        /// Make the car slower.
        /// </summary>
        /// <param name="car">Your car objeckt</param>
        /// <param name="maxAllowedSpeed">The max allowed speed of your car</param>
        /// <param name="maxAllowedSpeedBackwards">The max "backwards" allowed speed of your car</param>
        public void MakeTheCarSlower(Car car, float maxAllowedSpeed, float maxAllowedSpeedBackwards)
        {
            //Console.WriteLine("carSpeed: " + car.CarSpeed);
            if (car.CarSpeed > maxAllowedSpeed)
            {
                car.CarSpeed -= 0.2f;
            }
            if(car.CarSpeedBackwards > maxAllowedSpeedBackwards)
            {
                car.CarSpeedBackwards -= 0.2f;
            }
        }

        /// <summary>
        /// Checks the Checkpoints. The car must be pass throught next
        /// checkpoint. Round counter too.
        /// </summary>
        /// <param name="car">Your Car object</param>
        public void CheckpointCounter(Car car)
        {
            /* When you drive througth a checkpoint, it checks if the previus checkpoint.
             * If the previus checkpoint is set to true then set it to false and set the curent
             * to true. 
             * We count the 
             */
            if (car.CarRectangle.Intersects(checkpoint.StartLineCheckpointRectangle) & car.OnFifthCheckpoint == true)
            {
                car.Round += 1;
                car.OnCheckpoint = 0;
                car.OnFifthCheckpoint = false;
                car.OnStartCheckpoint = true;
            }
            else if (car.CarRectangle.Intersects(checkpoint.FirstCheckpointRectangle) & car.OnStartCheckpoint == true)
            {
                car.OnCheckpoint += 1;
                car.OnStartCheckpoint = false;
                car.OnFirstCheckpoint = true;
            }
            else if (car.CarRectangle.Intersects(checkpoint.SecondCheckpointRectangle) & car.OnFirstCheckpoint == true)
            {
                car.OnCheckpoint += 1;
                car.OnFirstCheckpoint = false;
                car.OnSecondCheckpoint = true;
            }
            else if (car.CarRectangle.Intersects(checkpoint.ThirdCheckpointRectangle) & car.OnSecondCheckpoint == true)
            {
                car.OnCheckpoint += 1;
                car.OnSecondCheckpoint = false;
                car.OnThirdCheckpoint = true;
            }
            else if (car.CarRectangle.Intersects(checkpoint.FourthCheckpointRectangle) & car.OnThirdCheckpoint == true)
            {
                car.OnCheckpoint += 1;
                car.OnThirdCheckpoint = false;
                car.OnFourthCheckpoint = true;
            }
            else if (car.CarRectangle.Intersects(checkpoint.FifthCheckpointRectangle) & car.OnFourthCheckpoint == true)
            {
                car.OnCheckpoint += 1;
                car.OnFourthCheckpoint = false;
                car.OnFifthCheckpoint = true;
            }

        }

        public void Coalition()
        {
            // TODO: make the cars collidieren
        }

        /// <summary>
        /// Draw the Textur of the car,
        /// initialize the default position
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="car"></param>
        public void Draw(SpriteBatch spriteBatch, Car car)
        {
            int carTextureWidth = (int)(car.CarTexture.Width / 2.5);
            int carTextureHeighth = (int)(car.CarTexture.Height / 2.5);


            // Center of rotation
            Vector2 origin = new Vector2(carTextureWidth, carTextureHeighth);
            //Vector2 origin = new Vector2(0, carTextureHeighth / 2);
            
            spriteBatch.Draw(car.CarTexture, CarPosition, null, Color.White, car.CarAngle, origin, 0.4f, SpriteEffects.None, 1f);
            CarRectangle = new Rectangle((int)car.CarPosition.X, (int)car.CarPosition.Y, carTextureWidth, carTextureHeighth);

            CarRectagleTest = new Rectangle(((int)car.CarPosition.X - (CarRectangle.Height / 2)), (int)(car.CarPosition.Y - (CarRectangle.Width / 2)),  carTextureHeighth, carTextureWidth);

            // Vector2 origin = new Vector2(carTextureWidth, carTextureHeighth);
            // Vector2 origin = new Vector2(car.CarTexture.Width / 15, car.CarTexture.Height / 15); 

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

         public bool IsDriftingLeft
        {
            get => _isDriftigLeft;
            set => _isDriftigLeft = value;
        }
        public bool IsDriftingRight
        {
            get => _isDriftingRight;
            set => _isDriftingRight = value;
        }

        // ==== Chekpoints geters and  seters 

        public int Round
        {
            get => _round;
            set
            {
                _round = value;
            }
        }

        public int OnCheckpoint
        {
            get => _onCheckpoint;
            set
            {
                _onCheckpoint = value;
            }
        }
        public bool OnStartCheckpoint
        {
            get => _onStartCheckpoint;
            set
            {
                _onStartCheckpoint = value;
            }
        }
        public bool OnFirstCheckpoint
        {
            get => _onFirstCheckpoint;
            set
            {
                _onFirstCheckpoint = value;
            }
        }
        public bool OnSecondCheckpoint
        {
            get => _onSecondCheckpoint;
            set
            {
                _onSecondCheckpoint = value;
            }
        }
        public bool OnThirdCheckpoint
        {
            get => _onThirdCheckpoint;
            set
            {
                _onThirdCheckpoint = value;
            }
        }
        public bool OnFourthCheckpoint
        {
            get => _onFourthCheckpoint;
            set
            {
                _onFourthCheckpoint = value;
            }
        }
        public bool OnFifthCheckpoint
        {
            get => _onFifthCheckpoint;
            set
            {
                _onFifthCheckpoint = value;
            }
        }




        // ==== end Chekpoints geters seters



        // ===== END geters and seters ==========

    }


}
