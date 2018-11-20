### Graphic Settings 

```c#
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;

            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

screenWidth = graphics.PreferredBackBufferWidth;
ScreenHeight = graphics.PreferredBackBufferHeight;
graphics.PreferredBackBufferWidth = GraphicsDevice.Viewport.Width;
graphics.PreferredBackBufferHeight = GraphicsDevice.Viewport.Height;

```





### Colors


```c#
    /// <summary>
    /// Checks the given Texture2D pixel by pixel
    ///  and returns a List with the position and the color of every pixel
    /// </summary>
    /// <param name = "track" ></ param >
    /// < returns > returns a List with the position and the color of every pixel</returns>
    public color[,] roadposition(texture2d track)
    {
        color[] mycolors = new color[track.width * track.height];
        track.getdata(mycolors);

        color[,] colors2d = new color[track.width, track.height];
        for (int x = 0; x < screenwidth; x++)
        {
            for (int y = 0; y < track.height; y++)
            {
                colors2d[x, y] = mycolors[x + y * track.width];
            }
        }

        if (colors2d[707, 53] != color.transparent)
        {
            console.writeline("asdflaksdjflkadsfjlkadsjflkads");
        }

        return colors2d;

    }
```





### Timer

```c#
//Initialize the timer
float timer = 3;         
const float TIMER = 3;


float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
timer -= elapsed;
if (timer < 0)
{

cabrio.IsOnRoad(carRectangle, greenBG.TrackTexture, cabrio);
timer = TIMER;   //Reset Timer
}
```



### HeighthMap

```c#
Texture2D heightMap;
Texture2D heightMapTexture;
VertexPositionTexture[] vertices; // ??


// heightMap
        int width;
        int height;  

// array to read heightMap data
        float[,] heightMapData;   

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

    public void Draw()
    {
        //graphicsDevice.(PrimitiveType.TriangleList, vertices, 0, vertices.Length);
    }

    #endregion HeightMap
```


### Keyboard previous state

`KeyboardState previousState;`



### Full screen

```c#
graphics.IsFullScreen = true;
	OR
graphics.ToggleFullScreen(); 

```



### Car Physics 

http://engineeringdotnet.blogspot.com/2010/04/simple-2d-car-physics-in-games.html



### Drifting 

```c#

```



### Draw a Rectangle outline

#### first way

make a property

```c#
Texture2D pixel;
```



under the LoadContent()

```c#
protected override void LoadContent()
        {
            pixel = new Texture2D(GraphicsDevice, 1, 1);
           // so that we can draw whatever color we want on top of it
            pixel.SetData(new[] { Color.White });  

        }
```

then in Draw() 

```c#
Rectangle titleSafeRectangle = cabrio.CarRectangle;
cabrio.DrawBorder(titleSafeRectangle, 3, Color.Red, spriteBatch, cabrio.CarTexture);

```

and the DrawBorder funtion in the car.cs

```c#
        public void DrawBorder(Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor, SpriteBatch spriteBatch, Texture2D pixel)
        {
            // Draw top line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), borderColor);

            // Draw left line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);

            // Draw right line
            spriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder),
                                            rectangleToDraw.Y,
                                            thicknessOfBorder,
                                            rectangleToDraw.Height), borderColor);
            // Draw bottom line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X,
                                            rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder,
                                            rectangleToDraw.Width,
                                            thicknessOfBorder), borderColor);
        }

```



### Second way

make a property

```c#
Texture2D pixel;
```



under the LoadContent() the same

```c#
protected override void LoadContent()
        {
            pixel = new Texture2D(GraphicsDevice, 1, 1);
           // so that we can draw whatever color we want on top of it
            pixel.SetData(new[] { Color.White });  

        }
```

then in Draw() 

```c#
        spriteBatch.Draw(pixel, new Rectangle(cabrio.CarRectagleTest.Left, cabrio.CarRectagleTest.Top, 3, cabrio.CarRectagleTest.Height), Color.Black); // Left
        spriteBatch.Draw(pixel, new Rectangle(cabrio.CarRectagleTest.Right, cabrio.CarRectagleTest.Top, 3, cabrio.CarRectagleTest.Height), Color.Black); // Right
        spriteBatch.Draw(pixel, new Rectangle(cabrio.CarRectagleTest.Left, cabrio.CarRectagleTest.Top, cabrio.CarRectagleTest.Width, 3), Color.Black); // Top
        spriteBatch.Draw(pixel, new Rectangle(cabrio.CarRectagleTest.Left, cabrio.CarRectagleTest.Bottom, cabrio.CarRectagleTest.Width, 3), Color.Black); // Bottom
```














