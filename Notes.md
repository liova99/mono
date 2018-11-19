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

