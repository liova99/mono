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

        private GraphicsDeviceManager _graphics;
        private Texture2D _car;
        private Vector2 _carPosition;
        private Vector2 _direction;
        private float _carSpeed;
        private float _carSpeedBackwards;
        private float _carAngle;
        private float _carRotationSpeed;

        public Car()
        {


            _graphics = new GraphicsDeviceManager(this);

            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            _carPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
                                      _graphics.PreferredBackBufferHeight / 2
                                     );


            //Direction = new Vector2((float)Math.Cos(CarAngle), (float)Math.Sin(CarAngle));
            //CarTexture = _car;
            _carSpeed = 0f;
            _carSpeedBackwards = 0f;
            _carAngle = 0.00f;
            _carRotationSpeed = 0.05f;
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
            CarPosition += Direction * CarSpeedBackwards;
            
        }
        /// <summary>
        /// slide the car a litel bit Backwards,
        /// if stop pushing the Backwards button
        /// </summary>
        /// <param name="speed of the Car"></param>
        public void SlideBackwards(float carSpeedBackwards)
        {

            CarDirection();
            CarPosition += Direction * carSpeedBackwards;
        }






        // TODO: maby DefineBordes  method don't belong to the car Class?? 
        /// <summary>
        /// Define the borders, otherwise the car 
        /// will be go outside of our screen
        /// </summary>
        public void DefineBorders()
        {
            _carPosition.X = Math.Min(Math.Max(CarTexture.Width / 3, _carPosition.X), _graphics.PreferredBackBufferWidth - CarTexture.Width / 3);
            _carPosition.Y = Math.Min(Math.Max(CarTexture.Height / 3, _carPosition.Y), _graphics.PreferredBackBufferHeight - CarTexture.Height / 3);
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
