using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_race_levan.Sprites
{
    public class Checkpoint
    {
        public Texture2D ChekpointTexture;
        
        private Rectangle _startLineCheckpointRectangle;
        private Rectangle _firstCheckpointRectangle;
        private Rectangle _secondCheckpointRectangle;
        private Rectangle _thirdCheckpointRectangle;
        private Rectangle _fourthCheckpointRectangle;
        private Rectangle _fifthCheckpointRectangle;



        public Checkpoint()
        {
            _startLineCheckpointRectangle = new Rectangle(685, 35, 7, 113); // |
            _firstCheckpointRectangle     = new Rectangle(200, 37, 7, 113); // |
            _secondCheckpointRectangle    = new Rectangle(51, 571, 101, 7); // --
            _thirdCheckpointRectangle     = new Rectangle(815, 631, 7, 101); // |
            _fourthCheckpointRectangle    = new Rectangle(320, 418, 104, 7); // --
            _fifthCheckpointRectangle     = new Rectangle(900, 184, 88, 7); // --
        }

        /// <summary>
        /// Create Checkpoint line
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="color"></param>
        /// <param name="checkpoint"></param>
        /// <param name="rectangle"></param>
        public void Draw(SpriteBatch spriteBatch, Color color, Checkpoint checkpoint, Rectangle rectangle)
        {
           
            spriteBatch.Draw(checkpoint.ChekpointTexture, rectangle, color);
        }


        #region Geter and Seter

        public Rectangle StartLineCheckpointRectangle
        {
            get => _startLineCheckpointRectangle;
            set
            {
                _startLineCheckpointRectangle = value;
            }
        }

        public Rectangle FirstCheckpointRectangle
        {
            get => _firstCheckpointRectangle;
            set
            {
                _firstCheckpointRectangle = value;
            }
        }

        public Rectangle SecondCheckpointRectangle
        {
            get => _secondCheckpointRectangle;
            set
            {
                _secondCheckpointRectangle = value;
            }
        }

        public Rectangle ThirdCheckpointRectangle
        {
            get => _thirdCheckpointRectangle;
            set
            {
                _thirdCheckpointRectangle = value;
            }
        }
        public Rectangle FourthCheckpointRectangle
        {
            get => _fourthCheckpointRectangle;
            set
            {
                _fourthCheckpointRectangle = value;
            }
        }
        public Rectangle FifthCheckpointRectangle
        {
            get => _fifthCheckpointRectangle;
            set
            {
                _fifthCheckpointRectangle = value;
            }
        }


        #endregion Geter and seter
    }


}
