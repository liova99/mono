using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_race_levan
{
    class ColorCollision
    {

        public static bool CarIsOnRoad(Vector2 PositionCar, Texture2D TextureCar, Texture2D TextureRoad)
        {
            Rectangle RectangleCar = new Rectangle((int)PositionCar.X, (int)PositionCar.Y, TextureCar.Width, TextureCar.Height);

            Color[] TextureDataRoad = new Color[TextureRoad.Width * TextureRoad.Height];
            TextureRoad.GetData(TextureDataRoad);

            for (int i = RectangleCar.Top; i < RectangleCar.Bottom; i++)
                for (int j = RectangleCar.Left; j < RectangleCar.Right; j++)
                    if (TextureDataRoad[i * TextureRoad.Width + j] != Color.Gray)
                        return false;

            return true;
        }

    }
}
