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
    

    public class Track
    {
        //GraphicsDevice graphicsDevice;

        public Texture2D TrackTexture;

        //public Texture2D TrackBG;

        // heightMap
        int width;
        int height;

        Texture2D heightMap;
        Texture2D heightMapTexture;
        VertexPositionTexture[] vertices; // ??


        // array to read heightMap data
        float[,] heightMapData;


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
        public void Draw(SpriteBatch spriteBatch, Color color, Track track, int screenWidth, int ScreenHeight)
        {
            Rectangle mainFrame = new Rectangle(0, 0, screenWidth, ScreenHeight);
            spriteBatch.Draw(track.TrackTexture, mainFrame, color);

        }

        #region HeighthMap 

        public void SetHeightMapData(Texture2D heightMap, Texture2D heightMapTexture)
        {
            this.heightMap = heightMap;
            this.heightMapTexture = heightMapTexture;
            width = heightMap.Width;
            height = heightMap.Height;
            SetHeights();
        }
        public void SetHeights()
        {
            Color[] greyValues = new Color[width * height];
            heightMap.GetData(greyValues);
            heightMapData = new float[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    heightMapData[x, y] = greyValues[x + y * width].G / 3.1f;
                }
            }
        }

        //public void Draw()
        //{
        //    //graphicsDevice.(PrimitiveType.TriangleList, vertices, 0, vertices.Length);
        //}

        #endregion HeightMap



    }


}
