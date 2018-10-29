using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        private float _carAngle;
        private float _carRotationSpeed;

        public Car()
        {
            

            _graphics = new GraphicsDeviceManager(this);

            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            CarPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
                                      _graphics.PreferredBackBufferHeight / 2
                                     );


            //Direction = new Vector2((float)Math.Cos(CarAngle), (float)Math.Sin(CarAngle));
            CarTexture = _car;
            CarSpeed = 300f;
            CarAngle = 0.00f;
            CarRotationSpeed = 0.05f;
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

        /// <summary>
        /// Move the car 5 pixels forwards
        /// </summary>
        /// <returns>New car Position</returns>
        public void MoveForward()
        {
            CarDirection();
            CarPosition -= Direction * 7;

        }

        /// <summary>
        /// Move the car 5 pixels backwards 
        /// </summary>
        /// <returns>New car Position</returns>
        public Vector2 MoveBackwards()
        {
            CarDirection();
            return CarPosition += Direction * 1;
        }


        // TODO: maby DefineBordes  method don't belong to the car Class?? 
        /// <summary>
        /// Define the borders, otherwise the car 
        /// will be go outside of our screen
        /// </summary>
        public void DefineBorders()
        {
            _carPosition.X = Math.Min(Math.Max(CarTexture.Width / 3, _carPosition.X), _graphics.PreferredBackBufferWidth - CarTexture.Width / 3);
            _carPosition.Y = Math.Min(Math.Max(CarTexture.Height / 3, _carPosition.Y), _graphics.PreferredBackBufferHeight - CarTexture.Height/ 3);
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
