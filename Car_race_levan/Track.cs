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
    

    class Track
    {
        public GraphicsDeviceManager Graphics;
        public Texture2D TrackTexture;

        public Track()
        {
        }
        /// <summary>
        /// Draw the track
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="track"></param>
        /// <param name="screenWidth"></param>
        /// <param name="ScreenHeight"></param>
        public void Draw(SpriteBatch spriteBatch, Track track, int screenWidth, int ScreenHeight)
        {
            Rectangle mainFrame = new Rectangle(0, 0, screenWidth, ScreenHeight);
            spriteBatch.Draw(track.TrackTexture, mainFrame, Color.White);

        }


    }

    
}
