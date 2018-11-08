


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





 
​                

```c#
float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
timer -= elapsed;
if (timer < 0)
{

cabrio.IsOnRoad(carRectangle, greenBG.TrackTexture, cabrio);
timer = TIMER;   //Reset Timer
}
```