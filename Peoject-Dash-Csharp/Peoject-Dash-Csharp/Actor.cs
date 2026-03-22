using System;

class Actor : GameObject
{
    private Vector2D mWorldLocation;
    private Text2DRenderer mText2D;

    public Vector2D WorldLocation
    {
        get => mWorldLocation;
        set
        {
            mWorldLocation = value;

            ConsolePoint screenPos;

            screenPos.x = GameMath.ToScreenCoord(value.x);
            screenPos.y = GameMath.ToScreenCoord(value.y);

            mText2D.ScreenPos = screenPos;
        }

    }

    public bool IsVisible
    {
        get => mText2D.IsDrawing;
        set => mText2D.IsDrawing = value;
    }
    public override void Update()
    {
    }

    public Actor(Vector2D worldLocation, string[] text2D, string color = RendererManager.RESET)
    {
        this.mWorldLocation = worldLocation;

        ConsolePoint screenPos;

        screenPos.x = GameMath.ToScreenCoord(worldLocation.x);
        screenPos.y = GameMath.ToScreenCoord(worldLocation.y);

        this.mText2D = new Text2DRenderer(screenPos: screenPos,text2D: text2D, color:color);
        NewComponemt(mText2D);
    }
}

